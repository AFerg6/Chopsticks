using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public String productName;
    public int price;
    public GameObject cosmetic;
    private GameObject player;
    private TMP_Text shopText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shopText = gameObject.GetComponentInChildren<TMP_Text>();

        shopText.text = "Purchase " + productName + "\nfor " + price + " credit";
        
        if (playerInfo.checkItemsBought(productName)) setEquipMode();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!playerInfo.checkItemsBought(productName)){
                if (playerInfo.getSocialCredit() >= price) {
                    playerInfo.spendSocialCredit(price);
                    playerInfo.addItem(productName);
                    equipItem(productName);
                    setEquipMode();
                }
            } else equipItem(productName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Destorys the current cosmetic and places the new one
    void equipItem(String product){
        if (player.transform.GetChild(0).childCount > 0)
        {
            Destroy(player.transform.GetChild(0).GetChild(0).gameObject);
        }

        playerInfo.SetHat(cosmetic);
        Instantiate(cosmetic, player.transform.GetChild(0));
    }

    private void setEquipMode()
    {
        shopText.text = "Equip " + productName;
    }
}
