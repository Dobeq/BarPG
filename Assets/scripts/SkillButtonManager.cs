using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonManager : MonoBehaviour {
    public Sprite[] Sprites;
    public GameObject skillButtonPrefab;
    public GameObject skillParent;
	// Use this for initialization
	void Start () {
        Transform skillParentI = Instantiate(skillParent).transform;
		for(int i = 0;i < Sprites.Length;i++)
        {
            GameObject toInstantiate = Instantiate(skillButtonPrefab, 
                new Vector3(i % 7 * 32 - 96, i / 7 * 32 - 184), 
                Quaternion.identity, 
                skillParentI);
            toInstantiate.GetComponent<SkillButton>().SetID(i);
            toInstantiate.GetComponent<SkillButton>().SetSprite(Sprites[i]);
        }
	}
	
    
}
