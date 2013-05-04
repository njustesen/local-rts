using System.Collections;
using System;

public class Timer
{
    public bool Pause
    {
        get;
        set;
    }

    public bool IsActive
    {
        get;
        private set;
    }

    public bool IsTimeUp
    {
        get;
        private set;
    }

    private float elapsedTime;
    private float shouldRunFor;
    private Action callback;

    public Timer()
    {

    }

    public Timer(float time )
    {
        Start(time);
    }

    public Timer(float time, Action callback)
    {
        Start(time, callback);
    }

    public void Start(float time, Action callback)
    {
        this.callback = callback;
        IsActive = true;
        IsTimeUp = false;
        Pause = false;
        shouldRunFor = time;
        elapsedTime = 0;
    }

    public void Start(float time)
    {
        IsActive = true;
        IsTimeUp = false;
        Pause = false;
        shouldRunFor = time;
        elapsedTime = 0;
    }

    public void Stop()
    {
        IsActive = false;
        IsTimeUp = false;
    }

    // Update is called once per frame
    public void Update(float dtime)
    {
        if (IsActive && !Pause)
        {
            elapsedTime += dtime;
            if (elapsedTime > shouldRunFor)
            {
                if (callback != null)
                    callback();
                IsActive = false;
                IsTimeUp = true;
            }
        }
    }
}
