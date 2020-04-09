using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float cameraDistOffset = 10;
    private Camera mainCamera;
    private GameObject playerObj;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        playerObj = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = playerObj.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
    }
}
