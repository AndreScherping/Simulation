using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public GameObject player;

    public int playerMoney;
    public int playerWood;
    public int playerStone;
    public int playerMetal;

    public Text playerMoneyText;
    public Text playerWoodText;
    public Text playerStoneText;
    public Text playerMetalText;
    public Text activationText;

    private void Start()
    {
        activationText.text = "";
    }

    private void Update()
    {
         
        playerMoneyText.text = "Geld: " + playerMoney.ToString();
        playerWoodText.text = "Holz: " + playerWood.ToString();
        playerStoneText.text = "Stein: " + playerStone.ToString();
        playerMetalText.text = "Metall: " + playerMetal.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("bank"))
        {
            activationText.text = "Drücke E um das Geld einzusammeln.";
        }
        if (other.CompareTag("holzfäller"))
        {
            activationText.text = "Drücke E um das Holz einzusammeln";
        }
        if (other.CompareTag("steinmetz"))
        {
            activationText.text = "Drücke E um den Stein einzusammeln";
        }
        if (other.CompareTag("fabrik"))
        {
            activationText.text = "Drücke E um das Metall einzusammeln";
        }
        
        if (Input.GetKeyDown("e"))
        {

            if (other.CompareTag("bank"))
            {
                playerMoney = playerMoney + player.GetComponent<MoneyProduction>().Money;
                player.GetComponent<MoneyProduction>().Money = 0;
            }
            if (other.CompareTag("holzfäller"))
            {
                playerWood = playerWood + player.GetComponent<MoneyProduction>().Wood;
                player.GetComponent<MoneyProduction>().Wood = 0;
            }
            if (other.CompareTag("steinmetz"))
            {
                playerStone = playerStone + player.GetComponent<MoneyProduction>().Stone;
                player.GetComponent<MoneyProduction>().Stone = 0;
            }
            if (other.CompareTag("fabrik"))
            {
                playerMetal = playerMetal + player.GetComponent<MoneyProduction>().Metal;
                player.GetComponent<MoneyProduction>().Metal = 0;
            }  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        activationText.text = "";
    }

}
