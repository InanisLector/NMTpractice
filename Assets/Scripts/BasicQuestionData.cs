using System;

[Serializable]
public struct BasicQuestionData
{
    public readonly string Question;
    public readonly string[] Answers;
    public readonly int CorrectAnswerIndex;

    public BasicQuestionData(string Question, string[] Answers, int CorrectAnswerIndex)
    {
        this.Question = Question;
        this.Answers = Answers;
        this.CorrectAnswerIndex = CorrectAnswerIndex;
    }
}
