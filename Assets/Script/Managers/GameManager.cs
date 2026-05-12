using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum InputKeys
    {
        WASD, ARROW
    }
    public static GameManager Instance { get; private set; }
    private int nextPlayerId = 1;

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
    // =========================
    // CAMBIO DE ESCENAS
    // =========================

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ReloadScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public int GetNextPlayerId()
    {
        return nextPlayerId++;
    }

    public Player SpawnPlayerWithId(GameObject prefab, string controlScheme, Vector3 position)
    {
        PlayerInput input = PlayerInput.Instantiate(
            prefab,
            controlScheme: controlScheme,
            pairWithDevice: Keyboard.current
        );

        input.transform.position = position;

        Player player = input.GetComponent<Player>();

        return player;
    }
}
