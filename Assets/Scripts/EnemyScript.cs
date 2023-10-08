using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject puck;
    private Transform defencePoint;

    private float speed;
    private float defenceSpeed = 10;
    private float attackSpeed = 20;

    private Rigidbody2D rb;
    private Vector3 targetPos;
    private Vector3 defencePointOffset;

    public float moveCooldown;

    // Start is called before the first frame update
    void Start()
    {
        puck = GameObject.Find("Ball");
        rb = GetComponent<Rigidbody2D>();
        defencePoint = GameObject.Find("DefencePoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCooldown -= Time.deltaTime;
        if (moveCooldown <= 0)
        {
            defencePointOffset = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f));
            moveCooldown = 2;
        }
        bool puckInRange = puck.transform.position.x > 0;

        if(puckInRange)
        {   // attack
            targetPos = puck.transform.position + (defencePointOffset / 5f);
            speed = attackSpeed;
        }
        else
        {   // defence
            targetPos = defencePoint.position;
            targetPos += defencePointOffset;
            speed = defenceSpeed;
        }
        Vector3 finalPosition = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        rb.MovePosition(finalPosition);
    }
}
