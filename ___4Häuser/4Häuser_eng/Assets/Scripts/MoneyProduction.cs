using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyProduction : MonoBehaviour {

    public Text MoneyText;
    public Text WoodText;
    public Text StoneText;
    public Text MetalText;

    public int Money;
    public int Wood;
    public int Stone;
    public int Metal;
    public int extraMoney;
    public int extraWood;
    public int extraStone;
    public int ExtraMetal;
    public int extensionMoney = 0;
    public int extensionWood = 0;
    public int extensionStone = 0;
    public int extensionMetal = 0;
    public int workmenMoney;
    public int workmenWood;
    public int workmenStone;
    public int workmenMetal;

    public Text correctionText;

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

        StartCoroutine(Print());
        StartCoroutine(Logging());
        StartCoroutine(Quarrying());
        StartCoroutine(Forge());

    }

    private void Update()
    {
        MoneyText.text = Money.ToString();
        WoodText.text = Wood.ToString();
        StoneText.text = Stone.ToString();
        MetalText.text = Metal.ToString();
    }

    public void Zusätze(int stoff)
    {
        if (stoff == 0)
        {
            buildBuilding.Build(stoff);
            extraMoney++;
        }
        else if (stoff == 1)
        {
            buildBuilding.Build(stoff);
            extraWood++;
        }
        else if (stoff == 2)
        {
            buildBuilding.Build(stoff);
            extraStone++;
        }
        else if (stoff == 3)
        {
            buildBuilding.Build(stoff);
            ExtraMetal++;
        }
    }

    public void Erweiterungen(int stoff)
    {
        if (stoff == 0)
        {
            upgradeFarmHouse.Upgrade(stoff);
            if (extensionMoney == 7)
            {
                extensionMoney = 0;
                Zusätze(stoff);
            }
        }
        else if (stoff == 1)
        {
            upgradeFarm.Upgrade(stoff);
            if (extensionWood == 7)
            {
                extensionWood = 0;
                Zusätze(stoff);
            }
        }
        else if (stoff == 2)
        {
            upgradeHouse.Upgrade(stoff);
            if (extensionStone == 7)
            {
                extensionStone = 0;
                Zusätze(stoff);
            }
        }
        else if (stoff == 3)
        {
            upgradeTower.Upgrade(stoff);
            if (extensionMetal == 7)
            {
                extensionMetal = 0;
                Zusätze(stoff);
            }
        }
    }

    public void WorkmenBying(int fabric)
    {
        if (fabric == 0)
        {
            workmenMoney++;
        }
        else if (fabric == 1)
        {
            workmenWood++;
        }
        else if (fabric == 2)
        {
            workmenStone++;
        }
        else if (fabric == 3)
        {
            workmenMetal++;
        }
    }

            IEnumerator Print()
            {
                Money = Money + extraMoney * extensionMoney * workmenMoney;
                yield return new WaitForSeconds(1);
                StartCoroutine(Print());
            }
            IEnumerator Logging()
            {
                Wood = Wood + extraWood * extensionWood * workmenWood;
                yield return new WaitForSeconds(1);
                StartCoroutine(Logging());
            }
            IEnumerator Quarrying()
            {
                Stone = Stone + extraStone * extensionStone * workmenStone;
                yield return new WaitForSeconds(1);
                StartCoroutine(Quarrying());
            }
            IEnumerator Forge()
            {
                Metal = Metal + ExtraMetal * extensionMetal * workmenMetal;
                yield return new WaitForSeconds(1);
                StartCoroutine(Forge());
            }
        }
