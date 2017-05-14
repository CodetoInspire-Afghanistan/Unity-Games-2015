using UnityEngine;
using System.Collections;

/// <summary>
/// Destroy a gameobject after the given time.
/// </summary>
public class Destroy : MonoBehaviour
{
		public float destroyTime = 1;

		// Use this for initialization
		void Start ()
		{
				Destroy (gameObject, destroyTime);
		}
}
