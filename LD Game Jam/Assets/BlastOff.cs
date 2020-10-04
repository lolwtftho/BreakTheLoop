using Racing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastOff : MonoBehaviour
{
    GameObject raceCar;
    MovementScript movementScript;

    // Start is called before the first frame update
    void Start()
    {
        raceCar = GameObject.FindWithTag("RaceCar");
        movementScript = raceCar.GetComponent<MovementScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == raceCar)
        {
            raceCar.GetComponent<MovementScript>().speed = 30;
            movementScript.LaunchSpeed();
        }

    }
}
