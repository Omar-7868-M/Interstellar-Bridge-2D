using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int SelectedCharacter;
    public Character[] characters;

    public Button unlockButton;
    public  TextMeshProUGUI coinsText;

    private void Awake() {
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach(GameObject player in skins)
        player.SetActive(false);

        skins[SelectedCharacter].SetActive(true);

        foreach(Character c in characters)
        {
            if(c.price == 0)
            c.isUnlocked = true;
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false: true;
            }
        }
        UpdateUI();
        
    }

    public void ChangeNext()
    {
        skins[SelectedCharacter].SetActive(false);
        SelectedCharacter++;
        if(SelectedCharacter == skins.Length)
        SelectedCharacter = 0;

        skins[SelectedCharacter].SetActive(true);
        if(characters[SelectedCharacter].isUnlocked)
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);

        UpdateUI();
    }


    public void ChangePrevious()
    {
        skins[SelectedCharacter].SetActive(false);
        SelectedCharacter--;
        if(SelectedCharacter == -1)
        SelectedCharacter = skins.Length -1;

        skins[SelectedCharacter].SetActive(true);
        if(characters[SelectedCharacter].isUnlocked)
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinsText.text = ""+ PlayerPrefs.GetInt("NumberOfCoins", 0);
        if(characters[SelectedCharacter].isUnlocked == true)
        {
            unlockButton.gameObject.SetActive(false);
            
        }
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + characters[SelectedCharacter].price;
            if(PlayerPrefs.GetInt("NumberOfCoins", 0) < characters[SelectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
                
            }

        }
        

    }
    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = characters[SelectedCharacter].price;
        PlayerPrefs.SetInt("NumberOfCoins", coins - price);
        PlayerPrefs.SetInt(characters[SelectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
        characters[SelectedCharacter].isUnlocked = true;
        UpdateUI(); 
    }
}
