using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private AudioSource AS;
    private AudioSource buttonAudio;
    private ParticleSystem PS;
    private bool isPlay;
    private float playTimer;
    private void Start() {
        AS = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        PS = GetComponent<ParticleSystem>();
        buttonAudio = GetComponent<AudioSource>();
    }
    private void Update() {
        if (isPlay)
        {
            playTimer += Time.deltaTime;

            if (playTimer < 1)
            {
                AS.volume -= 0.3f * Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("GameLevel");
            }
        }
    }
    private void OnMouseDown() 
    {
        isPlay = true;
        PS.Play();
        buttonAudio.Play();
    }
}
