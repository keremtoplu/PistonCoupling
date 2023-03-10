using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parts : MonoBehaviour
{
    [SerializeField]
    private float rotateSensivity=.5f; 
    public Transform targetTransform;

    [SerializeField]
    private int montageNumber;

    private Vector2 turn;
    private bool isRotate=false;
    private bool inSide=false;
    private Vector3 mOffSet;
    private float mZCoord;
    private Transform startParent;
    private Vector3 startPos;
    public Transform StartParent=>startParent;

    private int test=0;
    public bool IsRotate{ get{return isRotate;} set{isRotate=value;} }

    private void Awake() 
    {
        MontageController.Instance.MontageStarted+=OnMontageStarted;    
    }
    private void Start() 
    {
        startParent=transform.parent;
        startPos=transform.position;

    }

    private void Update() {
        
    }
    private void OnMouseDown() 
    {
        Debug.Log("tıktık");
        mZCoord=Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet=gameObject.transform.position-GetMouseWorldPos();
        if(transform.parent==targetTransform)
        {
            Debug.Log("dışarıdayım");
            
            if(montageNumber%10==0 && MontageController.Instance.LastBMontagePartsCount>montageNumber)
            {
                MontageController.Instance.LastBMontagePartsCount=montageNumber-10;
                Debug.Log("%10'a");
            }
            else if(MontageController.Instance.LastAMontagePartsCount>montageNumber)
            {
                MontageController.Instance.LastAMontagePartsCount=montageNumber-1;
            }
            transform.parent=startParent;
            MontageController.Instance.CurrentMontageCount--;
            inSide=false;
            Debug.Log(MontageController.Instance.LastBMontagePartsCount);
            Debug.Log(MontageController.Instance.LastAMontagePartsCount);
            Debug.Log(MontageController.Instance.CurrentMontageCount);
        }
    }

    private void OnMouseDrag() 
    {
        
        transform.position=GetMouseWorldPos()+mOffSet;
        
    }
    private void OnMouseUp() 
    {
        if(inSide)
        {
            Debug.Log("montage");
            targetTransform.GetComponent<BoxCollider>().enabled=false;
            MoveTargetWithAnimation();
            targetTransform.GetChild(0).gameObject.SetActive(false);
            inSide=false;
            MontageController.Instance.CurrentMontageCount++;
            Debug.Log(MontageController.Instance.CurrentMontageCount);

            
           
        }
        else
        {
            
            targetTransform.GetComponent<BoxCollider>().enabled=true;
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
        transform.LeanMoveLocal(Vector3.zero,4f);
        
        Debug.Log("move");
    }
    
    private void OnTriggerStay(Collider other) 
    {
        
        if(other.gameObject.name==targetTransform.name && transform.parent!=targetTransform)
        {
            if(montageNumber%10==0)
            {
                if(montageNumber<=MontageController.Instance.LastBMontagePartsCount||montageNumber==MontageController.Instance.LastBMontagePartsCount+10)
                {
                    other.transform.GetChild(0).gameObject.SetActive(true);
                    MontageController.Instance.LastBMontagePartsCount=montageNumber;
                    inSide=true;
                    Debug.Log("%10");
                  

                }
                else
                {
                    other.transform.GetChild(1).gameObject.SetActive(true);
                    inSide=false;
                }

            }
            else 
            {
                if (montageNumber<=MontageController.Instance.LastAMontagePartsCount||montageNumber==MontageController.Instance.LastAMontagePartsCount+1)
                {
                    other.transform.GetChild(0).gameObject.SetActive(true);
                    MontageController.Instance.LastAMontagePartsCount=montageNumber;
                    inSide=true;
                    Debug.Log("%3");
                }
                else
                {
                    other.transform.GetChild(1).gameObject.SetActive(true);
                    inSide=false;
                }
               

            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name==targetTransform.name)
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.transform.GetChild(1).gameObject.SetActive(false);
            inSide=false;
            
            
        }
        
    }

    private void OnMontageStarted()
    {
        transform.SetParent(startParent);
        transform.position=startPos;
    }

}
