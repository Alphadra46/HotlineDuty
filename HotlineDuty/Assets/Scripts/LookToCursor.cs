using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCursor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera camera;

    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);

        rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg);
    }
}
