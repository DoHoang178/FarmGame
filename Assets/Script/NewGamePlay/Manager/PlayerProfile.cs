
using System;
using System.Collections.Generic;

public class SaveGame
{
    public string Name { get; set; }
    public long Coin { get; set; }
    public List<GameItem> GameItems { get; set; }
}
public class PlayerProfile : ISingleton<PlayerProfile>
{
    public SaveGame SaveGame { get; private set; }

    public static Action ON_COIN_CHANGE { get; set; }

    public PlayerProfile()
    {
        SaveGame = new SaveGame()
        {
            Name = "PlayerName",
            Coin = 10000,
            GameItems = new List<GameItem>()
            {
                new GameItem() { Id = GameItemId.ITEM_01,Number=10, Name = "item1" },


            }
        };
    }
    public string GetPlayerName()
    {
        return SaveGame.Name;
    }
    public long GetCurrentCoin()
    {
        return SaveGame.Coin;
    }
    public void IncreaseCoin(long number)
    {
        SaveGame.Coin += number;
        ON_COIN_CHANGE?.Invoke();
    }
    public bool DecreaseCoin(long number)
    {
        if (SaveGame.Coin > number)
        {
            SaveGame.Coin -= number;
            ON_COIN_CHANGE?.Invoke();

            return true;
        }
        else
        {
            return false;
        }

    }
    public void AddGameItem(GameItemId itemId, int number = 1)
    {
        GameItem item = SaveGame.GameItems.Find(x => x.Id == itemId);
        if (item != null)
        {
            item.Number += number;
        }
        else { SaveGame.GameItems.Add(new GameItem() { Id = itemId, Number = number }); }

    }
    public bool UseGameItem(GameItemId itemId)
    {
        GameItem item = SaveGame.GameItems.Find(x => x.Id == itemId);
        if (item != null)
        {
            item.Number--;
            if (item.Number < 0)
            {
                SaveGame.GameItems.Remove(item);
            }

            return true;
        }
        else
        {
            return false;
        }
    }
}