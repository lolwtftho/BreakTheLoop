using Racing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradinsScript : MonoBehaviour
{

    public GameObject gradins;

    public MovementScript movementScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gradins")
        {
            Instantiate(gradins, this.transform);
            other.gameObject.SetActive(false);
            movementScript.blastOff = true;
        }
    }
    
}
