using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManeger : MonoBehaviour
{
    [SerializeField] GameObject txtInfor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time == 3)
        {
            Debug.Log("This Time");
        }
    }
    public void btnActivePopup()
    {
        if (txtInfor.activeSelf)
        {
            txtInfor.SetActive(false);
        }
        else
        {
            txtInfor.SetActive(true);
        }
    }
    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
