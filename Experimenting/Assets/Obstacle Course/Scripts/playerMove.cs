using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Text txtHits;
    [SerializeField] GameObject txtInfor;
    private int hits = 0;
    // Start is called before the first frame update
    void Start()
    {
        txtHits.text = "Hits: " + hits;
    }

    // Update is called once per frame
    void Update()
    {
        if(txtInfor.activeSelf == false) { 
            float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.position = transform.position + new Vector3(horizontalInput, 0f, verticalInput);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Hit")
        {
            hits++;
            txtHits.text = "Hits: " + hits;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            SceneManager.LoadScene(3);
        }
    }
}
