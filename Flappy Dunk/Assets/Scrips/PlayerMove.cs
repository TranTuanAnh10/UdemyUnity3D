using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpFoce = 2.5f;
    [SerializeField] GameObject btnReset;
    bool isDie = false;
    Vector2 jumpHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpHeight = new Vector2(1f, jumpFoce);
        btnReset.gameObject.SetActive(false);
    }

    void Update()
    {
        if (rb.isKinematic) rb.isKinematic = false;
        if (isDie == false)
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
            {
                if (rb.isKinematic) rb.isKinematic = false;
                rb.velocity = jumpHeight;
            }
    }
    public void die()
    {
        rb.isKinematic = true;
        isDie = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Die");
            die();
            btnReset.gameObject.SetActive(true);
        }
    }
}
