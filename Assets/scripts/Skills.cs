using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Skills{
    public static void UseSkill(int ID)
    {
        SkillResolver resolver = SkillResolver.instance;
        bool resolved = false;
        /**
         * 3 bars - mana rage energy
         * energy 1/3 act mana 2/1 act
         * rage from generators
         * all cap at 10
         * 
         * enemy interaction - heals, interrupts, phasing
         * 
         * */
        if (ID == 0)
        {
            if (resolver.Skill0())
            {
                resolved = true;
            }
        }
        else if(ID == 1)
        {
            if (resolver.Skill1())
            {
                resolved = true;
            }
        }
        else if(ID == 2)
        {
            if (resolver.Skill2())
            {
                resolved = true;
            }
        }
        else if(ID == 3)
        {
            if (resolver.Skill3())
            {
                resolved = true;
            }
        }
        else if(ID == 4)
        {
            if (resolver.Skill4())
            {
                resolved = true;
            }
        }
        else if (ID == 5)
        {
            if (resolver.Skill5())
            {
                resolved = true;
            }
        }
        /**
        else if (ID == 6)
        {
            Skill6();
        }
        else if (ID == 7)
        {
            Skill7();
        }
        else if (ID == 8)
        {
            Skill8();
        }
        else if (ID == 9)
        {
            Skill9();
        }
        else if (ID == 10)
        {
            Skill10();
        }
        else if (ID == 11)
        {
            Skill11();
        }
        else if (ID == 12)
        {
            Skill12();
        }
    **/
        if (ID == 13)
        {
            resolved = true;
        }
        if (resolved)
        {
        }
        
    }
}
