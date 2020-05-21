using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMember : MonoBehaviour
{
    public int strength { get; set; }
    public int agility { get; set; }
    public int vulnerable { get; set; }
    public int speed { get; set; }
    public int powerOfWill { get; set; }
    public int charisma { get;set; }

    public int damage { get; set; }
    public int defence { get; set; }
    public int accuracy { get; set; }
    public int health { get; set; }
    public int initiative { get; set; }
    public int powerOfSpell { get; set; }
    public int mentalDefence { get; set; }

    public int couldown { get; set; }
    public int maxHealth { get; set; }

    private Animator animator;

    public int mood;
    private int level = 1;
    private void Awake()
    {
        couldown = 4;
        CountStats();
        
 
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            animator.SetTrigger("Death");
        }

    }
    public void CountStats()
    {
        damage = strength * 5 + level + charisma;
        defence = agility * 2 + level;
        accuracy = agility*4 + level + charisma;
        health = vulnerable * 10 + level;
        initiative = speed * 2 + charisma;
        powerOfSpell = powerOfWill * 5 + level + charisma;
        mentalDefence = powerOfWill * 2 + level;
        maxHealth = health;
    }

    public virtual void Spell(List<GameObject> properties)
    {

    }
}
