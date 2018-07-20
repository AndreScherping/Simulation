using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSwap : MonoBehaviour {

    public GameObject BankSide;
    public GameObject FactorySide;
    public GameObject WoodmenSide;
    public GameObject LaboratorySide;
    public GameObject StonemenSide
        ;

    public int side=1;
    bool inStore=true;

    public void Turnaround()
    {
        side = side + 1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player") && inStore == true)
        {
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            inStore = true;
        }
    }

    private void Update()
    {
        if (side == 1)
        {
            StonemenSide.SetActive(false);
            BankSide.SetActive(true);
        }
        else if (side == 2)
        {
            BankSide.SetActive(false);
            FactorySide.SetActive(true);
        }
        else if(side == 3)
        {
            FactorySide.SetActive(false);
            WoodmenSide.SetActive(true);
        }
        else if(side == 4)
        {
            WoodmenSide.SetActive(false);
            LaboratorySide.SetActive(true);
        }
        else if(side == 5)
        {
            LaboratorySide.SetActive(false);
            StonemenSide.SetActive(true);
            side = 0;
        }
    }

    public void SchließeLaden()
    {
        inStore = false;
        Time.timeScale = 1;
    }

}
