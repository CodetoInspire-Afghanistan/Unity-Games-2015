using UnityEngine;
using System.Collections;

/// <summary>
/// Slider dots.
/// </summary>
public class SliderDots : MonoBehaviour
{
		public TextMesh[] dots;//dots text mesh references

	//set dot at the given index
		public void setDot (int index)
		{
				if (dots == null) {
						return;
				}
		
				if (index >= 0 && index < dots.Length) {
						resetDots ();
						dots [index].text = ".";
				}
		}

	//reset dots
		private void resetDots ()
		{
				if (dots == null) {
						return;
				}
				for (int i = 0; i < dots.Length; i++) {
			
						dots [i].text = "";
				}
		}
}
