using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void HandleCameraMovementEdgeScrolling()
    {
        
        Vector3 inputDir = new Vector3(0, 0, 0);
        
        int edgeScrollSize = 20;
        if (Input.mousePosition.x < edgeScrollSize) {
            inputDir.x = -1f;
        }
        if (Input.mousePosition.y < edgeScrollSize) {
            inputDir.z = -1f;
        }
        if (Input.mousePosition.x > Screen.width - edgeScrollSize) {
            inputDir.x = +1f;
        }
        if (Input.mousePosition.y > Screen.height-edgeScrollSize){
            inputDir.z = +1f; 
        }
        
        
        Vector3 moveDir= transform.forward * inputDir.z + transform.right * inputDir.x;
        float moveSpeed = 50f;
        transform.position += moveDir* moveSpeed * Time.deltaTime;
    }
}
