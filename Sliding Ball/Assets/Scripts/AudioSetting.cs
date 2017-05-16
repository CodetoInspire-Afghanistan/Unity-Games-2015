using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour {

	public Slider SoundSlid;

	void Awake(){
		AudioListener.volume = PlayerPrefs.GetFloat ("CUR");
		SoundSlid.value = AudioListener.volume;
	}

	// Update is called once per frame
	void Update () {
		SetVolume ();
	}

	//for controlling sound by slider
	public void SetVolume(){
		AudioListener.volume = SoundSlid.value;
		PlayerPrefs.SetFloat ("CUR", AudioListener.volume);

	}
}
