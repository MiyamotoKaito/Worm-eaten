using TMPro;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMesh;
    private QuestionSystem _questionSystem;

    private void Awake()
    {
        _questionSystem = GetComponent<QuestionSystem>();
        _textMesh.text = _questionSystem.Question.ToString();
    }
    private void OnEnable()
    {
       _questionSystem.OnReset += ResetQuestion;
    }
    private void OnDisable()
    {
        _questionSystem.OnReset += ResetQuestion;
    }

    private void ResetQuestion()
    {
        _textMesh.text = _questionSystem.Question.ToString();
    }
}