using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAllow : MonoBehaviour
{
    public TruckTrigger truckTrigger;
    public AICar car;

    public bool isEnterPlayer = false;
    public bool carEnter = false;

    public float timer;
    public float truckTriggerStandTime = 4f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEnterPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEnterPlayer = false;
        }
    }

    private void Update()
    {
        if (isEnterPlayer)
        {
            if (truckTrigger.isEntered && !carEnter)
            {
                carEnter = true;
            }

            if (carEnter)
            {
                if (!truckTrigger.isEntered)
                {
                    //Paradigm.CoreAppControl.Instance.DialogApp.CellWindow(Paradigm.WindowControll.TTypeWindow.Done);
                    carEnter = false;
                }
            }
        }

        if (isEnterPlayer && timer <= truckTriggerStandTime)
        {
            timer += Time.deltaTime;
        }

        if (timer >= truckTriggerStandTime)
        {
            GameManager.Instance.AddApply(GameManager.TCrash.blind_spot);
            car.type = AICar.TType.Start;
            timer = 0;
        }
    }

    public void ResetTruck()
    {
        isEnterPlayer = false;
        carEnter = false;
        timer = 0;
    }
}