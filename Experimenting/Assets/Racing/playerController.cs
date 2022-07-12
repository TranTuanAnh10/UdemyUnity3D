using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody rb; 
    public int speed = 10;
    public int turningSpeed = 10;
    [SerializeField]GameObject wheel;
    [SerializeField]GameObject wheel1;
    [SerializeField]GameObject wheel2;
    [SerializeField]GameObject wheel3;
    [SerializeField]Text txt;
    private int life = 3;
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
        }
        if(life == 0) { resetLevel(); }
        txt.text = "Life: " + life;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Plane")
        {
            life = life - 1;
            Debug.Log("va cham: "+ collision.gameObject.name);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "finish")
        {
            Debug.Log("Winnnn");
            Invoke(nameof(finishLevel), 0.5f);
        }
    }

    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }public void finishLevel()
    {
        SceneManager.LoadScene(3);
    }
}
