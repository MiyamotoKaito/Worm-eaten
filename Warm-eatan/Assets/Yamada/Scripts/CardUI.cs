using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///         カード1つに対する制御クラス
/// </summary>
public sealed class CardUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform _rect;
    private Canvas _canvas;
    private Transform _originalParent;
    private Vector2 _originalPosition;
    private Quaternion _originalRotation;

    /// <summary>
    ///         親オブジェクトに設定する
    /// </summary>
    /// <param name="parent">設定する親オブジェクト</param>
    public void PlaceToParent(Transform parent)
    {
        transform.SetParent(parent);
        _rect.anchoredPosition = Vector2.zero;
        // 設置されたときには角度なしの回転で実行
        _rect.localRotation = Quaternion.identity;
    }

    /// <summary>
    ///         元のポジションに移動する
    /// </summary>
    public void ReturnToOriginalPos()
    {
        transform.SetParent(_originalParent);
        _rect.anchoredPosition = _originalPosition;
        _rect.localRotation = _originalRotation;
    }

    /// <summary>
    ///         マウスドラッグ時
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    /// <summary>
    ///         マウスクリック時
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Save();
        _rect.localRotation = Quaternion.identity;
    }

    /// <summary>
    ///         マウスクリックから離した時
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData)
    {
        // Areaの方にドロップしていないなら元の場所に戻す
        if(transform.parent == _originalParent)
            ReturnToOriginalPos();
    }

    /// <summary>
    ///         親オブジェクトと元のポジションを記録する
    /// </summary>
    private void Save()
    {
        _originalParent = transform.parent;
        _originalPosition = _rect.anchoredPosition;
        _originalRotation = _rect.localRotation;
    }

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
    }
}
