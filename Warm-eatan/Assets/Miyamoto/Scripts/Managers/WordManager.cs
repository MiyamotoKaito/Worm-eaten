using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [System.Serializable]
    public class WordData
    {
        public string QuestionWord;
        public List<string> CorrectChar;
        public List<string> WrongChars;
    }

    [SerializeField] private List<WordData> _words = new List<WordData>();
    [SerializeField] private TextAsset _textFile;
}