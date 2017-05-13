using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere (this.transform.position, 6);
		Gizmos.color = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
