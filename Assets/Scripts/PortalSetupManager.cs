using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSetupManager : MonoBehaviour
{
    public Camera cameraRight;
    public Material cameraMatRight;

    public Camera cameraLeft;
    public Material cameraMatLeft;
    // Start is called before the first frame update
    void Start()
    {

        if (cameraLeft.targetTexture != null)
        {
            cameraLeft.targetTexture.Release();
        }
        cameraLeft.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatLeft.mainTexture = cameraLeft.targetTexture;

        if (cameraRight.targetTexture != null)
        {
            cameraRight.targetTexture.Release();
        }
        cameraRight.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatRight.mainTexture = cameraRight.targetTexture;
    }
}
