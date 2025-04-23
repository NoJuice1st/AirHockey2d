using UnityEngine;
using TMPro;

public class DynamicHalo : MonoBehaviour
{
    private SpriteRenderer SR;
    private TextMeshPro playerText;
    private TextMeshPro enemyText;

    public float colourLerpSpeed = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerText = GameObject.Find("PlayerScoreText").GetComponent<TextMeshPro>();
        enemyText = GameObject.Find("EnemyScoreText").GetComponent<TextMeshPro>();
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(playerText.text) < int.Parse(enemyText.text))
        {
            SR.color = Color.Lerp(SR.color, new Color(1, 0, 0), colourLerpSpeed * Time.deltaTime);
        }
        else if (int.Parse(playerText.text) > int.Parse(enemyText.text))
        {
            SR.color = Color.Lerp(SR.color, new Color(0, 1, 0), colourLerpSpeed * Time.deltaTime);
        }
        else
        {
            SR.color = Color.Lerp(SR.color, new Color(1, 0.9f, 0), colourLerpSpeed * Time.deltaTime);
        }
    }
}
