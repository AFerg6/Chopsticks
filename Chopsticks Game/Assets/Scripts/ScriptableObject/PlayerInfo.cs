using System;
using UnityEditor.Search;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    private int socialCredit;

    private String[] items = new string[3];
    
    public void increaseSocialCredit(int amount){
        socialCredit += amount;
    }

    public void spendSocialCredit(int price){
        socialCredit -= price;
    }

    public int getSocialCredit(){
        return socialCredit;
    }

    public Boolean checkItemsBought(String purchasedItem){
        for (int i = 0; i < items.Length; i++){
            if (items[i].Equals(purchasedItem)) return true;
        }
        return false;
    }

    public void populateArray(String purchase){
        for (int i = 0; i < items.Length; i++){
            if (items[i] == null) items[i] = purchase;
        }
    }

}
