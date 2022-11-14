using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.transform.tag == "Player")
        {
            PlayerManager.numberOfCoins++; //increase numberofcoins by 1 each time
            AudioManager.instance.Play("Coins");
            PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
            Destroy(gameObject);//destroy the BlackVoid currency upon collision
        }
    }
}
