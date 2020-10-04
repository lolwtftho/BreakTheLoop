using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject target;

    float rotateSpeed = 20.0f;
    float maxCamHeight = 0.5f;
    float minCamHeight = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * (rotateSpeed * Time.deltaTime));

        else if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * (rotateSpeed * Time.deltaTime));

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.rotation.x < maxCamHeight)
            {

                transform.Translate(Vector3.up * (rotateSpeed * Time.deltaTime));
            }
            else if (transform.rotation.x > maxCamHeight)
            {
                return;
            }
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.rotation.x > minCamHeight)
                transform.Translate(Vector3.down * (rotateSpeed * Time.deltaTime));
            else if (transform.rotation.x < minCamHeight)
            {
                return;
            }
        }
    }
}
