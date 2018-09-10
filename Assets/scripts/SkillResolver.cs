using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillResolver : MonoBehaviour {


    private BarManager barManager;
    private BuffManager buffManager;
    private List<Bar> bars;
    private Bar mana;
    private Bar energy;
    private Bar rage;
    private const float regenStart = 0.25f;
    private float regenTimer;
    public static SkillResolver instance
    {
        get
        {
            if (!skillResolver)
            {
                skillResolver = FindObjectOfType(typeof(SkillResolver)) as SkillResolver;
                skillResolver.Init();

            }
            return skillResolver;
        }
    }
    public static SkillResolver skillResolver;
    void Init()
    {
        bars = BarManager.instance.GetBars();
        mana = bars[0];
        energy = bars[1];
        rage = bars[2];
        regenTimer = 0.25f;
    }
    void Start()
    {
        
    }
    private void Update()
    {
        if(regenTimer <= 0)
        {
            Regen();
            regenTimer = regenStart;
        }
        else
        {
            regenTimer -= Time.deltaTime;
        }
    }
    public void Regen()
    {
        foreach(Bar bar in instance.bars)
        {
            bar.SetCurrR(
                (
                (bar.GetRPerAct() + GetTotalSum(BuffManager.instance.CheckBuffs("regen", "+", bar.GetName())))
                * GetTotalMult(
                    BuffManager.instance.CheckBuffs(
                        "regen", "x", bar.GetName()))
                + bar.GetCurrR()));
            if(bar.GetCurrR() >= 1)
            {
                bar.AddValue((int)bar.GetCurrR());
                while(bar.GetCurrR() >= 1)
                {
                    bar.SetCurrR(bar.GetCurrR() - 1);
                }
                
            }
        }
    }
    public float GetTotalMult(List<Buff> buffs)
    {
        float totalMult = 1;
        foreach(Buff buff in buffs)
        {
            totalMult *= buff.GetValue();
        }
        return totalMult;
    }
    public float GetTotalSum(List<Buff> buffs)
    {
        float totalMult = 0;
        foreach (Buff buff in buffs)
        {
            totalMult += buff.GetValue();
        }
        return totalMult;
    }
    public bool Skill0()
    {
        if(mana.GetValue() >= 4)
        {
            mana.AddValue(-4);
            rage.AddValue(1);
            return true;
        }
        return false;
    }
    public bool Skill1()
    {
        if (energy.GetValue() >= 1)
        {
            energy.AddValue(-1);
            rage.AddValue(3);
            return true;
        }
        return false;
    }
    public bool Skill2()
    {
        if(rage.GetValue() >= 2)
        {
            rage.AddValue(-2);
            //do damage
            return true;
        }
        return false;
    }
    public bool Skill3()
    {
        if(mana.GetValue() >= 10)
        {
            if (BuffManager.CheckBuffExists("skill3"))
            {
                BuffManager.ExtendBuffDuration("skill3", 10.0f);
                mana.AddValue(-10);
                return true;
            }
            mana.AddValue(-10);
            List<string> args = new List<string>();
            args.Add("mana");
            args.Add("3/1");
            args.Add("x");
            BuffManager.MakeBuff("skill3", 10.0f, "regen", args);
            return true;
        }
        return false;
    }
    public bool Skill4()
    {
        if (mana.GetValue() >= 10)
        {
            if (BuffManager.CheckBuffExists("skill4"))
            {
                BuffManager.ExtendBuffDuration("skill4", 10.0f);
                mana.AddValue(-10);
                return true;
            }
            mana.AddValue(-10);
            List<string> args = new List<string>();
            args.Add("energy");
            args.Add("2/1");
            args.Add("x");
            BuffManager.MakeBuff("skill4", 10.0f, "regen", args);
            return true;
        }
        return false;
    }
    public bool Skill5()
    {
        if (mana.GetValue() >= 10)
        {
            if (BuffManager.CheckBuffExists("skill5"))
            {
                BuffManager.ExtendBuffDuration("skill5", 10.0f);
                mana.AddValue(-10);
                return true;
            }
            mana.AddValue(-10);
            List<string> args = new List<string>();
            args.Add("rage");
            args.Add("1/6");
            args.Add("+");
            BuffManager.MakeBuff("skill5", 10.0f, "regen", args);
            return true;
        }
        return false;
    }
}
