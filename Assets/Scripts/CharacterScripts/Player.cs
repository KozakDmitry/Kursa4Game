using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int strength { get => strength; set => strength = value; }
    private int agility { get => agility; set => agility = value; }
    private int vulnerable { get => vulnerable; set => vulnerable = value; }
    private int speed { get => speed; set => speed = value; }
    private int powerOfWill { get => powerOfWill; set => powerOfWill = value; }
    private int charisma { get => charisma; set => charisma = value; }

    private int damage { get => damage; }
    private int defence { get => defence; }
    private int accuracy { get => accuracy; }
    private int health { get => health; }
    private int initiative { get => initiative; }
    private int powerOfSpell { get => powerOfSpell; set => charisma = value; }
    private int mentalDefence { get => mentalDefence; set => mentalDefence = value; }

    private int lifeCounts = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeCounts = lifeCounts++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
