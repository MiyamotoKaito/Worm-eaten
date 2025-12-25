using UnityEngine;
using UnityEngine.EventSystems;

public class AnswerDropArea : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform _slotRoot;

    private CardUI _currentCard;

    public void OnDrop(PointerEventData eventData)
    {
        CardUI newCard = eventData.pointerDrag?.GetComponent<CardUI>();
        if (newCard == null) return;

        if(_currentCard != null)
        {
            _currentCard.ReturnToOriginalPos();
        }

        _currentCard = newCard;
        newCard.PlaceToParent(_slotRoot);
    }
}
