using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeldProduzieren : MonoBehaviour {

    public Text GeldText;
    public Text HolzText;
    public Text SteinText;
    public Text MetalText;
    public Text ÖlText;

    public int Geld;
    public int Holz;
    public int Stein;
    public int Metal;
    public int Öl;
    public int zusatzGeld;
    public int zusatzHolz;
    public int zusatzStein;
    public int zusatzMetal;
    public int zusatzÖl;
    public int erweiterungenGeld=1;
    public int erweiterungenHolz = 0;
    public int erweiterungenStein = 0;
    public int erweiterungenMetal = 0;
    public int erweiterungenÖl = 0;

    public Text verbesserungsText;

    private void Start()
    {

        StartCoroutine(Drucken());
        StartCoroutine(Fällen());
        StartCoroutine(Abbauen());
        StartCoroutine(Schmieden());
        StartCoroutine(Bohren());

    }

    private void Update()
    {
        GeldText.text = Geld.ToString();
        HolzText.text = Holz.ToString();
        SteinText.text = Stein.ToString();
        MetalText.text = Metal.ToString();
        ÖlText.text = Öl.ToString();
    }

    public void Zusätze(int stoff)
    {
        if (stoff == 0)
            zusatzGeld++;
        else if (stoff == 1)
            zusatzHolz++;
        else if (stoff == 2)
            zusatzStein++;
        else if (stoff == 3)
            zusatzMetal++;
        else if (stoff == 4)
            zusatzÖl++;
    }

    public void Erweiterungen(int stoff)
    {
        if (stoff == 0)
            erweiterungenGeld++;
        else if (stoff == 1)
            erweiterungenHolz++;
        else if (stoff == 2)
            erweiterungenStein++;
        else if (stoff == 3)
            erweiterungenMetal++;
        else if (stoff == 4)
            erweiterungenÖl++;
    }

    IEnumerator Drucken()
    {
        Geld = Geld + zusatzGeld*erweiterungenGeld;
        yield return new WaitForSeconds(1);
        StartCoroutine(Drucken());
    }
    IEnumerator Fällen()
    {
        Holz = Holz + zusatzHolz * erweiterungenHolz;
        yield return new WaitForSeconds(1);
        StartCoroutine(Fällen());
    }
    IEnumerator Abbauen()
    {
        Stein = Stein + zusatzStein * erweiterungenStein;
        yield return new WaitForSeconds(1);
        StartCoroutine(Abbauen());
    }
    IEnumerator Schmieden()
    {
        Metal = Metal + zusatzMetal * erweiterungenMetal;
        yield return new WaitForSeconds(1);
        StartCoroutine(Schmieden());
    }
    IEnumerator Bohren()
    {
        Öl = Öl + zusatzÖl * erweiterungenÖl;
        yield return new WaitForSeconds(1);
        StartCoroutine(Bohren());
    }
}
