using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [Header("Informations")]
    [SerializeField] private Camera camera;
    [SerializeField] private Transform player;
    [SerializeField] private float threshold;
    
    

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = player.position;
        Vector3 targetPos = (playerPos + mousePos)/2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + playerPos.x, threshold + playerPos.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + playerPos.y, threshold + playerPos.y);

        transform.position = targetPos;
    }
}
