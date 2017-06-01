using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour {


    //const
    public int basePoints = 150;
    public int lastLevel = 10;
    [SerializeField]
    public string[] videos;
    public string[] videosMetaphore;
    public int currentLevel { get; set; }

    public Question currentQuestion { get; set; }
    public GameScore gameScore { get; set; }
    public List<Question> questions { get; set; }

    public Sprite func1;
    public Sprite func2;
    public Sprite func3;
    public Sprite func4;
    public Sprite func5;
    public Sprite func6;
    public Sprite func7;
    public Sprite func8;
    public Sprite func9;
    public Sprite func10;


    void Awake()
    {
        questions = new List<Question>();
        gameScore = new GameScore();

        Question question01 = new Question(1, func1, "Qual a função representada no gráfico apresentado?", new ArrayList(new string[] { "-1x^2", "(x-1)^2", "(x^2)-1" }), 3);
        Question question02 = new Question(1, func2, "Qual função representa o gráfico apresentado?", new ArrayList(new string[] { "(-2+x)^2", "-2x^2", "-2+x^2" }), 1);
        Question question03 = new Question(2, func3, "Qual função representa o gráfico apresentado?", new ArrayList(new string[] { "(1*x)^2 ", "0.05*x^2", "10*x^2" }), 2);
        Question question04 = new Question(2, func4, "Qual dos gráficos representa a função f(x)= x - 2?", new ArrayList(new string[] { "Verde", "Azul", "Vermelha" }), 3);
        Question question05 = new Question(3, func5, "Quanto deve somar a B de modo a que o grafico passe na origem?", new ArrayList(new string[] { "-1", "1", "1x" }), 2);
        Question question06 = new Question(3, func6, "O gráfico apresentado é representado por qual das seguintas funções?", new ArrayList(new string[] { "-0.5x² + 0.5", "(x + 0.5)² + 0.5", "(x - 0.5)² + 0.5" }), 3);
        Question question07 = new Question(4, func7, "Qual a diferença no valor de K entre as duas funções?", new ArrayList(new string[] { "0.5", "-1", "1" }), 3);
        Question question08 = new Question(4, func8, "Quanto foi somado à função azul por forma  a chegar à função em laranja.", new ArrayList(new string[] { "0.5", "-0.5", "1" }), 1);
        Question question09 = new Question(5, func9, "Qual o gráfico da função f(x)=x-1", new ArrayList(new string[] { "azul ", "laranja", "verde" }), 1);
        Question question10 = new Question(5, func10, "Qual das funções está deslocada a uma unidade da origem?", new ArrayList(new string[] { "Apenas a azul ", "Apenas a verde", "Todas" }), 3);

        questions.Add(question01);
        questions.Add(question02);
        questions.Add(question03);
        questions.Add(question04);
        questions.Add(question05);
        questions.Add(question06);
        questions.Add(question07);
        questions.Add(question08);
        questions.Add(question09);
        questions.Add(question10);

    }



}
