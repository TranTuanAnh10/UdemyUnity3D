using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer rendererDr;
    Rigidbody rb;
    [SerializeField] float timeToWaitStart = 1f;
    [SerializeField] float timeToWaitEnd = 10f;
    float timeToWait;
    // Start is called before the first frame update
    void Start()
    {
        rendererDr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rendererDr.enabled = false;
        timeToWait = Random.Range(timeToWaitStart, timeToWaitEnd);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            rb.useGravity = true;
            rendererDr.enabled = true;
        }
    }
}
