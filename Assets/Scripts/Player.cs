using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (mousePos.x > 0) mousePos.x = 0;


        Vector3 finalPosition = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        rb.MovePosition(finalPosition);
    }
}
