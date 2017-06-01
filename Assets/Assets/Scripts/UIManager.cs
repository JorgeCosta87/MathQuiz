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
    public GameObject gameCompletePanel;
    public GameObject optionsPanel;
    public GameObject blurPanel;

    //buttons
    public Button soundBtn;

    public Image sound;
    public Sprite soundOn;
    public Sprite soundOff;

    //questions
    public Text questionText;
    public Image questionImage;
    public Text awnser01;
    public Text awnser02;
    public Text awnser03;
    public Text soundText;

    //Score
    public Text textScore;
    public Text textLevel;
    public Text finalPoints;
    public Text gameOverLevel;

    //audio
    public AudioSource genericBtn;
    public AudioSource selectAwnser;
    public AudioSource rightAwnser;
    public AudioSource wrongAwnser;
    public AudioSource gameCompleted;
    public AudioSource gameOverSound;

    public void playBtn()
    {
        genericBtn.Play();

        mainMneuPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameManager.startGame();
    }

    public void tutorialBtn()
    {
        genericBtn.Play();
        System.Threading.Thread.Sleep(100);
        gameManager.rotateScene(90);
    }

    public void LearningAreaBtn()
    {
        genericBtn.Play();
        gameManager.rotateScene(-90);
    }

    public void backButton(int degress)
    {
        genericBtn.Play();
        gameManager.backgroundSound.volume = 1;
        gameManager.stop();
        gameManager.stopMetaphore();
        gameManager.rotateScene(degress);
    }

    public void muteSound()
    {
        genericBtn.Play();
        if (!gameManager.audioListener.enabled)
        {
            sound.sprite = soundOn;
            AudioListener.pause = false;
            gameManager.audioListener.enabled = true;
            soundText.text = "Som on";
        }
        else
        {
            sound.sprite = soundOff;
            AudioListener.pause = true;
            gameManager.audioListener.enabled = false;
            soundText.text = "Som off";
        }
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
        selectAwnser.Play();
        gameManager.awnser(button.name);
    }

    public void gameOver()
    {
        gameOverSound.Play();
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
        finalPoints.text = gameManager.getScore().ToString();

        if (gameManager.getCurrentLevel() == 1)
        {
            gameOverLevel.text = "Pergunta difícil?\nTente Novamente!";
        }
        else
        {
            gameOverLevel.text = "Nada mal!\nAcertou " + (gameManager.numberOfRightQuestions) + " perguntas";
        }



        //Invoke("showMainMenu", 10);
    }

    public void showNextLevelPanel(bool levelUp)
    {
        rightAwnser.Play();
        gamePanel.SetActive(false);
        nextLevelPanel.SetActive(true);

        if (gameManager.numberOfRightQuestions == (gameManager.finalLevel * gameManager.questionsPerLevel) - 1)
        {
            textLevel.text = "Esta era díficil!\n\nÚltima pergunta\nBoa sorte! ";
        }
        else if (levelUp)
        {
            switch(gameManager.getCurrentLevel())
            {
                case 1 : textLevel.text = "Parabéns\n\nNível " + gameManager.getCurrentLevel().ToString() + "\nDummy"; break;
                case 2 : textLevel.text = "Parabéns\n\nNível " + gameManager.getCurrentLevel().ToString() + "\nAprendiz"; break;
                case 3 : textLevel.text = "Parabéns\n\nNível " + gameManager.getCurrentLevel().ToString() + "\nMestre"; break;
                case 4 : textLevel.text = "Parabéns\n\nNível " + gameManager.getCurrentLevel().ToString() + "\nProfessor"; break;
                case 5 : textLevel.text = "Parabéns\n\nNível " + gameManager.getCurrentLevel().ToString() + "\nMajor"; break;

                default:
                    textLevel.text = "Parabéns\n\nNível " + gameManager.getCurrentLevel().ToString() + "\nProfessor"; break;
            }
        }
        else
        {
            textLevel.text = "Bom trabalho!";
        }



        textScore.text = gameManager.getScore().ToString();

        Invoke("showNextQuestion", 3);
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
        gameCompletePanel.SetActive(false);
    }

    public void backMainMenu()
    {
        genericBtn.Play();
        mainMneuPanel.SetActive(true);
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameCompletePanel.SetActive(false);
        blurPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void showGameCompleted()
    {
        gameCompleted.Play();
        gamePanel.SetActive(false);
        gameCompletePanel.SetActive(true);


        Invoke("showMainMenu", 6);
        //not the best solution!
        Invoke("StopGameOverSound", 6);
    }

    public void StopGameOverSound()
    {
        gameCompleted.Stop();
    }

    public void quitGame()
    {
        genericBtn.Play();
        Application.Quit();
    }

    public void optionsBtn()
    {
        genericBtn.Play();
        blurPanel.SetActive(true);
        optionsPanel.SetActive(true);

    }

    public void showVideoGameOver()
    {

        switch (gameManager.getCurrentLevel())
        {
            case 1: gameManager.loadVideoMetaphore("videoMetafora_1.mp4");  break;
            case 2: gameManager.loadVideoMetaphore("videoMetafora_2.mp4");  break;
            case 3: gameManager.loadVideoMetaphore("videoMetafora_3.mp4");  break;
            case 4: gameManager.loadVideoMetaphore("videoMetafora_4.mp4");  break;

            default:
                gameManager.loadVideoMetaphore("videoMetafora_4.mp4"); gameManager.playMetaphore(); break;
        }

        gameManager.rotateScene(-90);
        mainMneuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

}
