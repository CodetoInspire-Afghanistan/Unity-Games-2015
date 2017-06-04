using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour {

	public Slider SoundSlid;
	// Use this for initialization

	void Awake(){
		AudioListener.volume = PlayerPrefs.GetFloat ("CUR");
		SoundSlid.value = AudioListener.volume;
	}

	void Start () {
		//AudioListener.volume = 0.1F;
	}

	// Update is called once per frame
	void Update () {
		SetVolume ();
	}

	public void SetVolume(){
		AudioListener.volume = SoundSlid.value;
		PlayerPrefs.SetFloat ("CUR", AudioListener.volume);

	}
}
