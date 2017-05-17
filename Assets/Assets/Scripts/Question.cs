using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour {

    public bool used { get; set; }
    public int questionLevel { get; set; }
    public Sprite image { get; set; }
    public string question { get; set; }
    public ArrayList awnsers { get; set; }
    public int correctAwnser { get; set; }

    public Question(int questionsLevel, Sprite image, string question, ArrayList awnsers, int correctAwnser)
    {
        this.questionLevel = questionsLevel;
        this.image = image;
        this.question = question;
        this.awnsers = awnsers;
        this.correctAwnser = correctAwnser;

        used = false;
    }

}
