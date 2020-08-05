using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celestial_Object : MonoBehaviour
{
    public Rigidbody Rb;
    float G = 0.000000000006674f;

    public Vector3 Initial_Velocity;
    Vector3 Current_Force;


    private void Start()
    {
        Rb.velocity = Initial_Velocity;
    }


    public void Apply_Force(Vector3 force) {
        Rb.AddForce(force);
    }

    public Vector3 Get_Force(Rigidbody Other_Celestial, float Mass_Multiplier) {
        Vector3 force = Vector3.zero;
        Vector3 unit_vec;

        unit_vec = Other_Celestial.position - Rb.position;

        float dst = Mathf.Sqrt( (Rb.position.x - Other_Celestial.position.x)* (Rb.position.x - Other_Celestial.position.x) + (Rb.position.y - Other_Celestial.position.y)* (Rb.position.y - Other_Celestial.position.y) + (Rb.position.z - Other_Celestial.position.z)* (Rb.position.z - Other_Celestial.position.z));

        unit_vec = unit_vec / dst;

        float top = G * Rb.mass * Other_Celestial.mass * Mass_Multiplier;

        float magnitude = top / dst * dst;

        force = magnitude * unit_vec;

        return force;
    }

}
