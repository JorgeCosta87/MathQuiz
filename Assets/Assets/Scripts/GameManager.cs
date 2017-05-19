using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public bool m_bFinish = false;
    public int videoIndex;

    public GameObject player;
    public UIManager uiManager;
    public MediaPlayerCtrl videoManager;
    public GameData gameData;
    public GameObject prefabButton;
    public RectTransform ParentPanel;

    void Start () {
        videoIndex = 0;
        videoManager.OnEnd += OnEnd;


        
        /*
        //set the movie btns in runtime!
        for (int i = 0; i < gameData.videos.Length; i++)
        {
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(2, 1, 1);
            Vector3 aux = goButton.transform.position;
            Debug.Log(aux);
            goButton.transform.position = new Vector3(aux.x,aux.y + i * -0.25f ,aux.z);

            Button tempButton = goButton.GetComponent<Button>();
            Text name = tempButton.GetComponentInChildren<Text>();
            name.text = gameData.videos[i];
            tempButton.onClick.AddListener(() => ButtonClicked(gameData.videos[i]));
        }
        */

    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (scrMedia.GetCurrentState() == MediaPlayerCtrl.MEDIAPLAYER_STATE.PLAYING)
        {
            if (GUI.Button(new Rect(200, 200, 100, 100), scrMedia.GetSeekPosition().ToString()))
            {

            }

            if (GUI.Button(new Rect(200, 350, 100, 100), scrMedia.GetDuration().ToString()))
            {

            }

            if (GUI.Button(new Rect(200, 450, 100, 100), scrMedia.GetVideoWidth().ToString()))
            {

            }

            if (GUI.Button(new Rect(200, 550, 100, 100), scrMedia.GetVideoHeight().ToString()))
            {

            }
        }
        */


    }


    void ButtonClicked(string movieName)
    {

        loadVideo(movieName);
    }


    public void rotateScene(float degrees)
    {
        player.transform.Rotate(new Vector3(0, degrees, 0));
        pause();
    }

    public void startGame()
    {
        gameData.numberOfRightQuestions = 0;
        gameData.currentLevel = 1;
        gameData.gameScore.score = 0;
        shuffleQuestions();
        Question startQuestion = getRandomQuestion(gameData.currentLevel);
        gameData.currentQuestion = startQuestion;
        uiManager.setQuestion(startQuestion);
    }

    public void nextQuestion()
    {

        if(gameData.lastLevel == 10)
            //you won the game congrats;

        gameData.numberOfRightQuestions++;
        gameData.gameScore.score += gameData.currentLevel * gameData.basePoints;
        if (gameData.numberOfRightQuestions % 2 == 0)
        {
            gameData.currentLevel++;
            uiManager.showNextLevelPanel(true);
        }
        else
        {
            uiManager.showNextLevelPanel(false);
        }

        gameData.currentQuestion.used = true;

        Question newQuestion = getRandomQuestion(gameData.currentLevel);
        gameData.currentQuestion = newQuestion;
        uiManager.setQuestion(newQuestion);

    }

    public void awnser(string awnser)
    {
        
        int correctAwnser = gameData.currentQuestion.correctAwnser;

        Debug.Log("button:" + awnser + " correct: " + correctAwnser + " bool: " + (awnser == "awnser_1"));

        if (awnser == "awnser_1" && correctAwnser == 1)
        {
            nextQuestion();
        }
        else if (awnser == "awnser_2" && correctAwnser == 2)
        {
            nextQuestion();
        }
        else if (awnser == "awnser_3" && correctAwnser == 3)
        {
            nextQuestion();
        }
        else
        {
            uiManager.gameOver();
        }
    }

    public void shuffleQuestions()
    {
        List<Question> questions = gameData.questions;

        for (int i = 0; i < questions.Count; i++)
        {
            Question tmp = questions[i];
            int random = Random.Range(0, questions.Count);
            questions[i] = questions[random];
            questions[random] = tmp;
        }
    }


    public Question getRandomQuestion(int level)
    {
        List<Question> questions = gameData.questions;
        foreach (Question q in questions)
        {
            Debug.Log(q);
            if (q.used == false && q.questionLevel == level)
            {
                Debug.Log("getrandom: " + (q.used == false && q.questionLevel == level));
                return q;
            }
        }
        return null;
    }

    public int getCurrentLevel()
    {
        return gameData.currentLevel;
    }

    public int getScore()
    {
        return gameData.gameScore.score;
    }



//******** video manager **********

    void OnEnd()
    {
        m_bFinish = true;
    }

    public void loadVideo(string name)
    {
        videoManager.Load(name);
        play();
        m_bFinish = false;
    }

    public void nextVideo()
    {
        //videoManager.Load(gameData.videos[videoIndex++ % gameData.videos.Length]);
        m_bFinish = false;
    }

    public void play()
    {
        videoManager.Play();
        m_bFinish = false;
    }

    public void stop()
    {
        videoManager.Stop();
    }

    public void pause()
    {
        videoManager.Pause();
    }

    public void unload()
    {
        videoManager.UnLoad();
    }

    public void seekTo(int amout)
    {
        videoManager.SeekTo(amout);
    }







}
		
