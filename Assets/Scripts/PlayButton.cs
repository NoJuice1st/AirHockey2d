using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private AudioSource AS;
    private AudioSource buttonAudio;
    private ParticleSystem PS;
    private bool isPlay;
    private float playTimer;

    private LevelManager levelManager;
    private void Start() {
        AS = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        PS = GetComponent<ParticleSystem>();
        buttonAudio = GetComponent<AudioSource>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    
    private void Update() {
        if (isPlay)
        {
            playTimer += Time.deltaTime;

            if (playTimer < 1)
            {
                AS.volume -= 0.3f * Time.deltaTime;
            }
        }
    }

    private void LoadGame()
    {
        DOTween.KillAll();
        levelManager.LoadGame("GameLevel");
    }
    
    private void OnMouseDown() 
    {
        isPlay = true;
        transform.DOScale(1.2f, 1f).SetLoops(-1, LoopType.Yoyo);
        PS.Play();
        buttonAudio.Play();
        Invoke("LoadGame", 1f);
    }
}
