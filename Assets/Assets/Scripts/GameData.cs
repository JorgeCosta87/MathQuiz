using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour {


    //const
    public int basePoints = 150;
    public int lastLevel = 10;
    [SerializeField]
   // public string[] videos;
    public int currentLevel { get; set; }
    public int numberOfRightQuestions { get; set; }
    public Question currentQuestion { get; set; }
    public GameScore gameScore { get; set; }
    public List<Question> questions { get; set; }


    //Images
    public Sprite quadratic;
    public Sprite sinFunction;
    public Sprite cosFunction;
    public Sprite cosTransY;
    public Sprite cosTransAmp;


    void Awake()
    {
        questions = new List<Question>();
        gameScore = new GameScore();

        Question question01 = new Question(1, quadratic, "What is the function of this graph?", new ArrayList(new string[] { "x^2", "x^3", "-x^2" }), 1);
        Question question02 = new Question(1, sinFunction, "What is the trignometric funciont presented?", new ArrayList(new string[] { "cos(x)", "sin(x)", "tg(x)" }), 2);
        Question question03 = new Question(1, cosFunction, "What is the trignometric funciont presented?", new ArrayList(new string[] { "sec(x)", "sin(x)", "cos(x)" }), 3);
        Question question04 = new Question(2, cosTransY, "What is the transformation applied to the cos(x)?", new ArrayList(new string[] { "cos(x) + 2", "2 * cos(x)", "cos(x + 2)" }), 1);
        Question question05 = new Question(2, cosTransAmp, "What is the transformation applied to the cos(x)?", new ArrayList(new string[] { "3 * cos(x)", "4 * cos(x)  - 1", "cos(3pi * x)" }), 1);
        questions.Add(question01);
        questions.Add(question02);
        questions.Add(question03);
        questions.Add(question04);
        questions.Add(question05);

    }



}
