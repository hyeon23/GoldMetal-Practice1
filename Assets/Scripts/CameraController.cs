using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.transform.position;
    }

    void LateUpdate()//ī�޶� �̵��� LateUpdate 
    {
        transform.position = playerTransform.position + offset;
    }   
}
