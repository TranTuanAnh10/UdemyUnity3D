using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketTrigger : MonoBehaviour
{
    [SerializeField] GameObject basket;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("removeRim", .2f);
        }
    }
    
    public void removeRim()
    {
        Destroy(basket);
        GameManager.Instance.creatBasket();
    }
}
