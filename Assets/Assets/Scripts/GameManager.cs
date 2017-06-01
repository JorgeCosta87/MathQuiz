using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {


    public int finalLevel = 4;
    public int questionsPerLevel = 2;

    public bool m_bFinishLearning = false;
    public bool m_bFinishMetaphore = false;
    private int videoIndexLearning;
    private int videoIndexMetaphore;

    public int numberOfRightQuestions;

    public GameObject player;
    public UIManager uiManager;
    public MediaPlayerCtrl videoManagerLearning;
    public MediaPlayerCtrl videoManagerMetaphore;
    public GameData gameData;
    public AudioSource backgroundSound;


    void Start () {

        numberOfRightQuestions = 0;
        videoIndexLearning = 0;
        videoIndexMetaphore = 0;
        videoManagerLearning.OnEnd += OnEnd;
        videoManagerMetaphore.OnEnd += OnEndMetaphore;

    }

	void Update () {

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
        numberOfRightQuestions = 0;
        gameData.currentLevel = 1;
        gameData.gameScore.score = 0;
        shuffleQuestions();
        Question startQuestion = getRandomQuestion(gameData.currentLevel);
        gameData.currentQuestion = startQuestion;
        uiManager.setQuestion(startQuestion);
    }

    public void nextQuestion()
    {

        if(gameData.currentLevel == finalLevel - 1)
        {
            uiManager.showGameCompleted();
            return;
        }

        numberOfRightQuestions++;
        gameData.gameScore.score += gameData.currentLevel * gameData.basePoints;

        if ((numberOfRightQuestions % questionsPerLevel) == 0)
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



//******** video manager learning area **********

    void OnEnd()
    {
        m_bFinishLearning = true;
    }

    public void loadVideo(string name)
    {
        stopMetaphore();
        videoManagerLearning.Load(name);
        Invoke("play", 0.5f);
    }

    public void nextVideo()
    {
        m_bFinishLearning = true;
        uiManager.genericBtn.Play();
        videoManagerLearning.Load(gameData.videos[videoIndexLearning++ % gameData.videos.Length]);

    }

    public void play()
    {
        backgroundSound.mute = true;
        stopMetaphore();
        videoManagerLearning.Play();
        m_bFinishLearning = false;
    }

    public void stop()
    {
        backgroundSound.mute = false;
        videoManagerLearning.Stop();
        m_bFinishLearning = true;
    }

    public void pause()
    {
        backgroundSound.mute = false;
        videoManagerLearning.Pause();
    }

    public void unload()
    {
        videoManagerLearning.UnLoad();
    }

    public void seekTo(int amout)
    {
        videoManagerLearning.SeekTo(amout);
    }


    //******** video manager metaphore**********

    public void loadVideoMetaphore(string name)
    {
        stop();
        videoManagerMetaphore.Load(name);
        Invoke("playMetaphore", 0.5f);
    }

    public void nextVideoMetaphore()
    {
        m_bFinishMetaphore = true;
        videoManagerMetaphore.Load(gameData.videos[videoIndexMetaphore++ % gameData.videosMetaphore.Length]);
        playMetaphore();
    }

    public void playMetaphore()
    {
        backgroundSound.mute = true;
        stop();
        videoManagerMetaphore.Play();
        m_bFinishMetaphore = false;
    }

    public void stopMetaphore()
    {
        backgroundSound.mute = false;
        videoManagerMetaphore.Stop();
        m_bFinishMetaphore = true;
    }

    public void pauseMetaphore()
    {
        backgroundSound.mute = false;
        videoManagerMetaphore.Pause();
    }

    public void unloadMetaphore()
    {
        videoManagerMetaphore.UnLoad();
    }

    public void seekToMetaphore(int amout)
    {
        videoManagerMetaphore.SeekTo(amout);
    }

    void OnEndMetaphore()
    {
        m_bFinishMetaphore = true;
    }

}

