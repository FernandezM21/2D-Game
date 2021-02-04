using UnityEngine;
using System.Collections;

public class EnemyJumper : MonoBehaviour
{

	public float forceY = 300f;    //controls how high he jumps
	private Rigidbody2D myRigidbody;    //allows us to apply physics to the jumper
	private Animator myAnimator;    //allows us to have control over animations


	void Awake()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}
	// Use this for initialization
	void Start()
	{
		StartCoroutine(Attack());
	}

	IEnumerator Attack()
	{
		yield return new WaitForSeconds(Random.Range(2, 4));
		forceY = Random.Range(250, 550);
		myRigidbody.AddForce(new Vector2(0, forceY));
		myAnimator.SetBool("attack", true);
		yield return new WaitForSeconds(1.5f);
		myAnimator.SetBool("attack", false);
		StartCoroutine(Attack());
	}


	void OnTriggerEnter2D(Collider2D target)
	{

		if (target.tag == "bullet")
		{
			Destroy(gameObject);
			Destroy(target.gameObject);
		}
	}

}
