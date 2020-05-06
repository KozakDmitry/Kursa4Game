using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCharacter : MonoBehaviour
{
    protected int strength { get => strength; set => strength = value; }
    protected int agility { get => agility; set => agility = value; }
    protected int vulnerable { get => vulnerable; set => vulnerable = value; }
    protected int speed { get => speed; set => speed = value; }
    protected int powerOfWill { get => powerOfWill; set => powerOfWill = value; }
    protected int charisma { get => charisma; set => charisma = value; }

    protected int damage { get => damage; set => damage = value; }
    protected int defence { get => defence; set => defence = value; }
    protected int accuracy { get => accuracy; set => accuracy = value; }
    protected int health { get => health; set => health = value; }
    protected int initiative { get => initiative; set => initiative = value; }
    protected int powerOfSpell { get => powerOfSpell; set => powerOfSpell = value; }
    protected int mentalDefence { get => mentalDefence; set => mentalDefence = value; }
}
