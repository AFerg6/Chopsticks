using System;
using UnityEditor.Search;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    private int level = 0;

    [NonSerialized]
    private int socialCredit;

    [NonSerialized]
    public String[] itemsPurchased = new string[0];
    
    public void increaseSocialCredit(int amount){
        socialCredit += amount;
    }

    public void spendSocialCredit(int price){
        socialCredit -= price;
    }

    public int getSocialCredit(){
        return socialCredit;
    }

    public void increaseLevel()
    {
        level++;
    }

    public int getLevel()
    {
        return level;
    }

    public Boolean checkItemsBought(String purchasedItem){
        for (int i = 0; i < itemsPurchased.Length; i++){
            if (itemsPurchased[i].Equals(purchasedItem)) return true;
        }
        return false;
    }

    public void addItem(String purchase){
        if (!checkItemsBought(purchase))
        {
            if (itemsPurchased.Length == 0)
            {
                itemsPurchased = new string[1];
                itemsPurchased[0] = purchase;
            }
            else
            {
                string[] temp = new string[itemsPurchased.Length];
                for (int i = 0; i < itemsPurchased.Length; i++)
                    temp[i] = itemsPurchased[i];
                itemsPurchased = new string[temp.Length + 1];
                for (int i = 0; i < temp.Length; i++)
                    itemsPurchased[i] = temp[i];
                itemsPurchased[itemsPurchased.Length - 1] = purchase;
            }
        }
    }
}
