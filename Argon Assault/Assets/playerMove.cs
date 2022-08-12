using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float playerSpeed = 5f;

    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(horizontalInput, 0f, verticalInput);
    }
}
