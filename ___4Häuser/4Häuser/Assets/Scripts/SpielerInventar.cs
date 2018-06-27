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
    public int spielerÖl;

    public Text spielerGeldText;
    public Text spielerHolzText;
    public Text spielerSteinText;
    public Text spielerMetalText;
    public Text spielerÖlText;
    public Text AktivierungsText;

    private void Start()
    {
        AktivierungsText.text = "";
    }

    private void Update()
    {
         
        spielerGeldText.text = spielerGeld.ToString();
        spielerHolzText.text = spielerHolz.ToString();
        spielerSteinText.text = spielerStein.ToString();
        spielerMetalText.text = spielerMetal.ToString();
        spielerÖlText.text = spielerÖl.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        AktivierungsText.text = "Press E";
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
            if (other.CompareTag("labor"))
            {
                spielerÖl = spielerÖl + player.GetComponent<GeldProduzieren>().Öl;
                player.GetComponent<GeldProduzieren>().Öl = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        AktivierungsText.text = "";
    }

}
