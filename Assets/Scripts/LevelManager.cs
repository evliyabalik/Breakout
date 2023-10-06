using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] GameObject m_breakablePrefab;
    [SerializeField] Vector2 m_size;
    [SerializeField] Vector2 m_offset;

    private void Awake()
    {
        if (instance != this)
            instance = this;
    }

    private void Start()
    {
        StartCoroutine(IsWin());
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }


    [ContextMenu(nameof(Create))]
    public void Create()
    {
        for (int x = 0; x < m_size.x; x++)
        {
            for (int y = 0; y < m_size.y; y++)
            {
                var sizeX = x * m_offset.x;
                var sizeY = y * m_offset.y;

                var position = new Vector3(sizeX, sizeY, 0);
                var breakable = Instantiate(m_breakablePrefab, position, Quaternion.identity);
                breakable.transform.SetParent(transform);
            }
        }
    }

    [ContextMenu(nameof(RemoveChild))]
    void RemoveChild()
    {
        var tempArray = new GameObject[transform.childCount];

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = transform.GetChild(i).gameObject;
        }

        foreach (var item in tempArray)
        {
            DestroyImmediate(item);
        }
    }

    public void Win()
    {
        print("Win");
        Time.timeScale = 0;
    }

    IEnumerator IsWin()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();


            if (transform.childCount <= 0)
            {
                Win();
                break;
            }


        }
    }
}
