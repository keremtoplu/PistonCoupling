using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parts : MonoBehaviour
{
    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private InteractiveController interactiveController;


    private bool isMontaged=false;
    public bool IsMontaged { get
    {
        return isMontaged;
    } 
    set
    {
        isMontaged=value;
    } }
    public void MovedByMousePos()
    {
        Ray ray=mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            transform.position=raycastHit.point;
        }
        
    }

    public void Update() 
    {
        if(interactiveController.IsInteractive)
        {
            MovedByMousePos();
        }
    }


}
