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
}