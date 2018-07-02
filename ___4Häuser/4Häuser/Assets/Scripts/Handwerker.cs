using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handwerker : MonoBehaviour
{
    public GameObject player;
    public GameObject laden;

    private void Start()
    {
        var inv = player.GetComponent<SpielerInventar>();
        var pro = player.GetComponent<GeldProduzieren>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            laden.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            laden.SetActive(false);
        }
    }

}
