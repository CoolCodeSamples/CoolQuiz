using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private TMP_Text answerText;

    public void SelectAnswer()
    {
        QuizManager.Instance.ReceiveAnswer(answerText.text);
    }

    public void ChangeText(string answer)
    {
        answerText.text = answer;
    }
}
