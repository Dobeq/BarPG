using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BuffManager : MonoBehaviour {
    //make buffs, have them tick, kill them(?)
    // Use this for initialization
    private List<Buff> buffs;
    private List<Buff> toDestroy;
    public static BuffManager instance
    {
        get
        {
            if (!buffManager)
            {
                buffManager = FindObjectOfType(typeof(BuffManager)) as BuffManager;
                buffManager.Init();
               
            }
            return buffManager;
        }
    }
    private static BuffManager buffManager;
    // Update is called once per frame
    private void Init()
    {
        buffs = new List<Buff>();
        toDestroy = new List<Buff>();
    }
    void Update () {
		foreach(Buff buff in instance.buffs)
        {
            buff.Update();
        }
        foreach (Buff buff in instance.toDestroy)
        {
            instance.buffs.Remove(buff);
        }
    }
    public static void MakeBuff(string name, float duration, string type, List<string> misc = null)
    {
        if(type == "regen")
        {
            instance.buffs.Add(new RegenBuff(name, duration, type, misc));
        }
    }
    public List<Buff> CheckBuffs(string type, string misc)
    {
        List<Buff> outList = new List<Buff>();
        if(type == "regen")
        {
            if(instance.buffs == null)
            {
                return outList;
            }
            foreach(Buff buff in instance.buffs)
            {
                if(buff.GetType().Name == "RegenBuff")
                {
                    RegenBuff rbuff = (RegenBuff)buff;
                    if(rbuff.GetBar() == misc)
                    {
                        outList.Add(buff);
                    }
                    
                }
            }
        }
        return outList;
    }
    public List<Buff> CheckBuffs(string type, string misc1, string misc2)
    {
        List<Buff> outList = new List<Buff>();
        if (type == "regen")
        {
            if (instance.buffs == null)
            {
                return outList;
            }
            foreach (Buff buff in instance.buffs)
            {
                if (buff.GetType().Name == "RegenBuff")
                {
                    RegenBuff rbuff = (RegenBuff)buff;
                    if (rbuff.GetBar() == misc2)
                    {
                        if(rbuff.GetCombine() == misc1)
                        {
                            outList.Add(buff);
                        }
                        
                    }

                }
            }
        }
        return outList;
    }
    public static void Expire(string name)
    {
        foreach(Buff buff in instance.buffs)
        {
            if(buff.GetName() == name)
            {
                instance.toDestroy.Add(buff);
            }
        }
    }
    public static bool CheckBuffExists(string name)
    {
        if(instance.buffs == null)
        {
            return false;
        }
        foreach(Buff buff in instance.buffs)
        {
            if(buff.GetName() == name)
            {
                return true;
            }
        }
        return false;
    }
    public static void ExtendBuffDuration(string name, float duration)
    {
        foreach(Buff buff in instance.buffs)
        {
            if(buff.GetName() == name)
            {
                buff.AddDuration(duration);
            }
        }
    }
}
