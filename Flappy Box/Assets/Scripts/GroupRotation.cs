using UnityEngine;
using System.Collections;

/// <summary>
/// rotate a set of gameobjects togother.
/// </summary>
public class GroupRotation : MonoBehaviour
{
		public GameObject[] group;//group references
		public bool isRunning = true;
		public float rotationSpeed = 2;
		private Transform tran;//transform
		private Vector3 rot;//rotation

		// Update is called once per frame
		void Update ()
		{
				if (!isRunning) {
						return;
				}
				group = GameObject.FindGameObjectsWithTag ("candy");
				if (group == null) {
						return;
				}
				//start rotating group elements
				foreach (GameObject ob in group) {
						tran = ob.transform;
						rot = tran.eulerAngles;
						rot.z += rotationSpeed * Time.deltaTime;
						tran.eulerAngles = rot;
				}
				
		}
}
