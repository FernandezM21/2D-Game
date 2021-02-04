using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	public float movementSpeed;

	private bool facingRight;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private float jumpForce;

	public bool imAlive;

	public GameObject reset;

	private Slider healthBar;

	public float health = 10f;

	private float healthBurn = 5f;

	void Start()
	{

		facingRight = true;

		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
		imAlive = true;
		reset.SetActive(false);
		healthBar = GameObject.Find("health slider").GetComponent<Slider>();
		healthBar.minValue = 0f;
		healthBar.maxValue = health;
		healthBar.value = healthBar.maxValue;
	}

	void Update()
	{
		HandleInput();
	}

	void FixedUpdate()

	{
		if (imAlive)
		{
			float horizontal = Input.GetAxis("Horizontal");
			HandleMovement(horizontal);
			Flip(horizontal);
			isGrounded = IsGrounded();
		}
	}



	private bool IsGrounded()
	{
		if (myRigidbody.velocity.y <= 0)
		{
			//if player is not moving vertically test each of Player’s groundpoints for contact with the Ground
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject)
					//if any of the groundpoints is in contact(collides) with anything other than the Player, return true
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void HandleMovement(float horizontal)
	{
		if (isGrounded && jump)
		{
			isGrounded = false;
			jump = false;
			myRigidbody.AddForce(new Vector2(0, jumpForce));
		}
		myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
		myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));
	}
	private void Flip(float horizontal)
	{

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}

	}

	private void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
			Debug.Log("I'm jumping!");
			myAnimator.SetBool("jumping", true);
		}
	}
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Ground")
		{
			myAnimator.SetBool("jumping", false);
		}

		if (target.gameObject.tag == "deadly")
		{
			ImDead();
		}

		if (target.gameObject.tag == "damage")
		{
			UpdateHealth();
		}
	}
			//this function will be called when player collides with an enemy
			void UpdateHealth()
			{
				if (health > 0)
				{
					health -= healthBurn; //current value of health minus 2f
					healthBar.value = health;  //update the interface slider
				}
				if (health <= 0) {
					ImDead();
				}
			}
			public void ImDead() {
				myAnimator.SetBool("dead", true);
				imAlive = false;
				reset.gameObject.SetActive(true);
			}
		

}

