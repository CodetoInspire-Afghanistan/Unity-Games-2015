using UnityEngine;
using System.Collections;

/// <summary>
/// Descending Timer.
/// </summary>
public class Timer : MonoBehaviour
{
		public string startTime = "";
		public float delayTime = 1;
		private string temptime;//temp time for disply only
		private bool isRunning;
		private bool isStarted;
		public bool isDone;
		public bool playAtStart;
		public bool applyTimeToTextMeshes;
		public TextMesh[] textmeshes;
		public string doneEventName;
		public GameObject doneEventObject;
		
		void Awake ()
		{
				temptime = DataEncryption.Base64Encode (startTime);
				ApplyToTextMeshes ();
		}

		void Start ()
		{
				if (delayTime < 0) {
						delayTime = 1;
				}

				if (playAtStart) {
						Play ();
				}
		}

		private IEnumerator StartTimer ()
		{

				while (true) {
					
						if (isRunning) {
								if (temptime == null) {
										break;
								}

								string  [] decodesTime = DataEncryption.Base64Decode (temptime).Split (':');
								if (decodesTime == null) {
										continue;
								}
								int tempm = int.Parse (decodesTime [0]);//minutes
								int temps = int.Parse (decodesTime [1]);//seconds
							
								temps--;
								if (temps == -1) {
										temps = 59;
										tempm--;
								}

								if (tempm == 0 && temps == 0) {
										isDone = true;
										isRunning = false;

										if (!string.IsNullOrEmpty (doneEventName) && doneEventObject != null) {//send message when done
												doneEventObject.SendMessage (doneEventName);
										}
								}

								string strSeconds = getStringTime (temps);
								string strMinutes = getStringTime (tempm);
								temptime = DataEncryption.Base64Encode (strMinutes + ":" + strSeconds);
								if (applyTimeToTextMeshes) {
										ApplyToTextMeshes ();
								}
								yield return new WaitForSeconds (delayTime);
						} else {
								yield return 0;
						}
						
				}
		}

		public static string getStringTime (int value)
		{
				string strValue = "";
				if (value < 10) {
						strValue += "0";
				}
				strValue += value;

				return strValue;
		}

		public void Reset ()
		{
				temptime = DataEncryption.Base64Encode (startTime);
		}

		public void Stop ()
		{
				StopCoroutine ("StartTimer");
				isStarted = false;
				isRunning = false;
		}

		public void Pause ()
		{
				isRunning = false;
		}

		public void Play ()
		{
				if (!isRunning) {
						isRunning = true;
						if (!isStarted) {
								temptime = DataEncryption.Base64Encode (startTime);
								StartCoroutine ("StartTimer");
								isStarted = true;
						}
				}
		}

		private void ApplyToTextMeshes ()
		{
				if (textmeshes == null) {
						return;
				}
				foreach (TextMesh tm in textmeshes) {
						tm.text = CTime;
				}
		}

		public string CTime {
				get { return DataEncryption.Base64Decode (this.temptime);}
		}
}
