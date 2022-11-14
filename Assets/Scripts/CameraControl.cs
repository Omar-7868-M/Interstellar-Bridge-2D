using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
      DisableAutoRotation ();
    }

    public void DisableAutoRotation() {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(target.transform.position.x,transform.position.y, -10);
    }
}
