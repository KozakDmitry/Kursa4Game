using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : BattleMember
{
    // Start is called before the first frame update
    void Awake()
    {
        mood = 0;
        strength = 25;
        agility = 15;
        vulnerable = 20;
        speed = 3;
        powerOfWill = 15;
        charisma = 0;
        CountStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
