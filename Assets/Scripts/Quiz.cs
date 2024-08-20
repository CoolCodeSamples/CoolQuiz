using UnityEngine;

[System.Serializable]
public class Quiz
{
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    [SerializeField] private char solutionLetter;

    public string GetSolution()
    {
        char solutionLower = char.ToLower(solutionLetter);

        if (solutionLower == 'a') return answerA;
        if (solutionLower == 'b') return answerB;
        if (solutionLower == 'c') return answerC;
        if (solutionLower == 'd') return answerD;
        else return "Error!";
    }
}
