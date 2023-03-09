using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBolt_1 : Parts
{
    public override void MoveTargetWithAnimation()
    {
        
        base.MoveTargetWithAnimation();
        transform.Translate(Vector3.forward*10f*Time.deltaTime);
    }
}
