using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;

    private bool rotateActive=false;
    private Parts _parts;
    private CameraMovement cameraMovement;
    
    public bool RotateActive=>rotateActive;


    void Start()
    {
        cameraMovement=mainCam.GetComponent<CameraMovement>();
    }
    void Update()
    {
       
        if(Input.GetMouseButtonDown(1))
        {
            Ray interactiveRay=mainCam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(interactiveRay,out RaycastHit rayHit))
            {
                var parts=rayHit.collider.GetComponent<Parts>();
                if(parts)
                {
                    parts.IsRotate=true;
                    rotateActive=true;
                    _parts=parts;
                }
            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            rotateActive=false;
        }
        if(rotateActive && !cameraMovement.IsRotateActive && _parts.transform.parent==_parts.StartParent)
        {
            _parts.RotateByMouse();
        }

        
    }


    
}
