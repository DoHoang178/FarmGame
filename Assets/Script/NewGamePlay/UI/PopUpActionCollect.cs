using UnityEngine;
using UnityEngine.UI;

public class PopUpActionCollect : MonoBehaviour
{
    [SerializeField] private Image image;
    private Collectable gameItem;

    private GamePlayController gamePlayController;
    public void Init(GamePlayController controller, Collectable item)
    {
        gamePlayController = controller;
        gameItem = item;
        image.sprite = DataManger.Instance.GetItemSprite(item.gameItemId);
    }
    public void Collect()
    {
        PlayerProfile.Instance.AddGameItem(gameItem.gameItemId);
        gameItem.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
