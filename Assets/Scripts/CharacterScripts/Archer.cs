using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : BattleMember
{

    
    // Start is called before the first frame update
    void Awake()
    {
        mood = 1;
        strength = 10;
        agility = 25;
        vulnerable = 10;
        speed = 15;
        powerOfWill = 2;
        charisma = 8;
        CountStats();
    }

    public override void Spell(List<GameObject> properties)
    {
        BattleMember bt = properties[0].GetComponent<BattleMember>();
        for (int i = 0; i <3;i++)
            if ((accuracy - bt.agility / 2) - Random.Range(0, 100) > 0)
            {
                bt.health -= powerOfSpell - bt.powerOfWill / 2;
            }
        couldown = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
