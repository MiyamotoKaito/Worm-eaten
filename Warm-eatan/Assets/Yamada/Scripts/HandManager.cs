using UnityEngine;

/// <summary>
///         手札の生成と見た目の配置を担当
/// </summary>
public class HandManager : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private RectTransform _handRoot;

    [Header("配置設定")]
    [SerializeField] private float _cardSpacing;
    [SerializeField] private float _cardRotateAngle;
    [SerializeField] private float _curveHeight = -20f;  // カーブの強さ

    private int _handCount = 3;

    public void ResetHand()
    {
        ClearHand();
        CreateHand();
        LayoutHand();
    }

    private void ClearHand()
    {
        foreach (Transform t in _handRoot)
            Destroy(t.gameObject);
    }

    private void CreateHand()
    {
        for (int i = 0; i < _handCount; i++)
        {
            Instantiate(_cardPrefab, _handRoot);
            // ここで文字設定すると思う
        }
    }

    private void LayoutHand()
    {
        int count = _handRoot.childCount;
        if (count == 0) return;

        float centerIndex = (count - 1) / 2f;

        for (int i = 0; i < count; i++)
        {
            RectTransform card = _handRoot.GetChild(i).GetComponent<RectTransform>();

            float offset = i - centerIndex;

            float x = offset * _cardSpacing;
            float y = Mathf.Abs(offset) * _curveHeight;
            float angle = -(offset / centerIndex) * _cardRotateAngle;

            card.anchoredPosition = new Vector2(x, y);
            card.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void Start()
    {
        ResetHand();
    }
}