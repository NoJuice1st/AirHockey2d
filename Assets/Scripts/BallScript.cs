using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private TextMeshPro playerText;
    private TextMeshPro enemyText;
    private AudioSource HitWallSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerText = GameObject.Find("PlayerScoreText").GetComponent<TextMeshPro>();
        enemyText = GameObject.Find("EnemyScoreText").GetComponent<TextMeshPro>();
        HitWallSound = GameObject.Find("HitWallSound").GetComponent<AudioSource>();
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
        else if (collision.gameObject.name.Contains("Wall"))
        {
            HitWallSound.Play();
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void Goal()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector2.zero;
    }
}
