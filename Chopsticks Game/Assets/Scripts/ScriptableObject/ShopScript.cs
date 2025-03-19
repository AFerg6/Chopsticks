using System;
using JetBrains.Annotations;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    public PlayerInfo playerInfo;
    public String productName;
    public int price;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerInfo.checkItemsBought(productName)) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!playerInfo.checkItemsBought(productName)){
            if (playerInfo.getSocialCredit() > price) {
                // TODO give player the product
                playerInfo.spendSocialCredit(price);
                
            }
        }
        // equipItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void equipItem(){
        
    }
    
}
