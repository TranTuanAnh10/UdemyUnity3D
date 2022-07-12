using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 850f;
    [SerializeField] float rotationThrust = 120f;
    [SerializeField] GameObject btnReset;
    bool isDie = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        btnReset.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }
    void ProcessInput()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" && isDie == false)
        {
            die();
            Debug.Log("die");
        }
        if (collision.gameObject.tag == "End")
        {
            isDie = true;
            Debug.Log("win");
            if (btnReset.activeSelf == false)
            {
                btnReset.SetActive(true);
            }
        }
    }
    public void die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
