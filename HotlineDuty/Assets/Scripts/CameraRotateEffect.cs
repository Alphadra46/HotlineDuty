using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{

    private float zRotVal = 0f;
    
    // Update is called once per frame
    void Update()
    {
        CameraTilt();
    }

    private void CameraTilt()
    {
        
        float direction = InputManager.instance.move.ReadValue<Vector2>().x;

        if (InputManager.instance.move.ReadValue<Vector2>().x != 0)
        {
            zRotVal += 0.01f * direction > 0 ? 1f : -1f;
            zRotVal = Mathf.Clamp(zRotVal, -5f, 5f);
        }
        else //Reset the camera rotation if there is no movement input
        {
            zRotVal = 0f;
        }

        transform.eulerAngles = new Vector3(0, 0, zRotVal);
    }
    
}
