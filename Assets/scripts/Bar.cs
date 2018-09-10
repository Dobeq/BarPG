using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar {
    private int max;
    private int curr;
    private string name;
    private List<GameObject> parts;
    private float rPerAct;
    private float currR;
    public Bar(int max, int curr, float rPerAct, List<GameObject> parts, string name)
    {
        this.max = max;
        this.curr = curr;
        this.parts = parts;
        this.name = name;
        this.rPerAct = rPerAct;
        this.currR = 0.0f;
    }
    public void SetValue(int value) {
        if (value>= 0 && value <= max)
        {
            if (value > curr)
            {
                for (int i = curr; i < value; i++)
                {
                    parts[i].SetActive(true);
                }
            }
            else if (value < curr)
            {
                for (int i = value; i < curr; i++)
                {
                    parts[i].SetActive(false);
                }
            }
            this.curr = value;
        }
    }
    public int GetValue()
    {
        return this.curr;
    }
    public void AddValue(int value)
    {
        this.SetValue(this.GetValue() + value);
    }
    public float GetRPerAct()
    {
        return this.rPerAct;
    }
    public void SetCurrR(float r)
    {
        this.currR = r;
    }
    public float GetCurrR()
    {
        return this.currR;
    }
    public string GetName()
    {
        return this.name;
    }
    public void SetRPerAct(float rPerAct)
    {
        this.rPerAct = rPerAct;
    }
}
