using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    Vector3 angleToRotate = new Vector3(0, 0.1f, 0);

    private void Update()
    {
        transform.Rotate(angleToRotate);
    }
}
