using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    public GameObject barrier1;
    public GameObject barrier2;
    public GameObject player;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void Easy()
    {
        barrier1.GetComponent<BarrierMove>().difficulty = 0;
        barrier2.GetComponent<BarrierMove>().difficulty = 0;
        DestroyAll();
    }

    public void Medium()
    {
        barrier1.GetComponent<BarrierMove>().difficulty = 1;
        barrier2.GetComponent<BarrierMove>().difficulty = 1;
        DestroyAll();
    }
    public void Hard()
    {
        barrier1.GetComponent<BarrierMove>().difficulty = 2;
        barrier2.GetComponent<BarrierMove>().difficulty = 2;
        DestroyAll();
    } 


    private void DestroyAll()
    {
        var buttons = GameObject.FindGameObjectsWithTag("DifficultySetting");
        foreach( var b in buttons)
            Destroy(b);
        player.SetActive(true);
    }
}
