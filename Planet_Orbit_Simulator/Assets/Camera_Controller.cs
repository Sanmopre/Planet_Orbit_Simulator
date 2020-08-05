using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target;

    public Transform Camera;

    private GameObject Cel_Obj;
    float mouseX, mouseY;

    public bool focused_on_planet = false;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

        Camera.transform.position = new Vector3(0.0f, 0.0f, -350.0f);
        focused_on_planet = true;
    }


    public void UnfixCameraPlanet() {
        Target.transform.SetParent(null);
        Target.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        Camera.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        focused_on_planet = false;

    }
    

    void LateUpdate()
    {        
        
        CamControl();
        if (Input.GetKeyDown("space") && focused_on_planet == false)
        {
            Cel_Obj = GameObject.Find("SUN");
            FixCameraPlanet(Cel_Obj.transform);
        }
        else if (Input.GetKeyDown("space") && focused_on_planet == true) {
            UnfixCameraPlanet();
        }



    }
}
