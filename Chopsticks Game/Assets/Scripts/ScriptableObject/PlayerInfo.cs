using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    private int socialCredit;

    public void increaseSocialCredit(int amount){
        socialCredit += amount;
    }

    public void spendSocialCredit(int price){
        socialCredit -= price;
    }

    public int getSocialCredit(){
        return socialCredit;
    }

}
