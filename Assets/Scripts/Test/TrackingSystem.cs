using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour {
 
	public float speed = 3.0f;
		public GameObject  _target = null;
		Vector3 _lastknownposition =  Vector3.zero;
	 Quaternion lookrotation;
	
	// Update is called once per frame
	void Update () {
		if (_lastknownposition != _target.transform.position)
		{
			_lastknownposition = _target.transform.position;
			lookrotation = Quaternion.LookRotation(_lastknownposition - transform.position);
		}
		if (transform.rotation != lookrotation)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, lookrotation, speed * Time.deltaTime);
		}
		
	}

	bool SetTarget(GameObject target)
	{
		if (target)
		{
			return false;
		}

		_target = target;
		return true;


	}
	
}






