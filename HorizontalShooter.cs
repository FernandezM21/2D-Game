using UnityEngine;
using System.Collections;

public class HorizontalShooter : MonoBehaviour
{

	[SerializeField]
	private GameObject bullet;
	float fireRate;
	float nextFire;

	void Start()
	{
		fireRate = 2f;
		nextFire = Time.time;
	}

	void Update()
	{
		CheckIfTimeToFire();
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;

		}


	}


}

