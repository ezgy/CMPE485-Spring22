using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
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
