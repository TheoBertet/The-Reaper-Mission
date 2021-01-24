using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamping : MonoBehaviour
{
    public float limitXPos;
    public float limitXMin;
    public float limitYPos;
    public float limitYMin;

    public Transform targetToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(targetToFollow.position.x, limitXMin, limitXPos),
            Mathf.Clamp(targetToFollow.position.y, limitYMin, limitYPos),
            transform.position.z);
    }
}
