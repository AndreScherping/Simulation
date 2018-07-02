using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuilder : MonoBehaviour
{
    public GameObject[] Buildings;
    public GameObject XStreets;
    public GameObject ZStreets;
    public GameObject Crossroads;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public int[,] mapgrid;

    private int buildingFootPrint = 3;

    private void Start()
    {
        mapgrid = new int[mapWidth, mapHeight];
        int seed = 10;
        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                mapgrid[w, h] = (int)(Mathf.PerlinNoise(w / 10.0f + seed, h / 10.0f + seed) * 5);             
            }
        }

        int x = 0;
        for(int n = 0; n < 50; n++)
        {
            for(int h = 0; h < mapHeight; h++)
            {
                mapgrid[x, h] = -1;
            }
            x += 3;
            //x += Random.Range(5, 10);
            if (x >= mapWidth)
                break;
        }

        int z = 0;
        for(int n = 0; n < 10; n++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                if(mapgrid[w, z] == -1)
                {
                    mapgrid[w, z] = -3;
                }
                else
                {
                    mapgrid[w, z] = -2;
                }
            }
            z += 4;
            //z += Random.Range(3, 20);
            if (z >= mapHeight)
                break;
        }

        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                int result = mapgrid[w, h];
                Vector3 pos = new Vector3(w * buildingFootPrint, 0, h * buildingFootPrint);

                if (result == -3)
                {
                    Instantiate(Crossroads, pos, Crossroads.transform.rotation);
                }
                else if (result == -2)
                {
                    Instantiate(XStreets, pos, XStreets.transform.rotation);
                }
                else if (result == -1)
                {
                    Instantiate(ZStreets, pos, ZStreets.transform.rotation);
                }
                else if (result == 0 || result == 1 || result == 2 || result == 3)
                {
                    mapgrid[w, h] = 4;
                    result = 4;
                }

                if (result == 4)
                {
                    Instantiate(Buildings[4], pos, Quaternion.identity);
                }
            }
        }
    }
}
