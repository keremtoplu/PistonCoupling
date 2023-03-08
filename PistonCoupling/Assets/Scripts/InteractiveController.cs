using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private float rotateSpeed;
    
    private Rigidbody rb;
    private bool isInteractive=false;
    private bool isRotateparts=false;

    public bool IsInteractive=>isInteractive;

    private void Start() 
    {
       
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)&&isRotateparts==false)
        {
            Ray interactiveRay=mainCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(interactiveRay,out RaycastHit rayHit))
            {
                var parts=rayHit.collider.GetComponentInParent<Parts>();
                if(parts)
                {
                    isInteractive=true;
                    Debug.Log("asd");
                }
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Ray interactiveRay=mainCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(interactiveRay,out RaycastHit rayHit))
            {
                var parts=rayHit.collider.GetComponent<Parts>();
                if(parts&&parts.IsMontaged==false)
                {
                    rb=parts.transform.GetComponent<Rigidbody>();
                    Debug.Log("as1");
                    isRotateparts=true;
                    float rotX=Input.GetAxis("Mouse X")*rotateSpeed*Time.fixedDeltaTime;
                    float rotY=Input.GetAxis("Mouse Y")*rotateSpeed*Time.fixedDeltaTime;
                    rb.AddTorque(Vector3.down*rotX);
                    rb.AddTorque(Vector3.up*rotY);
                    // if(Input.GetMouseButtonUp(1))
                    //     isRotateparts=false;

                    Debug.Log(isRotateparts);
                }
            }
        }

        
    }
}
