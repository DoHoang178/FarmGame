using System;

public enum GameItemId
{
    NONE,
    ITEM_01,
    ITEM_02,
    ITEM_03,
    ITEM_04,
    ITEM_05,
    ITEM_06,
}

[Serializable]
public class GameItem
{
    public GameItemId Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}