using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Use this for initialization

    public GameManager gameManager;

    //views
    public GameObject mainMneuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;

    //questions
    public Text questionText;
    public Image questionImage;
    public Text awnser01;
    public Text awnser02;
    public Text awnser03;

    //Score
    public Text textScore;
    public Text textLevel;
    public Text finalPoints;


    public void playBtn()
    {
        mainMneuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameManager.startGame();
    }

    public void tutorialBtn()
    {
        gameManager.rotateScene(-90);
    }

    public void LearningAreaBtn()
    {
        gameManager.rotateScene(90);
    }

    public void hallOfFameBtn()
    {
        gameManager.rotateScene(180);
    }


    public void setQuestion(Question q)
    {
        questionText.text = q.question;
        questionImage.overrideSprite = q.image;
        awnser01.text = q.awnsers[0] as string;
        awnser02.text = q.awnsers[1] as string;
        awnser03.text = q.awnsers[2] as string;

    }

    public void OnCliked(Button button)
    {
        gameManager.awnser(button.name);
    }

    public void gameOver()
    {
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        finalPoints.text = gameManager.getScore().ToString();
        Invoke("showMainMenu", 2);
    }

    public void showNextLevelPanel(bool levelUp)
    {
        gamePanel.SetActive(false);
        nextLevelPanel.SetActive(true);

        if(levelUp)
            textLevel.text = "Congratulations!\n\nLevel\n" + gameManager.getCurrentLevel().ToString();

        textLevel.text = "Level\n" + gameManager.getCurrentLevel().ToString();
        textScore.text = gameManager.getScore().ToString();

        Invoke("showNextQuestion", 2);
    }

    public void showNextQuestion()
    {
        gamePanel.SetActive(true);
        nextLevelPanel.SetActive(false);
    }
    public void showMainMenu()
    {
        mainMneuPanel.SetActive(true);
        nextLevelPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }


}
