using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   [SerializeField]
   private float mouseSensivity=1f;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float distanceFromTarget=5.0f;

    [SerializeField]
    private float zoom;

    private Camera cam;
    private float rotationY;
    private float rotationX;

    private bool isRotateActive=false;

    public bool IsRotateActive=>isRotateActive;

    private void Start() 
    {
        cam=Camera.main;
    }

   private void Update()
   {   
        if(Input.GetMouseButtonDown(1))
        {
            isRotateActive=true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isRotateActive=false;
        }

        if(isRotateActive)
        {
            
            float mouseY=Input.GetAxis("Mouse X")*mouseSensivity;
            float mouseX=Input.GetAxis("Mouse Y")*mouseSensivity;

            rotationX+=mouseX;
            rotationY+=mouseY;
            rotationX=Mathf.Clamp(rotationX,-40,40);

            transform.localEulerAngles=new Vector3(rotationX,rotationY,0);
            transform.position=_target.position-transform.forward*distanceFromTarget;
        }

        
        cam.fieldOfView-=Input.GetAxis("Mouse ScrollWheel")* zoom;  

         
   
   }

}
