using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public String productName;
    public int price;
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
        if (!other.gameObject.tag.Equals("Player"))
            return;
        
        if (!playerInfo.checkItemsBought(productName)){
            if (playerInfo.getSocialCredit() > price) {
                playerInfo.spendSocialCredit(price);
                playerInfo.addItem(productName);
                equipItem(productName);
                setEquipMode();
            }
        } else equipItem(productName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Disables all the hats except the one indicated
    void equipItem(String product){
        for (int i = 0; i < player.transform.childCount; i++)
        {
            player.transform.GetChild(i).gameObject.SetActive(player.transform.GetChild(i).gameObject.name.Equals(product) || player.transform.GetChild(i).gameObject.name.Equals("Main Camera"));
        }
    }

    private void setEquipMode()
    {
        shopText.text = "Equip " + productName;
    }
}
