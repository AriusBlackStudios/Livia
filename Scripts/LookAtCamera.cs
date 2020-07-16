using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera playerCamera;
    void Update()
    {
        this.transform.LookAt(playerCamera.gameObject.transform);
    }
}
