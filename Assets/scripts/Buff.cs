using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public abstract class Buff{
    private string name;
    private float duration;
    private string type;
    private float startDuration;
    public Buff(string name, float duration, string type, List<string> misc = null)
    {
        this.name = name;
        this.duration = duration;
        this.startDuration = duration;
        this.type = type;
    }
    // Update is called once per frame
    public void Update() {
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            this.Remove();
        }
        if(duration > startDuration * 1.5f)
        {
            duration = startDuration * 1.5f;
        }
    }
    public void Remove()
    {
        BuffManager.Expire(this.name);
    }
    public virtual float GetValue()
    {
        return -1;
    }
    public string GetName()
    {
        return this.name;
    }
    public float GetDuration()
    {
        return duration;
    }
    public void SetDuration(float duration)
    {
        this.duration = duration;
    }
    public void AddDuration(float duration)
    {
        this.duration += duration;
    }
}
