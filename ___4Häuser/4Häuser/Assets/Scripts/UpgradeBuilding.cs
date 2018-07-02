using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : MonoBehaviour
{
    private GeldProduzieren moneyProduction;
    private GameObject player;

    public void Upgrade(int buildingNumber)
    {
        if(player == null)
            player = GameObject.FindWithTag("Player");

        if(moneyProduction == null)
            moneyProduction = player.GetComponent<GeldProduzieren>();

        if (buildingNumber == 0)
        {
            GameObject farmHouse = GameObject.FindWithTag("FarmHouse");

            if(moneyProduction.erweiterungenGeld < 6)
            {
                farmHouse.transform.GetChild(moneyProduction.erweiterungenGeld).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.erweiterungenGeld++;
                farmHouse.transform.GetChild(moneyProduction.erweiterungenGeld).GetComponent<MeshRenderer>().enabled = true;
            }

            if (moneyProduction.erweiterungenGeld >= 6)
            {
                moneyProduction.erweiterungenGeld++;
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

            if (moneyProduction.erweiterungenHolz >= 6)
            {
                moneyProduction.erweiterungenHolz++;
                farm.transform.gameObject.tag = "EditorOnly";
            }
            else
            {
                farm.transform.GetChild(moneyProduction.erweiterungenHolz).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.erweiterungenHolz++;
                farm.transform.GetChild(moneyProduction.erweiterungenHolz).GetComponent<MeshRenderer>().enabled = true;
            }
        }


        if(buildingNumber == 2)
        {
            GameObject house = GameObject.FindWithTag("House");

            if (moneyProduction.erweiterungenStein >= 6)
            {
                moneyProduction.erweiterungenStein++;
                house.transform.gameObject.tag = "EditorOnly";
            }
            else
            {
                house.transform.GetChild(moneyProduction.erweiterungenStein).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.erweiterungenStein++;
                house.transform.GetChild(moneyProduction.erweiterungenStein).GetComponent<MeshRenderer>().enabled = true;
            }
        }

        if(buildingNumber == 3)
        {
            GameObject tower = GameObject.FindWithTag("Tower");

            if (moneyProduction.erweiterungenMetal >= 6)
            {
                moneyProduction.erweiterungenMetal++;
                tower.transform.gameObject.tag = "EditorOnly";
            }
            else
            {
                tower.transform.GetChild(moneyProduction.erweiterungenMetal).GetComponent<MeshRenderer>().enabled = false;
                moneyProduction.erweiterungenMetal++;
                tower.transform.GetChild(moneyProduction.erweiterungenMetal).GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
