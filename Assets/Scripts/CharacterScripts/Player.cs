using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private int level = 1;
	private float playerspeed = 10.0f;
	public static int artifact = 0;
	private Rigidbody2D rb;
	private Animator animator;
	private Vector2 moveVelocity;
	public List<GameObject> squad;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public static void SetArtifact()
	{
		artifact = 1;
	}
	// Update is called once per frame
	void Update()
	{
		Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveinput.normalized * playerspeed;
		

		if (moveinput.x > 0)
		{	
				animator.SetBool("IsFacingRight",true);
				animator.SetBool("IsFacingDown", false);
				animator.SetBool("IsFacingUp", false);
				animator.SetBool("IsFacingLeft", false);
		}
		else
			if (moveinput.y < 0)
			{
				animator.SetBool("IsFacingRight", false);
				animator.SetBool("IsFacingDown", true);
				animator.SetBool("IsFacingUp", false);
				animator.SetBool("IsFacingLeft", false);
			}
			else
				if (moveinput.y > 0)
				{

					animator.SetBool("IsFacingRight", false);
					animator.SetBool("IsFacingDown", false);
					animator.SetBool("IsFacingUp", true);
					animator.SetBool("IsFacingLeft", false);
				}
				else
					if (moveinput.x < 0)
					{
						animator.SetBool("IsFacingRight", false);
						animator.SetBool("IsFacingDown", false);
						animator.SetBool("IsFacingUp", false		);
						animator.SetBool("IsFacingLeft", true);
					}
					else
						if (moveinput.x == 0 && moveinput.y==0)
						{
						animator.SetBool("IsFacingRight", false);
						animator.SetBool("IsFacingDown", false);
						animator.SetBool("IsFacingUp", false);
						animator.SetBool("IsFacingLeft", false);
						}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
		
	}


}
