using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    public class MovementScript : MonoBehaviour
    {
        public float speed;
        private int nextPoint;

        private bool stopRacing = false;

        public Transform[] movePoints;

        [HideInInspector] public bool raceFinished = false;

        [HideInInspector] public bool blastOff = false;

        private Rigidbody rb;

        float fixedXRotation = -5.0f;

        bool zeroTouched = false;

        GameObject youWin;

        AudioSource audioS;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            youWin = GameObject.FindWithTag("youwin");
            youWin.SetActive(false);
            audioS = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (!blastOff)
            {
                transform.position = Vector3.MoveTowards(transform.position, movePoints[nextPoint].position, speed * Time.deltaTime);
                transform.LookAt(movePoints[nextPoint]);
            }
            else if (Vector3.Distance(transform.position, movePoints[1].position) < 0.1f && blastOff)
            {
                youWin.SetActive(true);
                zeroTouched = true;
                LaunchSpeed();
            }
            else if (Vector3.Distance(transform.position, movePoints[1].position) > 0.1f && blastOff && !zeroTouched)
            {
                transform.position = Vector3.MoveTowards(transform.position, movePoints[nextPoint].position, speed * Time.deltaTime);
                transform.LookAt(movePoints[nextPoint]);
            }
            

            //Stops the nose of the car from pointing down
            if (transform.rotation.x != fixedXRotation)
                transform.eulerAngles = new Vector3(fixedXRotation, transform.eulerAngles.y, transform.eulerAngles.z);


            if (Vector3.Distance(transform.position, movePoints[nextPoint].position) < 0.1f && !stopRacing)
            {
                nextPoint++;
                if (nextPoint > movePoints.Length - 1)
                    nextPoint = 0;
                
            }


            if (Vector3.Distance(transform.position, movePoints[0].position) < 0.1f && raceFinished)
            {
                transform.position = movePoints[0].position;
                youWin.SetActive(true);
                audioS.enabled = false;

                if (Vector3.Distance(transform.position, movePoints[0].position) < 0.1f)
                    stopRacing = true;
            }


        }

        public void LaunchSpeed()
        {
            if (transform.rotation.y != 0)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            rb.velocity = transform.forward * speed;
        }
    }
}
