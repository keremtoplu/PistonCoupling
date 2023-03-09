using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parts : MonoBehaviour
{
    [SerializeField]
    private float rotateSensivity=.5f;

    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    private MontageController montageController;

    [SerializeField]
    private int montageNumber;

    [SerializeField]
    private Transform parent;

    private Vector2 turn;
    private bool isRotate=false;
    private bool inSide=false;
    private Vector3 mOffSet;
    private float mZCoord;
    private Transform startParent;

    public Transform StartParent=>startParent;
    public bool IsRotate{ get{return isRotate;} set{isRotate=value;} }

    private void Start() 
    {
        startParent=transform.parent;
    }

    private void Update() {
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("uppp");
        }
    }
    private void OnMouseDown() 
    {
        mZCoord=Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet=gameObject.transform.position-GetMouseWorldPos();
    }

    private void OnMouseDrag() 
    {
        if(transform.parent=parent)
        {
            transform.parent=startParent;
            targetTransform.GetComponent<BoxCollider>().enabled=true;
        }
        transform.position=GetMouseWorldPos()+mOffSet;
        
    }
    private void OnMouseUp() 
    {
        if( montageNumber>=montageController.CurrentMontageCount && inSide)
        {
            parent=targetTransform;
            Debug.Log("montage");
            montageController.CurrentMontageCount=montageNumber;
            MoveTargetWithAnimation();
            targetTransform.GetChild(0).gameObject.SetActive(false);
            targetTransform.GetComponent<BoxCollider>().enabled=false;

        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint=Input.mousePosition;
        mousePoint.z=mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void RotateByMouse() 
    {
        turn.x+=Input.GetAxis("Mouse X")*rotateSensivity;
        turn.y+=Input.GetAxis("Mouse Y")*rotateSensivity;
        transform.localRotation=Quaternion.Euler(turn.y,-turn.x,0);
        
    }

    public virtual void MoveTargetWithAnimation()
    {
        transform.SetParent(targetTransform);
        transform.LeanMoveLocal(Vector3.zero,2f);
    }

    private void OnTriggerStay(Collider other) 
    {
        
        if(other.gameObject.name==targetTransform.name && transform.parent!=targetTransform)
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            inSide=true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name==targetTransform.name)
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            inSide=false;
        }
    }

}
