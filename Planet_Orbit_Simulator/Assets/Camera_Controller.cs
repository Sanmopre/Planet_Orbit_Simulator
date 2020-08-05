using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target;

    enum Cam_mode { FreeCam,Planet};

    Cam_mode cam_mode;

    public Transform Camera;

    public Celestial_Object[] Current_Planet_list;
    public Celestial_Object Current_Planet;
    float mouseX, mouseY;

    public bool focused_on_planet = false;

    private int iterator = 1;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam_mode = Cam_mode.FreeCam;
    }


    void CamControl() {

        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -45, 70);

        transform.LookAt(Target);


        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);

    }


    public void FixCameraPlanet(Transform newParent)
    {
        // Sets "newParent" as the new parent of the child GameObject.
        Target.transform.SetParent(newParent);
        Vector3 Cel_Position = newParent.transform.position;

        Target.transform.position = Vector3.zero + Cel_Position;
        Target.transform.rotation = Quaternion.identity;
        Target.transform.localScale = Vector3.one;

        Camera.transform.position = new Vector3(0.0f, 0.0f, -350.0f) + Cel_Position;
        transform.LookAt(Target);
        focused_on_planet = true;
    }


    public void UnfixCameraPlanet() 
    {


        Vector3 position = Target.parent.transform.position;

        Target.transform.SetParent(null);
        Target.transform.rotation = Quaternion.identity;
        Target.transform.localScale = Vector3.one;
        Target.transform.position = position + new Vector3(0.0f, 0.0f, 0.0f);
        Camera.transform.position = position + new Vector3(0.0f, 0.0f, 0.0f);
        Camera.transform.rotation = Quaternion.identity;
        focused_on_planet = false;

    }



    void Sawp_Cam_Mode() {
        if (cam_mode == Cam_mode.FreeCam)
        {
            FixCameraPlanet(Current_Planet_list[iterator].transform);
            cam_mode = Cam_mode.Planet;
            iterator++;
        }
        else if (cam_mode == Cam_mode.Planet) {
            UnfixCameraPlanet();
            cam_mode = Cam_mode.FreeCam;
        }
    }

    void LateUpdate()
    {


       Current_Planet_list = FindObjectsOfType<Celestial_Object>();
       Current_Planet = Current_Planet_list[iterator];

        CamControl();
     

        if (Input.GetKeyDown("space")){
            Sawp_Cam_Mode();
        }

        if (iterator >= Current_Planet_list.Length) {
            iterator = 0;
        }

        
        if (cam_mode == Cam_mode.Planet && Input.GetKeyDown(KeyCode.F)) {
            if (iterator < Current_Planet_list.Length)
            {
                FixCameraPlanet(Current_Planet_list[iterator].transform);
            }
            iterator++;
        }

    }
}
