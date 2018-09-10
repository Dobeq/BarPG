using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RegenBuff : Buff {
    private string bar;
    private float regen;
    private float duration;
    private string combine;
    public RegenBuff(string name, float duration, string type, List<string> misc) : base(name, duration, type, misc)
    {
        bar = misc[0];
        string misc1 = misc[1];
        int slash = misc1.IndexOf("/");
        regen = (float)Int32.Parse(misc1.Substring(0, slash)) / Int32.Parse(misc1.Substring(slash + 1));
        combine = misc[2];
        this.duration = duration;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
    public string GetBar()
    {
        return bar;
    }
    public override float GetValue()
    {
        return regen;
    }
    public string GetCombine()
    {
        return combine;
    }
}
