using System.Collections.Generic;
using UnityEngine;

public class MenuItems : MonoBehaviour
{
    [SerializeField] private List<itemUIView> listImage;

    public void ShowGameItem()
    {
        foreach (itemUIView item in listImage)
        {
            item.Hide();
        }

        int i = 0;
        foreach (var item in PlayerProfile.Instance.SaveGame.GameItems)
        {
            listImage[i].Init(item);
            i++;
        }
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
