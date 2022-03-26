using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
        
    }
}
