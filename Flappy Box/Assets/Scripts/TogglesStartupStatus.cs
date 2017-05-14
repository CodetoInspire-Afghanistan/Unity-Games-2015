using UnityEngine;
using System.Collections;

/// <summary>
/// Toggles startup status.
/// </summary>
public class TogglesStartupStatus : MonoBehaviour
{
		public Animator[] togglesAnimators;//toggles animators references
		public SpriteRenderer[] togglesRelatedIconsSp;//toggles related to icons spriterenderers (sound , music spriterenderers)
		public Sprite musicOffIcon, soundsOffIcon;//music off , sound off icons

		void Start ()
		{
				if (SFX.instance.audioSources [0].mute) {//check if the audioSources[0] is muted 
						togglesAnimators [0].SetBool ("isToggleOn", false);
						togglesAnimators [0].SetBool ("isToggleOff", true);
						togglesRelatedIconsSp [0].sprite = musicOffIcon;
						togglesAnimators [0].GetComponent<Button> ().toggleStatus = Button.ToggleStatus.OFF;
				}

				if (SFX.instance.audioSources [1].mute) {//check if the audioSources[1] is muted 
						togglesAnimators [1].SetBool ("isToggleOn", false);
						togglesAnimators [1].SetBool ("isToggleOff", true);
						togglesRelatedIconsSp [1].sprite = soundsOffIcon;
						togglesAnimators [1].GetComponent<Button> ().toggleStatus = Button.ToggleStatus.OFF;
				}
		}
}