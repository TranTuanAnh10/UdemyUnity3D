using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject basket;
    [SerializeField] GameObject background;
    [SerializeField] GameObject ground;
    [SerializeField] Transform parentBasket;
    [SerializeField] Transform parentbg;
    private float creatBasketX;
    private float creatBgX;
    private int count = 0;
    public void Start()
    {
        Instance = this;
        for (var i = 0; i < 6; i++)
        {
            Instantiate(basket, new Vector2(-2 + (i * 3), Random.Range(-1f, 2f)), Quaternion.identity, parentBasket);
            creatBasketX = -2 + (i * 3);
        }
        for (var i = 0; i < 2; i++)
        {
            Instantiate(background, new Vector2(0 + (i*8), 0f), Quaternion.identity, parentbg);
            Instantiate(ground, new Vector2(0 + (i*8), -4.7f), Quaternion.identity, parentbg);
            creatBgX = i * 8f;
        }
    }
    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void creatBasket()
    {
        creatBasketX += 3;
        Instantiate(basket, new Vector2(creatBasketX, Random.Range(-1f, 2f)), Quaternion.identity, parentBasket);
        count++;
        Debug.Log(count);
        if(count == 3)
        {
            creatBgX += 8;
            Instantiate(background, new Vector2(creatBgX, 0f), Quaternion.identity, parentbg);
            Instantiate(ground, new Vector2(creatBgX, -4.7f), Quaternion.identity, parentbg);
            Debug.Log("create bg");
            count = 0;
        }
    }
}
