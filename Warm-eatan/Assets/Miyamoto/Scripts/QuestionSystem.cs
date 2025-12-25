using UnityEngine;

public class QuestionSystem : MonoBehaviour
{
    public WordData Question => _question;

    private WordData _question;
    private WordManager _wordManager;
    private void Awake()
    {
        _wordManager = FindAnyObjectByType<WordManager>();
    }
    private void Start()
    {
        _question = _wordManager.SetQuestion();
    }
    /// <summary>
    /// 次の問題を作成
    /// </summary>
    public void NextQuestion()
    {
        var nextQuestion = _wordManager.SetQuestion();
        //現在の問題と被っていたら再起呼び出し
        if (_question == nextQuestion)
        {
            NextQuestion();
        }
        else
            _question = nextQuestion;
    }
}