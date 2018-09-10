using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour {
    private int ID;
    public void SetID(int ID)
    {
        this.ID = ID;
    }
    public void SetSprite(Sprite sprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    private void OnMouseDown()
    {
        Skills.UseSkill(ID);
    }
}
