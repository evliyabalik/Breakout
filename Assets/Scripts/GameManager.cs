using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject m_gameoverPanel;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null || instance != this)
            instance = this;
        else
            Destroy(instance);

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        GameOver(false);
    }

    public void GameOver(bool isActive)
    {
        m_gameoverPanel.SetActive(isActive);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
