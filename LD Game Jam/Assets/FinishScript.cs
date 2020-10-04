using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    public class FinishScript : MonoBehaviour
    {
        public GameObject flagProp;
        public GameObject flag;
        [HideInInspector] public bool lvlFinished = false;

        private void Start()
        {
            flag.GetComponent<MeshRenderer>().enabled = false;
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "UnstuckObj")
            {
                flag.GetComponent<MeshRenderer>().enabled = true;
                flagProp.SetActive(false);
                lvlFinished = true;
            }
        }
    }
}
