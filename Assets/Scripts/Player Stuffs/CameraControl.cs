using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

	public GameObject Player;

	private Vector3 _offset;
	
	// Creates the offset so the camera isn't inside the player and stays a distance away.
	private void Start ()
	{
		_offset = transform.position - Player.transform.position;
	}
	
	// Moves the camera with the player
	private void Update ()
	{
		transform.position = Player.transform.position + _offset;
	}
}
