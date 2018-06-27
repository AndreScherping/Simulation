using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadenSwap : MonoBehaviour {

    public GameObject BankSeite;
    public GameObject FabrikSeite;
    public GameObject HolzfällerSeite;
    public GameObject LaborSeite;
    public GameObject SteinmetzSeite;

    public int seite=1;
    bool imLaden=true;

    public void Umdrehen()
    {
        seite = seite + 1;
        Debug.Log("kk");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player")&&imLaden==true)
        {
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            imLaden = true;
        }
    }

    private void Update()
    {
        if (seite == 1)
        {
            SteinmetzSeite.SetActive(false);
            BankSeite.SetActive(true);
        }
        else if (seite == 2)
        {
            BankSeite.SetActive(false);
            FabrikSeite.SetActive(true);
        }
        else if(seite == 3)
        {
            FabrikSeite.SetActive(false);
            HolzfällerSeite.SetActive(true);
        }
        else if(seite == 4)
        {
            HolzfällerSeite.SetActive(false);
            LaborSeite.SetActive(true);
        }
        else if(seite == 5)
        {
            LaborSeite.SetActive(false);
            SteinmetzSeite.SetActive(true);
            seite = 0;
        }
    }

    public void SchließeLaden()
    {
        imLaden = false;
        Time.timeScale = 1;
    }

}
