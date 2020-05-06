using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : AbstractCharacter
{
    [SerializeField]
    private Sprite modelPlayer;
    private int lifeCounts = 0;
    private int level = 1;
	private float movementSpeed = 100.0f;
	private Animator animator;
	private Vector3 lastPosition;
	private Vector3 CheckPointPosition;
	private bool isDead = false;

	// Start is called before the first frame update
	void Start()
    {
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
    

    // Update is called once per frame
    void Update()
    {
		// get the input this frame
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		// if there is no input then stop the animation
		if ((vertical == 0.0f) && (horizontal == 0.0f))
		{
			animator.speed = 0.0f;
		}

		// reset the velocity each frame
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		// horizontal movement, left or right, set animation type and speed 
		if (horizontal > 0)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed * Time.deltaTime, 0);
			animator.SetInteger("Direction", 1);
			animator.speed = 0.5f;
		}
		else if (horizontal < 0)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-movementSpeed * Time.deltaTime, 0);
			animator.SetInteger("Direction", 3);
			animator.speed = 0.5f;
		}

		// vertical movement, up or down, set animation type and speed 
		if (vertical > 0)
		{
			//transform.Translate(0, movementSpeed * 0.9f * Time.deltaTime, 0);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, movementSpeed * Time.deltaTime);
			animator.SetInteger("Direction", 0);
			animator.speed = 0.35f;
		}
		else if (vertical < 0)
		{
			//transform.Translate(0, -movementSpeed *  0.9f * Time.deltaTime, 0);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -movementSpeed * Time.deltaTime);
			animator.SetInteger("Direction", 2);
			animator.speed = 0.35f;
		}

		//compare this position to the last known one, are we moving?
		if (this.transform.position == lastPosition)
		{
			// we aren't moving so make sure we dont animate
			animator.speed = 0.0f;
		}

		// get the last known position
		lastPosition = transform.position;

		// if we are dead do not move anymore
		if (isDead == true)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
			animator.speed = 0.0f;
		}
	}
}
