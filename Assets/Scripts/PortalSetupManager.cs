using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSetupManager : MonoBehaviour
{
    public Camera cameraRight;
    public Material cameraMatRight;
    // Start is called before the first frame update
    void Start()
    {
        if (cameraRight.targetTexture != null)
        {
            cameraRight.targetTexture.Release();
        }
        cameraRight.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatRight.mainTexture = cameraRight.targetTexture;
    }
}
