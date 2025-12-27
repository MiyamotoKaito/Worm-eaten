using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMesh;
    [SerializeField] private Image _canDropImage;
    private QuestionSystem _questionSystem;
    private Image _currentDropImage;

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
        _questionSystem.OnReset -= ResetQuestion;
    }

    private void ResetQuestion()
    {
        _textMesh.text = _questionSystem.Question.ToString();
        UpdateDisplayText();
    }
    private void UpdateDisplayText()
    {
        //TextMeshProの情報を更新
        _textMesh.ForceMeshUpdate();
        TMP_TextInfo info = _textMesh.textInfo;
        for (int i = 0; i < info.characterCount; i++)
        {
            if (info.characterInfo[i].character == _questionSystem.Question.CorrectChar)
            {
                // 正解の文字と合致していたら文字の場所にUIを置く
                TMP_CharacterInfo charInfo = info.characterInfo[i];

                // 文字が実際に表示されているかチェック
                if (!charInfo.isVisible) continue;

                // 文字の中心位置を計算
                Vector3 bottomLeft = charInfo.bottomLeft;
                Vector3 topRight = charInfo.topRight;
                Vector3 centerPosition = (bottomLeft + topRight) / 2f;

                // ワールド座標に変換
                Vector3 worldPosition = _textMesh.transform.TransformPoint(centerPosition);

                // UIを配置（既存のUIがあれば削除）
                if (_currentDropImage != null)
                {
                    Destroy(_currentDropImage.gameObject);
                }
                _currentDropImage = Instantiate(_canDropImage, worldPosition, Quaternion.identity);

                break; // 最初の一致で終了
            }
        }
    }
}