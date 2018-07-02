using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeldProduzieren : MonoBehaviour {

    public Text GeldText;
    public Text HolzText;
    public Text SteinText;
    public Text MetalText;

    public int Geld;
    public int Holz;
    public int Stein;
    public int Metal;
    public int zusatzGeld;
    public int zusatzHolz;
    public int zusatzStein;
    public int zusatzMetal;
    public int erweiterungenGeld=0;
    public int erweiterungenHolz = 0;
    public int erweiterungenStein = 0;
    public int erweiterungenMetal = 0;
    public int ArbeiterGeld;
    public int ArbeiterHolz;
    public int ArbeiterStein;
    public int ArbeiterMetal;

    public Text verbesserungsText;

    private BuildBuilding buildBuilding;
    private UpgradeBuilding upgradeFarmHouse;
    private UpgradeBuilding upgradeFarm;
    private UpgradeBuilding upgradeHouse;
    private UpgradeBuilding upgradeTower;
    [SerializeField]
    private GameObject farmHouse;
    [SerializeField]
    private GameObject farm;
    [SerializeField]
    private GameObject house;
    [SerializeField]
    private GameObject tower;

    private void Start()
    {
        buildBuilding = GetComponent<BuildBuilding>();
        upgradeFarmHouse = farmHouse.GetComponent<UpgradeBuilding>();
        upgradeFarm = farm.GetComponent<UpgradeBuilding>();
        upgradeHouse = house.GetComponent<UpgradeBuilding>();
        upgradeTower = tower.GetComponent<UpgradeBuilding>();

        StartCoroutine(Drucken());
        StartCoroutine(Fällen());
        StartCoroutine(Abbauen());
        StartCoroutine(Schmieden());

    }

    private void Update()
    {
        GeldText.text = Geld.ToString();
        HolzText.text = Holz.ToString();
        SteinText.text = Stein.ToString();
        MetalText.text = Metal.ToString();
    }

    public void Zusätze(int stoff)
    {
        if (stoff == 0)
        {
            buildBuilding.Build(stoff);
            zusatzGeld++;
        }
        else if (stoff == 1)
        {
            buildBuilding.Build(stoff);
            zusatzHolz++;
        }
        else if (stoff == 2)
        {
            buildBuilding.Build(stoff);
            zusatzStein++;
        }
        else if (stoff == 3)
        {
            buildBuilding.Build(stoff);
            zusatzMetal++;
        }
    }

    public void Erweiterungen(int stoff)
    {
        if (stoff == 0)
        {
            upgradeFarmHouse.Upgrade(stoff);
            if (erweiterungenGeld == 7)
            {
                erweiterungenGeld = 0;
                Zusätze(stoff);
            }
        }
        else if (stoff == 1)
        {
            upgradeFarm.Upgrade(stoff);
            if (erweiterungenHolz == 7)
            {
                erweiterungenHolz = 0;
                Zusätze(stoff);
            }
        }
        else if (stoff == 2)
        {
            upgradeHouse.Upgrade(stoff);
            if (erweiterungenStein == 7)
            {
                erweiterungenStein = 0;
                Zusätze(stoff);
            }
        }
        else if (stoff == 3)
        {
            upgradeTower.Upgrade(stoff);
            if (erweiterungenMetal == 7)
            {
                erweiterungenMetal = 0;
                Zusätze(stoff);
            }
        }
    }

    public void ArbeiterKaufen(int stoff)
    {
        if (stoff == 0)
        {
            ArbeiterGeld++;
        }
        else if (stoff == 1)
        {
            ArbeiterHolz++;
        }
        else if (stoff == 2)
        {
            ArbeiterStein++;
        }
        else if (stoff == 3)
        {
            ArbeiterMetal++;
        }
    }

            IEnumerator Drucken()
            {
                Geld = Geld + zusatzGeld * erweiterungenGeld * ArbeiterGeld;
                yield return new WaitForSeconds(1);
                StartCoroutine(Drucken());
            }
            IEnumerator Fällen()
            {
                Holz = Holz + zusatzHolz * erweiterungenHolz * ArbeiterHolz;
                yield return new WaitForSeconds(1);
                StartCoroutine(Fällen());
            }
            IEnumerator Abbauen()
            {
                Stein = Stein + zusatzStein * erweiterungenStein * ArbeiterStein;
                yield return new WaitForSeconds(1);
                StartCoroutine(Abbauen());
            }
            IEnumerator Schmieden()
            {
                Metal = Metal + zusatzMetal * erweiterungenMetal * ArbeiterMetal;
                yield return new WaitForSeconds(1);
                StartCoroutine(Schmieden());
            }
        }
