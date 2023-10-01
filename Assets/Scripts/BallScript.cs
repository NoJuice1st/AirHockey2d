using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private TextMeshPro playerText;
    private TextMeshPro enemyText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerText = GameObject.Find("PlayerScoreText").GetComponent<TextMeshPro>();
        enemyText = GameObject.Find("EnemyScoreText").GetComponent<TextMeshPro>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("EnemyGoal"))
        {
            Goal();
            playerText.text = (int.Parse(playerText.text) + 1).ToString();
        }
        else if (collision.gameObject.name.Contains("PlayerGoal"))
        {
            Goal();

            enemyText.text = (int.Parse(enemyText.text) + 1).ToString();
        }
    }

    private void Goal()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;
    }
}
