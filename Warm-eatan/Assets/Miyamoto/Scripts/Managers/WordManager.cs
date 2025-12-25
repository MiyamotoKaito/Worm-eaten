using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [System.Serializable]
    public class WordData
    {
        public string QuestionWord;
        public string CorrectChar;
        public List<string> WrongChars;

        public WordData(string question, string correct, List<string> wrong)
        {
            QuestionWord = question;
            CorrectChar = correct;
            WrongChars = wrong;
        }
    }
    [SerializeField] private TextAsset _textFile;
    [SerializeField] private List<WordData> _words = new List<WordData>();

    private void Awake()
    {
        LoadWords();
    }
    /// <summary>
    /// 参照しているテキストアセットからデータを読み込んでリストに格納する
    /// </summary>
    private void LoadWords()
    {
        if (_textFile == null)
        {
            Debug.LogError("テキストファイルが見つかりませんでした");
            return;
        }
        //改行で切り取る
        var lines = _textFile.text.Split("\n");
        //最初の行はスキップするためのフラグ
        bool isFirstLine = false;
        foreach (var line in lines)
        {
            //カンマ区切りで受け取る
            var parts = line.Split(",");
            //最初の行だったらスキップ
            if (!isFirstLine)
            {
                isFirstLine = true;
                continue;
            }
            //不正解の文字を一時的に補完するリスト
            var wrongArray = new List<string>();
            for (int i = 2; i < parts.Length; i++)
            {
                wrongArray.Add(parts[i]);
            }
            //コンストラクタで問題、正解、不正解を作成
            var word = new WordData(parts[0], parts[1], wrongArray);
            //_wordsに格納
            _words.Add(word);
        }
    }
}