using UnityEngine;

public class DataManger : ISingleton<DataManger>
{
    private readonly ItemScriptable itemScriptable;
    public DataManger()
    {
        itemScriptable = Resources.Load<ItemScriptable>("ItemScriptable");
    }

    public Sprite GetItemSprite(GameItemId id)
    {
        ItemUI rs = itemScriptable.ListItemUI.Find(x => x.gameItemId == id);
        if (rs == null)
        {
            rs = itemScriptable.ListItemUI[0];
        }
        return rs.Image;
    }
    public GameObject GetItemPrefab(GameItemId id)
    {
        ItemUI rs = itemScriptable.ListItemUI.Find(x => x.gameItemId == id);
        if (rs == null)
        {
            rs = itemScriptable.ListItemUI[0];
        }
        return rs.PrefabPlant;
    }
}
