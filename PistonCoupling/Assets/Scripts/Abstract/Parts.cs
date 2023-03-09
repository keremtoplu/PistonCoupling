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

    private Vector2 turn;
    private bool isRotate=false;
    private Vector3 mOffSet;
    private float mZCoord;

    public bool IsRotate{ get{return isRotate;} set{isRotate=value;} }
    private void OnMouseDown() 
    {
        mZCoord=Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet=gameObject.transform.position-GetMouseWorldPos();
    }

    private void OnMouseDrag() 
    {
        transform.position=GetMouseWorldPos()+mOffSet;
        
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
        LeanTween.moveLocal(gameObject,targetTransform.position,2f).setEaseLinear();
    }

    private void OnTriggerStay(Collider other) 
    {
        
        if(other.gameObject.name==targetTransform.name)
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("asd");
            if(Input.GetMouseButtonUp(0) && montageNumber>=montageController.CurrentMontageCount )
            {
                Debug.Log("montage");
                montageController.CurrentMontageCount=montageNumber;
                MoveTargetWithAnimation();
                other.transform.GetChild(0).gameObject.SetActive(false);

            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name==targetTransform.name)
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
