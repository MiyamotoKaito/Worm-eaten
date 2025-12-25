using System.Collections.Generic;
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
    [SerializeField, Tooltip("カードどうしの間隔")] private float _cardSpacing;
    [SerializeField, Tooltip("最大回転角")] private float _cardRotateAngle;
    [SerializeField, Tooltip("カーブの強さ")] private float _curveHeight = -20f;

    private int _handCount = 3;
    private List<CardUI> _cards = new();

    /// <summary>
    ///         ハンドをシャッフル(リセット)する
    /// </summary>
    public void ShuffleHand()
    {
        if (_cardPrefab == null || _handRoot == null)
        {
            Debug.LogWarning("HandManager: 必要な参照が設定されていません。");
            return;
        }
        ClearHand();
        CreateHand();
        LayoutHand();
    }

    /// <summary>
    ///         ハンドのリストを削除する
    /// </summary>
    private void ClearHand()
    {
        foreach (Transform t in _handRoot)
            Destroy(t.gameObject);

        _cards.Clear();
    }

    /// <summary>
    ///         ハンドを生成する
    /// </summary>
    private void CreateHand()
    {
        for (int i = 0; i < _handCount; i++)
        {
            GameObject cardObj = Instantiate(_cardPrefab, _handRoot);
            CardUI card = cardObj.GetComponent<CardUI>();

            RectTransform rect = cardObj.GetComponent<RectTransform>();

            rect.anchoredPosition = Vector2.zero;
            rect.localRotation = Quaternion.identity;
            rect.localScale = Vector3.one;
            // ここで文字設定すると思う

            _cards.Add(card);
        }
    }

    /// <summary>
    ///         ハンドを扇形に計算して配置する
    /// </summary>
    private void LayoutHand()
    {
        // カード枚数数える
        int count = _cards.Count;
        if (count == 0) return;

        // 中央の基準値を決める
        // 例:3枚きたらindexの1を返す
        float centerIndex = (count - 1) / 2f;

        // 左から右へカード処理
        for (int i = 0; i < count; i++)
        {
            RectTransform card = _cards[i].GetComponent<RectTransform>();

            // 中央からのずれをとる
            float offset = i - centerIndex;

            // 扇形になるように位置計算
            float x = offset * _cardSpacing;

            // _curveHeightがマイナスだと外に行くほど位置が下がる
            float y = Mathf.Abs(offset) * _curveHeight;

            // offset / centerIndexで-1から1に正規化して最大回転角を掛ける
            // カードが1枚の場合はゼロ除算を避けるため角度を0にする
            float angle = (centerIndex != 0) ? -(offset / centerIndex) * _cardRotateAngle : 0f;

            //反映
            card.anchoredPosition = new Vector2(x, y);
            card.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void Start()
    {
        if (_cardPrefab == null)
        {
            Debug.LogError("HandManager: _cardPrefab が設定されていません。");
            return;
        }
        if (_handRoot == null)
        {
            Debug.LogError("HandManager: _handRoot が設定されていません。");
            return;
        }
        ShuffleHand();
    }
}