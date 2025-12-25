using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [System.Serializable]
    public class WordData
    {
        public string QuestionWord;
        public string CorrectChar;
        public List<string> WrongChars;
    }
}