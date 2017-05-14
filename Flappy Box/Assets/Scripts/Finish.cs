using UnityEngine;
using System.Collections;

/// <summary>
/// Finish scene script.
/// </summary>
public class Finish : MonoBehaviour
{
		// Use this for initialization
		IEnumerator Start ()
		{
				General.audioManagerComp.FadeInClip (SFX.instance.audioSources [0], 0.5f, 0.6f);
				yield return 0;
		}
}
