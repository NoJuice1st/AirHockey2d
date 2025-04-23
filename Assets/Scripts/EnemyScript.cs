using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject puck;
    private Transform defencePoint;
    
    private float speed;
    [SerializeField]private float defenceSpeed = 10;
    [SerializeField]private float attackSpeed = 20;
    private float dir;

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
            dir = Vector3.Cross(transform.forward, (transform.position - puck.transform.position).normalized).y;

            if (dir > 0) // if puck on the left
            {
                targetPos = puck.transform.position + (defencePointOffset / 5f);
                
            }
            else
            {
                targetPos = puck.transform.position + new Vector3(0, -1 + Random.Range(-1f,1f) / 5f, 0);
                
            }
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
