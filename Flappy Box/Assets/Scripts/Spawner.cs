using UnityEngine;
using System.Collections;

/// <summary>
/// GameObjects Spawner.
/// </summary>
public class Spawner : MonoBehaviour
{
		public bool isRunning = true;
		public bool createInstanceAtStart = true;//do you want to create an instance at the Start
		public GameObject[] prefabs;//prefabs
		public string instanceName = "";//instance name
		public Transform instanceParent;//instance parent
		public Vector2 delayTime = Vector2.one;//insantiate delay time
		public Vector3 eulerAngles;//euler angle
		private GameObject instance;

		private IEnumerator Start ()
		{
				if (createInstanceAtStart) {
						CreateInstance ();
				}

				while (true) {
						if (isRunning) {
								yield return new WaitForSeconds (Random.Range (delayTime.x, delayTime.y));
								if (isRunning) {
										CreateInstance ();
								}
						} else {
								yield return new WaitForSeconds (0.5f);
						}
				}
		}

	//instantiate or create new instance
		public void CreateInstance ()
		{
				if (prefabs == null) {
						return;
				}

				GameObject pref = GetRandomPrefab ();
				instance = Instantiate (pref, transform.position, Quaternion.identity) as GameObject;
				if (instanceParent != null) {
						instance.transform.parent = instanceParent;
				}
				if (!string.IsNullOrEmpty (instanceName)) {
						instance.name = instanceName;
				}
		}

	//get a random prefab
		private GameObject GetRandomPrefab ()
		{
				if (prefabs == null) {
						return null;
				}

				return prefabs [Random.Range (0, prefabs.Length)];
		}
}