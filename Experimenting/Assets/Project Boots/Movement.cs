using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 850f;
    [SerializeField] float rotationThrust = 120f;
    [SerializeField] GameObject btnReset;
    [SerializeField] ParticleSystem rocketJet;
    [SerializeField] ParticleSystem rocketJetLeft;
    [SerializeField] ParticleSystem rocketJetRight;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem success;
    bool isDie = false;
    bool isMove = true;
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
        if (isMove)
        {
            ProcessInput();
            ProcessRotation();
        }
    }
    void ProcessInput()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
            rocketJet.Play();
        }
        else
        {
            rocketJet.Stop();
        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
            rocketJetRight.Play();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            rocketJetLeft.Play();
        }
        else
        {
            rocketJetLeft.Stop();
            rocketJetRight.Stop();
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
            isMove = false;
            Invoke("die", 1f);
            Debug.Log("die");
            explosion.Play();
        }
        if (collision.gameObject.tag == "End")
        {
            isDie = true;
            Debug.Log("win");
            explosion.Play();
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
    public void backMenu()
    {
        SceneManager.LoadScene(0);
    }
}
