using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : BattleMember
{
    // Start is called before the first frame update
    void Awake()
    {
        mood = 1;
        strength = 15;
        agility = 10;
        vulnerable = 20;
        speed = 9;
        powerOfWill = 10;
        charisma = 6;
        CountStats();
    }

    public override void Spell(List<GameObject> properties)
    {
        defence += powerOfWill;
        couldown = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
