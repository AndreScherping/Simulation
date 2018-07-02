using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    public GameObject FollowerCam;
    public GameObject CarCam;
    public GameObject AirCam;
    public int CamCounter = 1;
    private void Start()
    {
        CarCam.SetActive(true);
    }
    void Update ()
    {

		if (Input.GetButtonDown("Fire3"))
        {
            CamCounter++;
        }
        if (CamCounter == 1)
        {
            FollowerCam.SetActive(false);
            CarCam.SetActive(true);
            AirCam.SetActive(false);
        }
        else if (CamCounter == 2)
        {
            FollowerCam.SetActive(true);
            CarCam.SetActive(false);
            AirCam.SetActive(false);
        }
        else if (CamCounter == 3)
        {
            FollowerCam.SetActive(false);
            CarCam.SetActive(false);
            AirCam.SetActive(true);
            CamCounter = 0;
        }


        //if(button.down){int +1}

        //if(int==1)cam1-;cam2-;cam3+
        //else if(int==2)cam1-;cam2+;cam3-
        //else if(int==3)cam1+;cam2-;cam3-;int=0


    }
}
