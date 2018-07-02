using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kaufen : MonoBehaviour {

    public GameObject player;

    int inventar;
    int multiplikator;
    int bauKosten;
    int typ;

    int stufeGeldKosten;
    int stufeHolzKosten;
    int stufeSteinKosten;
    int stufeMetalKosten;

    int arbeiterGeldKosten;
    int arbeiterHolzKosten;
    int arbeiterSteinKosten;
    int arbeiterMetalKosten;

    int stufeGeld;
    int stufeHolz;
    int stufeStein;
    int stufeMetal;

    int arbeiterGeld;
    int arbeiterHolz;
    int arbeiterStein;
    int arbeiterMetal;

    public Text KostenTextGeld;
    public Text KostenTextHolz;
    public Text KostenTextStein;
    public Text KostenTextMetal;

    public Text KostenTextGeldArbeiter;
    public Text KostenTextHolzArbeiter;
    public Text KostenTextSteinArbeiter;
    public Text KostenTextMetalArbeiter;

    public void UpgradeKostenAnzeige(int stoff)
    {
        
        if (stoff == 0)
        {
            
            KostenTextGeld.text = "Geld: " + stufeGeldKosten.ToString();
        }
        else if (stoff == 1)
        {
           
            KostenTextHolz.text = "Holz: " + stufeHolzKosten.ToString();
        }
        else if (stoff == 2)
        {
            
            KostenTextStein.text = "Stein: " + stufeSteinKosten.ToString();
        }
        else if (stoff == 3)
        {
           
            KostenTextMetal.text = "Metal: " + stufeMetalKosten.ToString();
        }
    }

    public void ArbeiterKostenAnzeige(int stoff)
    {
        
        if (stoff == 0)
        {
            
            KostenTextGeldArbeiter.text = "Geld: " + arbeiterGeldKosten.ToString();
        }
        else if (stoff == 1)
        {
            
            KostenTextHolzArbeiter.text = "Holz: " + arbeiterHolzKosten.ToString();
        }
        else if (stoff == 2)
        {
            
            KostenTextSteinArbeiter.text = "Stein: " + arbeiterSteinKosten.ToString();
        }
        else if (stoff == 3)
        {
            
            KostenTextMetalArbeiter.text = "Metal: " + arbeiterMetalKosten.ToString();
        }
    }

    public void Abziehen(int stoff,int kosten,int ArbeitUpgrade)
    {
        if (stoff == 0)//Geld
        {
            inventar=player.GetComponent<SpielerInventar>().spielerGeld;
            inventar = inventar - kosten;
            player.GetComponent<SpielerInventar>().spielerGeld = inventar;
            
        }
        else if (stoff == 1)//Holz
        {
            inventar = player.GetComponent<SpielerInventar>().spielerHolz;
            inventar = inventar - kosten;
            player.GetComponent<SpielerInventar>().spielerHolz = inventar;
            
        }
        else if (stoff == 2)//Stein
        {
            inventar = player.GetComponent<SpielerInventar>().spielerStein;
            inventar = inventar - kosten;
            player.GetComponent<SpielerInventar>().spielerStein = inventar;
            
        }
        else if (stoff == 3)//Metal
        {
            inventar = player.GetComponent<SpielerInventar>().spielerMetal;
            inventar = inventar - kosten;
            player.GetComponent<SpielerInventar>().spielerMetal = inventar;
            
        }
        KostenErhöhen(stoff,ArbeitUpgrade);
    }

    public void KostenErhöhen(int stoff,int UpAr)
    {
        if (stoff == 0)
        {
            if (UpAr == 1)
            {
                stufeGeldKosten = stufeGeldKosten + 100 * stufeGeld;
            }
            else
            {
                arbeiterGeldKosten = arbeiterGeldKosten + 100 * arbeiterGeld;
            }
        }
        else if (stoff == 1)
        {
            if (UpAr == 1)
            {
                stufeHolzKosten = stufeHolzKosten + 100 * stufeHolz;
            }
            else
            {
                arbeiterHolzKosten = arbeiterHolzKosten + 100 * arbeiterHolz;
            }
        }
        else if (stoff == 2)
        {
            if (UpAr == 1)
            {
                stufeSteinKosten = stufeSteinKosten + 100 * stufeStein;
            }
            else
            {
                arbeiterSteinKosten = arbeiterSteinKosten + 100 * arbeiterStein;
            }
        }
        else if (stoff == 3)
        {
            if (UpAr == 1)
            {
                stufeMetalKosten = stufeMetalKosten + 100 * stufeMetal;
            }
            else
            {
                arbeiterMetalKosten = arbeiterMetalKosten + 100 * arbeiterMetal;
            }
        }
    }

    public void InventarTestenHäuser(int art)
    {
            if(art == 0)
            {
                if (player.GetComponent<SpielerInventar>().spielerGeld >= stufeGeldKosten)
                {
                    HäuserKaufen(art);
                    Abziehen(art, stufeGeldKosten, 1);
                    stufeGeld++;
                    UpgradeKostenAnzeige(art);
                }
            }
            else if (art == 1)
            {
                if (player.GetComponent<SpielerInventar>().spielerHolz >= stufeHolzKosten)
                {
                    HäuserKaufen(art);
                    Abziehen(art, stufeHolzKosten, 1);
                    stufeHolz++;
                    UpgradeKostenAnzeige(art);
                }
            }
            else if (art == 2)
            {
                if (player.GetComponent<SpielerInventar>().spielerStein>= stufeSteinKosten)
                {
                    HäuserKaufen(art);
                    Abziehen(art, stufeSteinKosten, 1);
                    stufeStein++;
                    UpgradeKostenAnzeige(art);
                }
            }
            else if (art == 3)
            {
                if (player.GetComponent<SpielerInventar>().spielerMetal >= stufeMetalKosten)
                {
                    HäuserKaufen(art);
                    Abziehen(art, stufeMetalKosten, 1);
                    stufeMetal++;
                    UpgradeKostenAnzeige(art);
                }
            }
    }

    public void InventarTestenArbeiter(int art)
    {
        if (art == 0)
        {
            if (player.GetComponent<SpielerInventar>().spielerGeld >= arbeiterGeldKosten)
            {
                ArbeiterKaufen(art);
                Abziehen(art, arbeiterGeldKosten, 0);
                arbeiterGeld++;
                ArbeiterKostenAnzeige(art);
            }
        }
        else if (art == 1)
        {
            if (player.GetComponent<SpielerInventar>().spielerHolz >= arbeiterHolzKosten)
            {
                ArbeiterKaufen(art);
                Abziehen(art, arbeiterHolzKosten, 0);
                arbeiterHolz++;
                ArbeiterKostenAnzeige(art);
            }
        }
        else if (art == 2)
        {
            if (player.GetComponent<SpielerInventar>().spielerStein >= arbeiterSteinKosten)
            {
                ArbeiterKaufen(art);
                Abziehen(art, arbeiterSteinKosten, 0);
                arbeiterStein++;
                ArbeiterKostenAnzeige(art);
            }
        }
        else if (art == 3)
        {
            if (player.GetComponent<SpielerInventar>().spielerMetal >= arbeiterMetalKosten)
            {
                ArbeiterKaufen(art);
                Abziehen(art, arbeiterMetalKosten, 0);
                arbeiterMetal++;
                ArbeiterKostenAnzeige(art);
            }
        }
    }

    public void HäuserKaufen(int stoff)
    {
        player.GetComponent<GeldProduzieren>().Erweiterungen(stoff);
    }

    public void ArbeiterKaufen(int stoff)
    {
        player.GetComponent<GeldProduzieren>().ArbeiterKaufen(stoff);
    }


}
