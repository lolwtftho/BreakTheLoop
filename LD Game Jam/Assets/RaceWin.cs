using Racing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceWin : MonoBehaviour
{

    public GameObject flag;
    public GameObject flagProp;
    public MovementScript movementScript;

    // Start is called before the first frame update
    void Start()
    {

        flag.SetActive(false);
        flagProp.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "UnstuckObj")
        {
            flag.SetActive(true);
            other.gameObject.SetActive(false);
            movementScript.raceFinished = true;
        }
    }
}
