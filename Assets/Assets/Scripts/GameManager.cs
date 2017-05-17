using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {


    public GameObject player;
    public UIManager uiManager;
    public GameData gameData;

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void rotateScene(float degrees)
    {
        player.transform.Rotate(new Vector3(0, degrees, 0));
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
}
