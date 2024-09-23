using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry_RandomP : MonoBehaviour
{
    //Strawberry Obstacles
    public GameObject rotation1; 
    public GameObject rotation2;
    public GameObject rotation3;

    void Start()
    {
        R1();
        R2();
        R3();
    }


    void R1()
    {
        int randomNumber = Random.Range(0, 3);

        if(randomNumber == 0)
        {
                rotation1.transform.position = new Vector3(-7, 128, 0); 
        }
        else if (randomNumber == 1)
        {
                rotation1.transform.position = new Vector3(5, 128, 0);
        }
        else if(randomNumber == 3)
        {}
    }

    void R2()
    {
        int randomNumber = Random.Range(0, 3);

        if (randomNumber == 0)
        {
                rotation2.transform.position = new Vector3(-7, 173, 0);
        }
        else if (randomNumber == 1)
        {
                rotation2.transform.position = new Vector3(5, 173, 0);
        }
        else if (randomNumber == 3)
        {}
    }

    void R3()
    {
        int randomNumber = Random.Range(0, 3);

        if (randomNumber == 0)
        {
                rotation3.transform.position = new Vector3(-7, 224, 0);
        }
        else if (randomNumber == 1)
        {
                rotation3.transform.position = new Vector3(5, 224, 0);
        }
        else if (randomNumber == 3)
        {}
       
    }
}
