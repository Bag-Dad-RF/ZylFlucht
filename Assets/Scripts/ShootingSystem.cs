using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
	public float firerate;
	public int damage;
	public float fieldofview;
	public bool beam;
	public GameObject projectile;
	public GameObject target;
	public List<GameObject> projectilespawn;
	
	List<GameObject> _lastprojectile = new List<GameObject>();
	private float _firetimer;
	

	
	// Update is called once per frame
	void Update ()
	{
		if (beam && _lastprojectile.Count <= 0)
		{
			float angle = Quaternion.Angle(transform.rotation,
				Quaternion.LookRotation(target.transform.position - transform.position));

			if (angle < fieldofview)
			{
				SpawnProjectile();
			}
		}else if (beam && _lastprojectile.Count > 0)
		{
			float angle = Quaternion.Angle(transform.rotation,
				Quaternion.LookRotation(target.transform.position - transform.position));
			if (angle > fieldofview)
			{
				
				while (_lastprojectile.Count > 0)
				{
					Destroy(_lastprojectile[0]);
					_lastprojectile.RemoveAt(0);
				}
				
			}
		}
		else
		{
			_firetimer += Time.deltaTime;
			if (_firetimer >= firerate)
			{
				float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
				if (angle < fieldofview)
				{
					SpawnProjectile();
					_firetimer = 0.0f;
				}

			}
		}
	}

	void SpawnProjectile()
	{
		if (!projectile)
		{
			return;
		}
		_lastprojectile.Clear();

		for (int i = 0; i < projectilespawn.Count; i++)
		{
			if (projectilespawn[i])
			{
				GameObject proj = Instantiate(projectile, projectilespawn[i].transform.position, Quaternion.Euler(projectilespawn[i].transform.forward)) ;
				proj.GetComponent<BaseProjectile>().FireProjectile(projectilespawn[i], target, damage);
				_lastprojectile.Add(proj);
			}
			
		}
		
	}
	
}




