using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parts : MonoBehaviour
{
    [SerializeField]
    private float rotateSensivity=.5f;
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


}
