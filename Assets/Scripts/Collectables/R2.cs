using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2 : MonoBehaviour {

	void Update () 
	{
		transform.Rotate(new Vector3(30, 60, 90) * Time.deltaTime);
	}
}