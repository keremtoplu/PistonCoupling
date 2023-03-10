using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBolt_1 : Parts
{
    public override void MoveTargetWithAnimation()
    {
        
        LeanTween.rotateAroundLocal(gameObject,Vector3.forward,-360,4f);
        base.MoveTargetWithAnimation();
    }
}
