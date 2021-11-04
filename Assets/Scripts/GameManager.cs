using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    #endregion

    void Awake()
    {
        Physics.gravity = Vector3.down * 18f; //Set initial gravity
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [RuntimeInitializeOnLoadMethod] //Se llama cuando inicia el juego, solo afecta la primera funcion de abajo de ella
    static void AutoCreate()
    {
        if (!SceneManager.GetActiveScene().name.Equals(K.Scene.gameOver))
        {
            _instance = new GameObject("GameManager").AddComponent<GameManager>();
                    DontDestroyOnLoad(_instance.gameObject);
        }
    }

    //It will be called when the win condition is met
    public void GameFinished()
    {
        SceneManager.LoadScene(K.Scene.gameOver);
    }

    public void Play()
    {
        SceneManager.LoadScene(K.Scene.alam);
    }
}
