using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector2 cameraTarget;
    public Transform target;

    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Boss").transform;

    }


    void Update()
    {
        cameraTarget = new Vector3(target.position.x + 6, transform.position.y, -15);
        //transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
        transform.position = new Vector3(cameraTarget.x, cameraTarget.y, -15);
    }
}

