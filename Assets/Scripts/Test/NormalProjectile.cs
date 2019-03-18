using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : BaseProjectile
{
	private Vector3 _direction;

	private bool fired;
	// Update is called once per frame
	void Update () {
		if (fired)
		{
			transform.position += _direction * (speed * Time.deltaTime);
			StartCoroutine(fired);

		}
		
	}


	public override void FireProjectile(GameObject launcher, GameObject target, int damage)
	{
		if (launcher && target)
		{
			_direction = (target.transform.position - launcher.transform.position).normalized;
			fired = true;
		}
	}
	
}
