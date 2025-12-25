using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///         問題の虫食いスロット
///         移動制御、後で必要
/// </summary>
public class AnswerDropArea : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform _slotRoot;

    private CardUI _currentCard;

    /// <summary>
    ///         虫食いドロップ時の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        CardUI newCard = eventData.pointerDrag?.GetComponent<CardUI>();
        if (newCard == null) return;

        if(_currentCard != null)
        {
            _currentCard.ReturnToOriginalPos();
        }

        // 現在のカードに新しいものを挿入
        _currentCard = newCard;
        newCard.PlaceToParent(_slotRoot);
    }
}
