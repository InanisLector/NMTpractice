using System;

[Serializable]
public struct ParsedQuestion
{
    public string Question;
    public string[] CorrectAnswers; // min 1
    public string[] IncorrectAnswers; // min 3

    public ParsedQuestion(string Question, string[] CorrectAnswers, string[] IncorrectAnswers)
    {
        this.Question = Question;
        this.CorrectAnswers = CorrectAnswers;
        this.IncorrectAnswers = IncorrectAnswers;
    }

    public BasicQuestionData ToBasicQuestionData()
    {
        string[] answers = new string[4];

        int correctIndex = UnityEngine.Random.Range(0, 4);

        (int, int) excludedIncorrectAnswers = (-1, -1);

        for (int i = 0; i < 4; i++)
        {
            if (i == correctIndex)
            {
                answers[i] = CorrectAnswers[UnityEngine.Random.Range(0, CorrectAnswers.Length)];
                continue;
            }

            int incorrectAnswerIndex;

            do
                incorrectAnswerIndex = UnityEngine.Random.Range(0, IncorrectAnswers.Length);
            while(incorrectAnswerIndex == excludedIncorrectAnswers.Item1 || incorrectAnswerIndex == excludedIncorrectAnswers.Item2);

            answers[i] = IncorrectAnswers[incorrectAnswerIndex];

            if (excludedIncorrectAnswers.Item1 == -1)
                excludedIncorrectAnswers.Item1 = incorrectAnswerIndex;
            else
                excludedIncorrectAnswers.Item2 = incorrectAnswerIndex;

        }

        return new BasicQuestionData(Question, answers, correctIndex);
    }
    
}