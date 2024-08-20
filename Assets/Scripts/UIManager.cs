using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Quiz")]
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private AnswerButton buttonA;
    [SerializeField] private AnswerButton buttonB;
    [SerializeField] private AnswerButton buttonC;
    [SerializeField] private AnswerButton buttonD;
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private Image background;
    [SerializeField] private Color correctColor;
    [SerializeField] private Color wrongColor;
    private Color normalColor;

    [Header("Ending")]
    [SerializeField] private GameObject scoreMenu;
    [SerializeField] private TMP_Text endingScoreText;

    public void ShowQuiz(Quiz nextQuiz)
    {
        questionText.text = nextQuiz.question;
        buttonA.ChangeText(nextQuiz.answerA);
        buttonB.ChangeText(nextQuiz.answerB);
        buttonC.ChangeText(nextQuiz.answerC);
        buttonD.ChangeText(nextQuiz.answerD);
    }

    public void RightAnswer(int newScore)
    {
        currentScoreText.text = $"Punkte: {newScore}";
        background.color = correctColor;
        Invoke(nameof(ResetBackground), 1);
    }

    public void WrongAnswer()
    {
        background.color = wrongColor;
        Invoke(nameof(ResetBackground), 1);
    }

    public void ShowEnding(int score, int maxScore)
    {
        scoreMenu.SetActive(true);

        if (score == maxScore)
        {
            endingScoreText.text = $"Wow, du hast alle {maxScore} Fragen richtig beantwortet!";
        }
        else
        {
            endingScoreText.text = $"Du hast {score} von {maxScore} Fragen richtig beantwortet. Schaffst du mehr?";
        }
    }

    private void ResetBackground()
    {
        CancelInvoke(nameof(ResetBackground));
        background.color = normalColor;
    }

    private void Awake()
    {
        Instance = this;
        normalColor = background.color;
    }
}
