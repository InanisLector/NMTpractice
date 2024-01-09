using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using TMPro;

public class GameInstance : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text[] answersText;

    private List<ParsedQuestion> _parsedBasicQuestions;

    private void Start()
    {
        SerializeQuestions();
        _parsedBasicQuestions = new List<ParsedQuestion>();

        Convert();
        InitButtons();
    }

    private void InitButtons()
    {
        BasicQuestionData bqd = _parsedBasicQuestions[0].ToBasicQuestionData();
        questionText.text = bqd.Question;

        Debug.Log($"{bqd.Answers.Length}, {answersText.Length}");

        for (int i = 0; i < 4; i++)
            answersText[i].text = bqd.Answers[i];
    }

    private void Convert()
    {
        StreamReader reader = new StreamReader($@"{Application.dataPath}\Questions\Questions.json");
        using (reader)
        {
            _parsedBasicQuestions.Add(JsonConvert.DeserializeObject<ParsedQuestion>(reader.ReadToEnd()));
        }
        reader.Close();
    }

    private void SerializeQuestions()
    {
        StreamWriter writer = new StreamWriter($@"{Application.dataPath}\Questions\Questions.json");
        using (writer)
        {
            writer.Write(JsonConvert.SerializeObject(new ParsedQuestion("Першу згадку про козацтво датують:", new string[] { "1487" }, new string[] { "1567", "1632", "1435", "1387", "1467", "1569", "1556" }), Formatting.None));
        }
        writer.Close();
    }

    public void Refresh()
        => InitButtons();
}