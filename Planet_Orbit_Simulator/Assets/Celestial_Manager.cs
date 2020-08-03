using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celestial_Manager : MonoBehaviour
{

    private Celestial_Object[] celestialObjects;
    public float Mass_Multiplier; 

    public void Update()
    {
        celestialObjects = FindObjectsOfType<Celestial_Object>();

        // Lookps for phy simlulation
        for (int i = 0; i < celestialObjects.Length; i++) {
            Vector3 Final_Force = Vector3.zero;
            for (int j = 0; j < celestialObjects.Length; j++) {

                if (i != j)
                {
                    Final_Force = Final_Force + celestialObjects[i].Get_Force(celestialObjects[j].Rb, Mass_Multiplier);
                }
            
            }
            celestialObjects[i].Apply_Force(Final_Force);
        }
    }

}
