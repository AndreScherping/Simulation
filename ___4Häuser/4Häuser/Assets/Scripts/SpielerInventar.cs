using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpielerInventar : MonoBehaviour {

    public GameObject player;

    public int spielerGeld;
    public int spielerHolz;
    public int spielerStein;
    public int spielerMetal;

    public Text spielerGeldText;
    public Text spielerHolzText;
    public Text spielerSteinText;
    public Text spielerMetalText;
    public Text AktivierungsText;

    private void Start()
    {
        AktivierungsText.text = "";
    }

    private void Update()
    {
         
        spielerGeldText.text = "Geld: " + spielerGeld.ToString();
        spielerHolzText.text = "Holz: " + spielerHolz.ToString();
        spielerSteinText.text = "Stein: " + spielerStein.ToString();
        spielerMetalText.text = "Metall: " + spielerMetal.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("bank"))
        {
            AktivierungsText.text = "Drücke E um das Geld einzusammeln.";
        }
        if (other.CompareTag("holzfäller"))
        {
            AktivierungsText.text = "Drücke E um das Holz einzusammeln";
        }
        if (other.CompareTag("steinmetz"))
        {
            AktivierungsText.text = "Drücke E um den Stein einzusammeln";
        }
        if (other.CompareTag("fabrik"))
        {
            AktivierungsText.text = "Drücke E um das Metall einzusammeln";
        }
        
        if (Input.GetKeyDown("e"))
        {

            if (other.CompareTag("bank"))
            {
                spielerGeld = spielerGeld + player.GetComponent<GeldProduzieren>().Geld;
                player.GetComponent<GeldProduzieren>().Geld = 0;
            }
            if (other.CompareTag("holzfäller"))
            {
                spielerHolz = spielerHolz + player.GetComponent<GeldProduzieren>().Holz;
                player.GetComponent<GeldProduzieren>().Holz = 0;
            }
            if (other.CompareTag("steinmetz"))
            {
                spielerStein = spielerStein + player.GetComponent<GeldProduzieren>().Stein;
                player.GetComponent<GeldProduzieren>().Stein = 0;
            }
            if (other.CompareTag("fabrik"))
            {
                spielerMetal = spielerMetal + player.GetComponent<GeldProduzieren>().Metal;
                player.GetComponent<GeldProduzieren>().Metal = 0;
            }  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        AktivierungsText.text = "";
    }

}
