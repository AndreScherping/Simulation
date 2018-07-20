using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workmen : MonoBehaviour
{
    public GameObject player;
    public GameObject shop;

    private void Start()
    {
        var inv = player.GetComponent<PlayerInventory>();
        var pro = player.GetComponent<MoneyProduction>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shop.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shop.SetActive(false);
        }
    }

}
