using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    [HideInInspector]
    public bool isStopped;
    private float nextTime;
    private float lastTime;
    public float cooldownTime;

    public Cooldown(float _coolTime = 0f, bool readyOnStart = true)
    {
        isStopped = false;
        lastTime = 0;
        cooldownTime = _coolTime;
        if (!readyOnStart)
            Reset();
    }

    public void SetCooldown(float _time)
    {
        lastTime = 0;
        cooldownTime = _time;
    }

    public float GetElapsed()
    {
        return Time.time - lastTime;
    }

    public float TimeUntillOver()
    {
        return nextTime - Time.time;
    }

    public bool IsOver()
    {
        return (isStopped ? false : Time.time >= nextTime);
    }

    public void Reset()
    {
        isStopped = false;
        nextTime = Time.time + cooldownTime;
        lastTime = Time.time;
    }

    public void SetOver()
    {
        nextTime = Time.time;
        lastTime = Time.time;
    }
}