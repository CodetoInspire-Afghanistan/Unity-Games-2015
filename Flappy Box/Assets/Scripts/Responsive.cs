using UnityEngine;
using System.Collections;

/// <summary>
/// Responsive Positioning And Scaling For GameObject
/// </summary>
public class Responsive : MonoBehaviour
{
	public ScaleType scaleType = ScaleType.PERCENTAGE;//scale method
	public ResponsiveMode responsiveMode = ResponsiveMode.AWAKE;//responsive mode
	public float xposfrac = 0.5f;//x-position fraction
	public float yposfrac = 0.5f;//y-position fraction
	public float xscalefrac = 0.1f;//x-scale fraction
	public float yscalefrac = 0.1f;//y-scale fraction
	public float aspectfrac = 1;//aspect ratio fraction
	public bool doScale = true;
	public bool doTranslate = true;
	public bool isEnabled = true;
	public Camera cam;
	
	void Awake ()
	{
		if (cam == null) {
			cam = Camera.main;
		}
		
		if (isEnabled) {
			if (responsiveMode == ResponsiveMode.AWAKE) {
				SetPositionAndScale ();
			}
		}
	}
	
	void Update ()
	{
		if (isEnabled) {
			if (responsiveMode == ResponsiveMode.UPDATE) {
				SetPositionAndScale ();
			}
		}
	}

	//setting up the position and the scale
	private void SetPositionAndScale ()
	{
		if (doTranslate) {
			PercentagePositioning ();
		}
		if (doScale) {
			if (scaleType == ScaleType.ASPECT_RATIO) {
				AspectRatioScaling ();
			} else if (scaleType == ScaleType.PERCENTAGE) {
				PercentageScaling ();
			}
		}
	}
	
	//Change The Position Of Current Object Relative Screen Width and Screen Height
	private void PercentagePositioning ()
	{
		int swidth = Screen.width;
		int sheight = Screen.height;
		
		Vector3 positionworldvector = cam.ScreenToWorldPoint (new Vector2 (swidth * xposfrac, sheight * yposfrac));//screen pixel position to world position
		transform.position = new Vector3 (positionworldvector.x, positionworldvector.y, transform.position.z);//set new position
	}
	
	//Change The Scale Of Current Object Relative To Screen Width and Screen Height
	private void PercentageScaling ()
	{
		int swidth = Screen.width;
		int sheight = Screen.height;
		
		Vector3 sccaleworldvector = cam.ScreenToWorldPoint (new Vector2 (swidth, sheight));//screen pixel scale to world scale
		transform.localScale = new Vector3 (sccaleworldvector.x * xscalefrac, sccaleworldvector.y * yscalefrac, transform.localScale.z);//set new scale	
	}
	
	//Change The Scale Of Current Object Relative To Screen Aspect Ratio
	private void AspectRatioScaling ()
	{
		float aspectRatio = cam.aspect;
		transform.localScale = new Vector3 (aspectRatio * aspectfrac, aspectRatio * aspectfrac, aspectRatio * aspectfrac);//set new scale	
	}
	
	public enum ScaleType
	{
		PERCENTAGE,
		ASPECT_RATIO
	}
	
	public enum ResponsiveMode
	{
		AWAKE,
		UPDATE
	}
}