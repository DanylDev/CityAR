﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class TruckTrigger : MonoBehaviour
{
    public AICar car;
    public bool isEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car" && other.transform.parent.GetComponent<AICar>().typeCar == AICar.TTypeCar.Truck)
        {
            isEntered = true;
            car.type = AICar.TType.Stop;
        }

        if (other.tag == "Player" || other.tag == "MainCamera")
        {
            if(isEntered)
            {
                GameManager.Instance.AddCrash(GameManager.TCrash.blind_spot);
            }

            car.type = AICar.TType.Start;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Car" && other.transform.parent.GetComponent<AICar>().typeCar == AICar.TTypeCar.Truck)
        {
            isEntered = false;
        }
    }
}