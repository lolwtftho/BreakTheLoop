using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class DragController : MonoBehaviour
{

    [HideInInspector] public bool mouseDown = false;

    private Vector3 screenPoint;
    private Vector3 offset;

    GameObject grab;
    AudioSource grabAudio;

    GameObject drop;
    AudioSource dropAudio;

    private void Start()
    {
        if (tag == "youwin")
            return;
        else
            GetComponent<Rigidbody>().isKinematic = true;

        grab = GameObject.FindWithTag("grab");
        grabAudio = grab.GetComponent<AudioSource>();

        drop = GameObject.FindWithTag("drop");
        dropAudio = drop.GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (enabled)
        {
            mouseDown = true;

            if (tag != "youwin")
            {
                grabAudio.time = 0.1f;
                grabAudio.Play();
            }

            GetComponent<Rigidbody>().isKinematic = false;

            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (enabled)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    private void OnMouseUp()
    {
        if (enabled)
            mouseDown = false;

        if (tag != "youwin")
        {
            dropAudio.time = 0.1f;
            dropAudio.Play();
        }
    }
}
