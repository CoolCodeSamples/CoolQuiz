using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    [SerializeField] private Quiz[] quizes;
    private int nextQuestion;
    private int score;

    public void ReceiveAnswer(string selectedAnswer)
    {
        CheckSolution(selectedAnswer);

        nextQuestion++;
        bool isQuizOver = nextQuestion >= quizes.Length;

        if (isQuizOver)
        {
            Invoke(nameof(EndQuiz), 1);
        }
        else
        {
            Invoke(nameof(StartQuestion), 1);
        }
    }

    public void RestartQuiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void StartQuestion()
    {
        UIManager.Instance.ShowQuiz(quizes[nextQuestion]);
    }

    private void EndQuiz()
    {
        UIManager.Instance.ShowEnding(score, quizes.Length);
    }

    private void CheckSolution(string selectedAnswer)
    {
        string solution = quizes[nextQuestion].GetSolution();

        if (solution.Equals(selectedAnswer))
        {
            score++;
            UIManager.Instance.RightAnswer(score);
        }
        else
        {
            UIManager.Instance.WrongAnswer();
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartQuestion();
    }
}
