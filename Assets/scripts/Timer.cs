using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float totalSeconds = 0f;
    private float elapsedSeconds = 0f;
    private bool running = false;
    private bool started = false;



    public void Run()
    {
        if (totalSeconds > 0)
        {
            running = true;
            started = true;
            elapsedSeconds = 0;
        }
    }

    #region property

    

    
    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    public bool Finished
    {
        get { return started && !running;  }
    }

    public bool Running
    {
        get { return running; } 
    }

    #endregion
        
    

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }
}
