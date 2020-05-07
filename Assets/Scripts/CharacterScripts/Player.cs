using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : AbstractCharacter
{
   
    private int lifeCounts = 0;
    private int level = 1;
	private float playerspeed = 10.0f;
	private bool isDead = false;
	private bool isFacingRight = true;
	private Rigidbody2D rb;
	private Animator animator;
	private Vector2 moveVelocity;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		lifeCounts = lifeCounts++;

    }

    private void CountStats()
    {
        damage = strength * 5 + level + charisma / 4;
        defence = agility * 2 + level;
        accuracy = agility + level + charisma / 4;
        health = vulnerable * 10 + level * 5;
        initiative = speed * 2 + charisma / 4;
        powerOfSpell = powerOfWill * 5 + level + charisma / 4;
        mentalDefence = powerOfWill * 2 + level;
    }

	private void Flip()
	{
		//меняем направление движения персонажа
		isFacingRight = !isFacingRight;
		//получаем размеры персонажа
		Vector3 theScale = transform.localScale;
		//зеркально отражаем персонажа по оси Х
		theScale.x *= -1;
		//задаем новый размер персонажа, равный старому, но зеркально отраженный
		transform.localScale = theScale;
	}

	// Update is called once per frame
	void Update()
    {
		Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveinput.normalized * playerspeed;
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
	}
}
