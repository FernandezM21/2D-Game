using UnityEngine;
using System.Collections;

public class HorizontalBullet : MonoBehaviour
{
	private Rigidbody2D myRigidbody;
	public float speed = 2f;

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
		//this checks to see if the bullet touches the ground, then unloads the bullet if it touches ground.
		if (target.gameObject.tag == "Ground")
		{
			Destroy(gameObject);
		}
		if (target.gameObject.tag == "HorizontalBullet")
		{
			Destroy(gameObject);
		}
	}
	void FixedUpdate()
	{
		Move();
	}

	void Move()
	{
		myRigidbody.velocity = new Vector2(transform.localScale.x, 0) * speed;
	}
}




