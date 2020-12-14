using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSetupManager : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    public List<Material> camMatertials = new List<Material>();
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].targetTexture != null)
            {
                cameras[i].targetTexture.Release();
            }
            cameras[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            camMatertials[i].mainTexture = cameras[i].targetTexture;
        }
    }
}
