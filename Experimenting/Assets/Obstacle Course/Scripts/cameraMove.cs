using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cameraMain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraMain.transform.position = player.transform.position + (new Vector3(0f, 3f, -2f));
    }
}
