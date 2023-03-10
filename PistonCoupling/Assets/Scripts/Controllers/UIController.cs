using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialPanel;

    [SerializeField]
    private GameObject succesPanel;
    [SerializeField]
    private GameObject MainGame;

    private void Awake() 
    {
        MontageController.Instance.MontageCompleted+=OnMontageCompleted;

    }
    void Start()
    {
        tutorialPanel.SetActive(true);
        succesPanel.SetActive(false);
        MainGame.SetActive(false);
    }


    public void StartTheGame()
    {   
        tutorialPanel.SetActive(false);
        MainGame.SetActive(true);
    }


    public void ReStartGame()
    {
        MontageController.Instance.UpdateMontageStatus(false);
        MontageController.Instance.LastAMontagePartsCount=1;
        MontageController.Instance.LastBMontagePartsCount=0;
        MontageController.Instance.CurrentMontageCount=0;
        succesPanel.SetActive(false);
    }


    private void OnMontageCompleted()
    {
        succesPanel.SetActive(true);
    }


}
