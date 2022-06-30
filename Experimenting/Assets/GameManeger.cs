using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    [SerializeField] GameObject directionalLight;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject cameraLui;
    [SerializeField] GameObject cameraPhu;
    [SerializeField] GameObject player;
    public float speed = 1f;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        camera1.transform.position = player.transform.position + new Vector3(0f, 1.38f, 0.42f);
        camera2.transform.position = player.transform.position + new Vector3(0f, 2.68f, -4.78f);
        cameraLui.transform.position = player.transform.position + new Vector3(0f, 1.46f, -1.46f);
        cameraPhu.transform.position = player.transform.position + new Vector3(-3.86f, 3.03f, -4.15f);
        directionalLight.transform.Rotate(speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (cameraLui.activeSelf)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
                cameraLui.SetActive(false);
                cameraPhu.SetActive(false);
            }
            else
            {
                camera1.SetActive(false);
                camera2.SetActive(false);
                cameraLui.SetActive(true);
                cameraPhu.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            if (camera1.activeSelf) { 
                camera1.SetActive(false);
                camera2.SetActive(true);
                cameraLui.SetActive(false);
                cameraPhu.SetActive(false);
            }
            else
            {
                camera1.SetActive(true);
                camera2.SetActive(false);
                cameraLui.SetActive(false);
                cameraPhu.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            if (cameraPhu.activeSelf)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
                cameraLui.SetActive(false);
                cameraPhu.SetActive(false);
            }
            else
            {
                camera1.SetActive(false);
                camera2.SetActive(false);
                cameraLui.SetActive(false);
                cameraPhu.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            resetLevel();
        }
        if (player.transform.position.y < -1f && !dead)
        {
            Die();
        }
        
    }
    void Die()
    {
        Invoke(nameof(resetLevel), 1.3f);
        dead = true;
    }
    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
