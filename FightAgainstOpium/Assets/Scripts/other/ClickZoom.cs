using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ClickZoom : MonoBehaviour {

	public GameObject MainCamera;
	public int zoomIn;
	public Text NameGame;
	public Text Description; 
	public Button Next;
	private Vector3 FirstPos;
	private Vector3 SecondPos;
	int FirstSize=5;
	int SecondSize=1;
	float Speed=0.5f;

	void Start(){
		FirstPos = new Vector3 (1,0,-10);
		SecondPos=new Vector3(1,-2.4f,-10);
	}
	public void Zooming(){
		//0 , 5 size faqat 5 sec

		Next.gameObject.SetActive (true);
		NameGame.gameObject.SetActive (false);
		Description.gameObject.SetActive (false);



		MainCamera.GetComponent<Camera> ().orthographicSize=Mathf.Lerp (FirstSize,SecondSize,Time.deltaTime*Speed) ;
		//MainCamera.GetComponent<Transform> ().position = new Vector3(1,-2.4f,-10);


		MainCamera.GetComponent<Transform> ().position=Vector3.Lerp (FirstPos,SecondPos,Time.deltaTime*Speed);
		//MainCamera.GetComponent<Transform> ().position = new Vector3(1,-2.4f,-10);


	}



}