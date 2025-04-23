using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private TextMeshPro playerText;
    private TextMeshPro enemyText;
    private AudioSource hitWallSound;
    
    private bool shouldRespawn;
    private bool notify;
    private bool notifyWin;
    
    private float notifyTimer;
    private float respawnTimer;

    public Transform notificationPoint;
    private Vector3 notificationOrigin;
    
    private Vector3 respawnPosition;
    private TextMeshPro scoredText;
    private GameObject notification;
    private AudioSource hit;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerText = GameObject.Find("PlayerScoreText").GetComponent<TextMeshPro>();
        enemyText = GameObject.Find("EnemyScoreText").GetComponent<TextMeshPro>();
        hitWallSound = GameObject.Find("HitWallSound").GetComponent<AudioSource>();
        scoredText = GameObject.Find("WhoScoredText").GetComponent<TextMeshPro>();
        notification = GameObject.Find("WhoScoredText");
        notificationOrigin = notification.transform.position;
        hit = GetComponent<AudioSource>();
    }
    void Update() {
        float distanceToCenter = Vector3.Distance(Vector3.zero, transform.position);

        if (distanceToCenter > 10)
        {
            Goal();
        }
        // wait for a couple of seconds before ball respawn
        if (shouldRespawn)
        {
            respawnTimer += Time.deltaTime;

            if( respawnTimer >= 2)
            {
                // return to playarea
                transform.position = respawnPosition;
                respawnTimer = 0;
                shouldRespawn = false;
            }
        }
        // info dropdown (player scored! enemy scored! etc.)
        if(notify)
        {
            notifyTimer += Time.deltaTime;

            if(notifyTimer <= 0.5f)
            {
                notification.transform.position = Vector2.Lerp(notification.transform.position, notificationPoint.position, 5f * Time.deltaTime);
            }
            else if (notifyTimer is > 1.5f and < 2f)
            {
                notification.transform.position = Vector2.Lerp(notification.transform.position, notificationOrigin, 5f * Time.deltaTime);
            }
            else if(notifyTimer > 2)
            {
                notify = false;
                notifyTimer = 0;
            }
        }
        // win dropdown
        if(notifyWin)
        {
            notifyTimer += Time.deltaTime;

            if(notifyTimer <= 0.5f)
            {
                notification.transform.position += new Vector3(0, -5, 0) * Time.deltaTime;
            }
            else if(notifyTimer <= 1.5f && notifyTimer > 0.5f)
            {
                
            }
            else if(notifyTimer <= 2 && notifyTimer > 1.5f)
            {
                
            }
            else if(notifyTimer > 2)
            {
                notifyWin = false;
                notifyTimer = 0;
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("EnemyGoal"))
        {
            Goal("Enemy");

        }
        else if (collision.gameObject.name.Contains("PlayerGoal"))
        {
            Goal("Player");
        }
        else if (collision.gameObject.name.Contains("Wall"))
        {
            hitWallSound.Play();
        }
        else
        {
            hit.Play();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Goal(string goalName = "")
    {
        transform.position = new Vector3(0,9,0);
        rb.velocity = Vector2.zero;
        respawnPosition = Vector3.zero;
        notify = true;
        
        if(goalName == "Player")
        {
            respawnPosition =- Vector3.right;
            enemyText.text = (int.Parse(enemyText.text) + 1).ToString();
            scoredText.text = "Enemy scored!";
        }
        else if (goalName == "Enemy")
        {
            respawnPosition =- Vector3.left;
            playerText.text = (int.Parse(playerText.text) + 1).ToString();
            scoredText.text = "You scored!";
        }
        
        shouldRespawn = true;

        if (int.Parse(playerText.text) == 7)
        {
            notification.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1.4f);

            notify = false;
            scoredText.text = "You Won!";
            notifyWin = true;
            shouldRespawn = false;
        }
        else if (int.Parse(enemyText.text) == 7)
        {
            notification.GetComponent<RectTransform>().localScale = new Vector3(1.4f, 1.4f, 1.4f);
            
            notify = false;
            scoredText.text = "Enemy Won!";
            notifyWin = true;
            shouldRespawn = false;
        }
    }
}
