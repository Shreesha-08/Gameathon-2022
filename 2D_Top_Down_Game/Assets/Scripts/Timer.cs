using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float timeStart;

    public bool timerActive = false; //set timerActive to true when game scene starts

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeStart = 0;
    }

    void Update()
    {
        if (timerActive) //set timerActive to false if game is paused
        {
            timeStart += Time.deltaTime;
        }
    }
}
