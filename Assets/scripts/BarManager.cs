using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour {
	public GameObject barPart;
    public List<Bar> bars = new List<Bar>();
    public GameObject bar;
    public float manaRegen;
    public float energyRegen;
    public float rageRegen;
    public static BarManager instance
    {
        get
        {
            if (!barManager)
            {
                barManager = FindObjectOfType(typeof(BarManager)) as BarManager;
                barManager.Init();

            }
            return barManager;
        }
    }
    public static BarManager barManager;
    // Use this for initialization
    void Init()
    {
        
    }
    void Awake () {
        MakeBar(20, 20, manaRegen, name: "mana");
        MakeBar(10, 0, energyRegen, y: 1, name: "energy");
        MakeBar(20, 0, rageRegen, y: 2, name: "rage");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MakeBar(int length, int curr, float rPerAct, int x = 0, int y = 0, string name = "")
    {
        Transform parent = Instantiate(bar).transform;
        List<GameObject> barParts = new List<GameObject>();
        for (int i = 0;i < length; i++)
        {
            //for the weird numbers - 0.7 is to fit the stretch
            //-112 and 197 are to fit the camera
            //160 is due to sprites being 160/10 units
            barParts.Add(Instantiate(barPart, 
                new Vector3(-112 + (i + x) * (160 / length * 1.4f),197 - y * 9), 
                Quaternion.identity, 
                parent));
            barParts[barParts.Count - 1].transform.localScale = new Vector3(1.4f * 10 / length, 1.0f);
            if(i >= curr)
            {
                barParts[barParts.Count - 1].SetActive(false);
            }
        }
        bars.Add(new Bar(length, curr, rPerAct, barParts, name));
    }
    public List<Bar> GetBars()
    {
        return bars;
    }
    public void SetManaRegen(float regen)
    {
        this.manaRegen = regen;
    }
    public void SetEnergyRegen(float regen)
    {
        this.energyRegen = regen;
    }
    public void SetRageRegen(float regen)
    {
        this.rageRegen = regen;
    }
    public Bar GetByName(string name)
    {
        foreach(Bar bar in bars)
        {
            if(bar.GetName() == name)
            {
                return bar;
            }
        }
        return new Bar(0, 0, 0, new List<GameObject>(), "NoSuchBar");
    }
}
