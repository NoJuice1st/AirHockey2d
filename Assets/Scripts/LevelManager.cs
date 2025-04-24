using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject loadingScreen;
    private float targetScale;
    private string currentScene;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        loadingScreen = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        var pos = loadingScreen.transform.localScale;
        pos.y = math.lerp(loadingScreen.transform.localScale.y, targetScale, 10 * Time.deltaTime);
        loadingScreen.transform.localScale = pos;
    }
    
    public void LoadGame(string levelName)
    {
        targetScale = 5;
        currentScene = levelName;

        Invoke("LoadGameLevel", 0.25f);
    }

    private void LoadGameLevel()
    {
        SceneManager.LoadScene(currentScene);
        ShrinkTransition();
    }

    public void ShrinkTransition()
    {
        targetScale = 0;
    }
}
