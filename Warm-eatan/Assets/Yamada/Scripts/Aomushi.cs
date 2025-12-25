using UnityEngine;

/// <summary>
///         シャッフル用の虫
/// </summary>
public class Aomushi : MonoBehaviour
{
    [SerializeField] private HandManager _handManager;

    /// <summary>
    ///         虫をクリックした
    /// </summary>
    public void OnTouch()
    {
        // 問題にセットされているのをリセットする必要あり

        _handManager.ShuffleHand();
        Debug.Log("青虫をクリック! : シャッフル");
    }
}
