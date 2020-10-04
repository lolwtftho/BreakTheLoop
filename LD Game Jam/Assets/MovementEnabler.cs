using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnabler : MonoBehaviour
{

    DragController dragController;
    GameObject[] spectator;

    private void Start()
    {
        dragController = GetComponent<DragController>();
        dragController.enabled = false;
        spectator = GameObject.FindGameObjectsWithTag("MovingSpec");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cloud")
        {
            foreach (GameObject spectator in spectator)
            {
                spectator.SetActive(false);
            }
            dragController.enabled = true;
        }
    }

    
}
