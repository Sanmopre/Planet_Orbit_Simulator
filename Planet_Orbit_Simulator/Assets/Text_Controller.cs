using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Controller : MonoBehaviour
{

    public Text t_name;
    public Text t_mass;

    public Text t_force;

    public GameObject OBJECT;
    private Celestial_Object cel_obj;

    public Camera_Controller controller;
    public Celestial_Manager celestalManager;


    void Update()
    {
        if (controller.focused_on_planet)
        {
            cel_obj = controller.Current_Planet.GetComponent<Celestial_Object>();
            OBJECT.SetActive(true);
            t_name.text = cel_obj.celestial_name;
            t_mass.text = "Mass" + cel_obj.Rb.mass.ToString();            
            Vector3 Force = celestalManager.Get_Force_At_Planet(cel_obj);

            t_force.text = "Force X:" + Force.x.ToString() +  "Y:" + Force.y.ToString() + "Z:" + Force.z.ToString() ;


        }
        else {
            OBJECT.SetActive(false);
        }

    }


}
