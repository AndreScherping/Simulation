using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : MonoBehaviour
{
    private MoneyProduction moneyProduction;
    private GameObject player;

    public void Upgrade(int buildingNumber)
    {
        if(player == null)
            player = GameObject.FindWithTag("Player");

        if(moneyProduction == null)
            moneyProduction = player.GetComponent<MoneyProduction>();

        if (buildingNumber == 0)
        {
            GameObject farmHouse = GameObject.FindWithTag("FarmHouse");

            if(moneyProduction.extensionMoney < 6)
            {
                farmHouse.transform.GetChild(moneyProduction.extensionMoney).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.extensionMoney++;
                farmHouse.transform.GetChild(moneyProduction.extensionMoney).GetComponent<MeshRenderer>().enabled = true;
            }

            if (moneyProduction.extensionMoney >= 6)
            {
                moneyProduction.extensionMoney++;
                farmHouse.transform.gameObject.tag = "EditorOnly";
            }
            //else
            //{   
            //    farmHouse.transform.GetChild(moneyProduction.erweiterungenGeld).GetComponent<MeshRenderer>().enabled = false;
            //    moneyProduction.erweiterungenGeld++;
            //    farmHouse.transform.GetChild(moneyProduction.erweiterungenGeld).GetComponent<MeshRenderer>().enabled = true;
            //}
        }

        if (buildingNumber == 1)
        {
            GameObject farm = GameObject.FindWithTag("Farm");

            if (moneyProduction.extensionWood >= 6)
            {
                moneyProduction.extensionWood++;
                farm.transform.gameObject.tag = "EditorOnly";
            }
            else
            {
                farm.transform.GetChild(moneyProduction.extensionWood).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.extensionWood++;
                farm.transform.GetChild(moneyProduction.extensionWood).GetComponent<MeshRenderer>().enabled = true;
            }
        }


        if(buildingNumber == 2)
        {
            GameObject house = GameObject.FindWithTag("House");

            if (moneyProduction.extensionStone >= 6)
            {
                moneyProduction.extensionStone++;
                house.transform.gameObject.tag = "EditorOnly";
            }
            else
            {
                house.transform.GetChild(moneyProduction.extensionStone).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.extensionStone++;
                house.transform.GetChild(moneyProduction.extensionStone).GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if(buildingNumber == 3)
        {
            GameObject tower = GameObject.FindWithTag("Tower");

            if (moneyProduction.extensionMetal >= 6)
            {
                moneyProduction.extensionMetal++;
                tower.transform.gameObject.tag = "EditorOnly";
            }
            else
            {
                tower.transform.GetChild(moneyProduction.extensionMetal).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.extensionMetal++;
                tower.transform.GetChild(moneyProduction.extensionMetal).GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
