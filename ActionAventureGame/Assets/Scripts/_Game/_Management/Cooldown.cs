using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    private float nextTime;
    private float lastTime;
    public float cooldownTime;

    public Cooldown(float _coolTime = 0f, bool readyOnStart = true)
    {
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
        return Time.time >= nextTime;
    }

    public void Reset()
    {
        nextTime = Time.time + cooldownTime;
        lastTime = Time.time;
    }

    public void SetOver()
    {
        nextTime = Time.time;
        lastTime = Time.time;
    }
}