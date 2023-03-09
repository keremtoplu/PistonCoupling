using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MontageController : Singleton<MontageController>
{
    
    public event Action MontageCompleted;
    private int currentMontageCount=0;
    private int lastAMontagePartsCount=1;
    private int lastBMontagePartsCount=0;

    public int LastAMontagePartsCount{get{return lastAMontagePartsCount;} set{lastAMontagePartsCount=value;}}
    public int LastBMontagePartsCount{get{return lastBMontagePartsCount;} set{lastBMontagePartsCount=value;}}
    public int CurrentMontageCount{ get{return currentMontageCount;} set{
        
        currentMontageCount+=value;
        if(currentMontageCount==9)
        {
            MontageCompleted?.Invoke();
        }
        } }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
