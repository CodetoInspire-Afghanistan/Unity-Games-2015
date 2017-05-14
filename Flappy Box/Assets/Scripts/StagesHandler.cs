using UnityEngine;
using System.Collections;

/// <summary>
/// Stages scene handler.
/// </summary>
public class StagesHandler : MonoBehaviour
{
		// Use this for initialization
		IEnumerator Start ()
		{
				if (StorageManager.StagesStorageHelper.stagesDataRoot != null) {
						//apply data to stage elements in the scene
						StorageManager.StagesStorageHelper.ApplyDataToStageElementsInScene (StorageManager.StagesStorageHelper.stagesDataRoot.stagesParts);
				} else {
						Debug.Log ("StorageManager.StagesStorageHelper.stagesDataRoot is undefined");
				}

				GameObject loadingDots = GameObject.Find ("LoadingDots");
				if (loadingDots != null) {
						loadingDots.GetComponent<DotsAimation> ().Stop ();//stop dots loading animation
				}

				GameObject loadingMenu = GameObject.Find ("loadingMenu");
				if (loadingMenu != null) {
						loadingMenu.gameObject.SetActive (false);//hide loading menu		
				}
				yield return 0;
		}
}