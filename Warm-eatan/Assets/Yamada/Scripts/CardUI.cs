using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class CardUI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform _rect;
    private Canvas _canvas;
    private Transform _originalParent;
    private Vector2 _originalPosition;

    /// <summary>
    ///         親オブジェクトに設定する
    /// </summary>
    /// <param name="parent">設定する親オブジェクト</param>
    public void PlaceToParent(Transform parent)
    {
        transform.SetParent(parent);
        _rect.anchoredPosition = Vector2.zero;
    }

    /// <summary>
    ///         元のポジションに移動する
    /// </summary>
    public void ReturnToOriginalPos()
    {
        transform.SetParent(_originalParent);
        _rect.anchoredPosition = _originalPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rect.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Save();
    }

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
    }

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
    }
}
