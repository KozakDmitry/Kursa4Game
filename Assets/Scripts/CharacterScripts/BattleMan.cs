using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMan : BattleMember
{
    // Start is called before the first frame update
    void Awake()
    {
        mood = 1;
        strength = 25;
        agility = 9;
        vulnerable = 15;
        speed = 5;
        powerOfWill = 15;
        charisma = 1;
        CountStats();
    }

    public override void Spell(List<GameObject> properties)
    {
        foreach(GameObject enemy in properties)
        {
            BattleMember bt = enemy.GetComponent<BattleMember>();
            if ((accuracy - bt.agility / 2) - Random.Range(0, 100) > 0)
            {
                bt.health = powerOfSpell - bt.powerOfWill / 2;
            }
        }
        couldown = 5;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
