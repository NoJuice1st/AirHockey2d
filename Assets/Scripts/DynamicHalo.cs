using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicHalo : MonoBehaviour
{
    private SpriteRenderer SR;
    private TextMeshPro playerText;
    private TextMeshPro enemyText;
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
            SR.color = new Color(1, 0, 0);
        }
        else if (int.Parse(playerText.text) > int.Parse(enemyText.text))
        {
            SR.color = new Color(0, 1, 0);
        }
        else
        {
            SR.color = new Color(1, 0.9f, 0);
        }
    }
}
