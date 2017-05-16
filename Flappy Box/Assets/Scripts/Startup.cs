using UnityEngine;
using System.Collections;

/// <summary>
/// This is the startup script of the game.
/// </summary>
public class Startup : MonoBehaviour
{
		private IEnumerator LogoFinishEvent ()
		{
				yield return new WaitForSeconds (2f);
				Application.LoadLevel (Configuration.mainSceneName);
		}
}