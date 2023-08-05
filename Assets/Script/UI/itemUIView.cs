using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemUIView : MonoBehaviour
{
    [SerializeField] private Image Img;
    [SerializeField] private TextMeshProUGUI Number;

    public void Init(GameItem gameItem)
    {
        Img.gameObject.SetActive(true);
        Number.gameObject.SetActive(true);
        Img.sprite = DataManger.Instance.GetItemSprite(gameItem.Id);
        Number.text = gameItem.Number.ToString();
    }
    public void Hide()
    {
        Img.gameObject.SetActive(false);
        Number.gameObject.SetActive(false);
    }
}
