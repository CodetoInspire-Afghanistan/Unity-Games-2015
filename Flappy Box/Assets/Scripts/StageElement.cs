using UnityEngine;
using System.Collections;

/// <summary>
/// Stage element.
/// </summary>
public class StageElement : MonoBehaviour
{
		public bool isLocked;//is locked
		public int id;//id
		public int starLevel; //from 0 to 15
		public Sprite[] starLevelIcons;//star level icons
		public Sprite[] backgroundIcons;//background icons
       
		//set stars level
		public void SetStarsLevel (int level, SpriteRenderer sp)
		{
				if (!(level >= 0 && level < starLevelIcons.Length)) {
						return;
				}

				sp.sprite = starLevelIcons [level];
		}

		//set background icon
		public void SetBackgoundIcon (int index, SpriteRenderer sp)
		{
				if (!(index >= 0 && index < backgroundIcons.Length)) {
						return;
				}
				sp.sprite = backgroundIcons [index];
		}
}