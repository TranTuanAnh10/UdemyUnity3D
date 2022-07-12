using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void resetScenne()
    {
        SceneManager.LoadScene(0);
        Debug.Log("click reset");
    }
}
