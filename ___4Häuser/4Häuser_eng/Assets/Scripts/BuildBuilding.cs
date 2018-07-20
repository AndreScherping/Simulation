using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{
    public GameObject ChooseBuildingCanvas;
    public GameObject[] BuildingSpawn;

    public UpgradeBuilding upgradeFarmHouse;
    public UpgradeBuilding upgradeFarm;
    public UpgradeBuilding upgradeHouse;
    public UpgradeBuilding upgradeTower;

    private CityBuilder cityBuilder;
    private GameObject[,] existingBuildings;

    private void Start()
    {
        cityBuilder = new CityBuilder();
        existingBuildings = new GameObject[cityBuilder.mapWidth, cityBuilder.mapHeight];
        cityBuilder.mapgrid = new int[cityBuilder.mapWidth, cityBuilder.mapHeight];

        int seed = 10;
        for (int x0 = 0; x0 < cityBuilder.mapHeight; x0++)
        {
            for (int z0 = 0; z0 < cityBuilder.mapWidth; z0++)
            {
                cityBuilder.mapgrid[x0, z0] = (int)(Mathf.PerlinNoise(x0 / 10.0f + seed, z0 / 10.0f + seed) * 5);
            }
        }

        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int z2 = 0; z2 < cityBuilder.mapHeight; z2++)
            {
                cityBuilder.mapgrid[x, z2] = -1;
                existingBuildings[x, z2] = BuildingSpawn[0];
            }
            x += 3;
            if (x >= cityBuilder.mapWidth)
                break;
        }

        int z = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int x2 = 0; x2 < cityBuilder.mapWidth; x2++)
            {
                if (cityBuilder.mapgrid[x2, z] == -1)
                {
                    cityBuilder.mapgrid[x2, z] = -3;
                    existingBuildings[x2, z] = BuildingSpawn[0];
                }
                else
                {
                    cityBuilder.mapgrid[x2, z] = -2;
                    existingBuildings[x2, z] = BuildingSpawn[0];
                }
            }
            z += 4;
            if (z >= cityBuilder.mapHeight)
                break;
        }

        Build(0);
        Build(1);
        Build(2);
        Build(3);

    }

    public void Build(int buildingNumber)
    { 
        int w = Random.Range(0, cityBuilder.mapWidth -1);
        int h = Random.Range(0, cityBuilder.mapHeight -1);

        int result = cityBuilder.mapgrid[w, h];
        Vector3 pos = new Vector3(w * 3, 0, h * 3);

        if(result == 0)
        {
            cityBuilder.mapgrid[w, h] = 4;
            result = 4;
        }
        else if (result == 1)
        {
            cityBuilder.mapgrid[w, h] = 4;
            result = 4;
        }
        else if (result == 2)
        {
            cityBuilder.mapgrid[w, h] = 4;
            result = 4;
        }
        else if (result == 3)
        {
            cityBuilder.mapgrid[w, h] = 4;
            result = 4;
        }

        if(result == 4 && existingBuildings[w, h] == null)
        {
            existingBuildings[w, h] = BuildingSpawn[buildingNumber];
            if(buildingNumber == 0)
            {
                Instantiate(BuildingSpawn[buildingNumber], pos, Quaternion.identity);
            }

            if(buildingNumber == 1)
            {
                Instantiate(BuildingSpawn[buildingNumber], pos, Quaternion.identity);
            }

            if(buildingNumber == 2)
            {
                Instantiate(BuildingSpawn[buildingNumber], pos, Quaternion.identity);
            }

            if(buildingNumber == 3)
            {
                Instantiate(BuildingSpawn[buildingNumber], pos, Quaternion.identity);
            }
        }
        else
        {
            Build(buildingNumber);
        }
    }
}
