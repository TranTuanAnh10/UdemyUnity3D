using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb; 
    public int speed = 10;
    public int turningSpeed = 10;
    [SerializeField]GameObject wheel;
    [SerializeField]GameObject wheel1;
    [SerializeField]GameObject wheel2;
    [SerializeField]GameObject wheel3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput != 0 || verticalInput != 0) {
            transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0f, verticalInput * speed * Time.deltaTime);
            if(verticalInput > 0)
            {
                wheel.transform.Rotate(speed * (50) * Time.deltaTime, 0f, 0f);
                wheel1.transform.Rotate(speed * (50) * Time.deltaTime, 0f, 0f);
                wheel2.transform.Rotate(speed * (50) * Time.deltaTime, 0f, 0f);
                wheel3.transform.Rotate(speed * (50) * Time.deltaTime, 0f, 0f);
            }
            else
            {
                wheel.transform.Rotate(speed * (-50) * Time.deltaTime, 0f, 0f);
                wheel1.transform.Rotate(speed * (-50) * Time.deltaTime, 0f, 0f);
                wheel2.transform.Rotate(speed * (-50) * Time.deltaTime, 0f, 0f);
                wheel3.transform.Rotate(speed * (-50) * Time.deltaTime, 0f, 0f);
            }
           /* if (horizontalInput > 0)
            {
                wheel1.transform.Rotate(30f, 0f, 0f);
                wheel3.transform.Rotate(30f, 0f, 0f);
            }
            else
            {
                wheel1.transform.Rotate(-30f, 0f, 0f);
                wheel3.transform.Rotate(-30f, 0f, 0f);
            }*/
        }
        
    }
}
