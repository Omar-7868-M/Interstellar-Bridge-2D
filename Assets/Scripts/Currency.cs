using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public int BlackVoid;
    GameObject VoidUI;
    // Start is called before the first frame update
    void Start()
    {
        VoidUI = GameObject.Find("Currency");
        
    }

    // Update is called once per frame
    void Update()
    {
        VoidUI.GetComponent<Text>().text = BlackVoid.ToString();
        if(BlackVoid < 0)
        {
            BlackVoid = 0; //Code to display the amount of coins collected 
        }
        
    }
}
