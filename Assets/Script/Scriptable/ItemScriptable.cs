using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemUI
{
    public GameItemId gameItemId;
    public Sprite Image;
    public GameObject PrefabPlant;
}
[CreateAssetMenu(fileName = "ItemScriptable", menuName = "ScriptableObject/ItemScriptable", order = 1)]
public class ItemScriptable : ScriptableObject
{
    public List<ItemUI> ListItemUI;
}
