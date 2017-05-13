using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class touching : MonoBehaviour {
	GameObject musicplay;
	private Animator myAnimator;
	[SerializeField]
	private float speed;

	[SerializeField]
	private GameObject alphabuble;
	Spawner spawner;
	GameObject healthController;

	[SerializeField]
	private GameObject[] Health;
	public static int health;
	[SerializeField ]
	private Text Scoretext;
	private GameObject spawnerWords;
	public static string spawnWordTag;
	public static int wordIndex;
	public static string myString;
	// Use this for initialization
	// for access gameobject in the inspector
	void Start () {
		musicplay = GameObject.Find ("musicP") as GameObject;
		myAnimator = GetComponent<Animator> ();
		healthController = GameObject.Find ("HealthController");
		spawner = GameObject.FindObjectOfType<Spawner> ();
		health = 0;
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 3) {
			spawnerWords = GameObject.Find ("SpawnWords");

		}
	
	
	}

	// Update is called once per frame
	// for moveing words from up to down
	void Update () {
		
	
		transform.Translate (new Vector3 (0, 1, 0) *speed * Time.deltaTime);
	
		touch ();
	}


	//Touch on gameobjects
		void touch ()
		{
		//gameobject will destroy or also by teaching the correct word our score will be  increased and the correct sound will  be played
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 3) {
			spawnWordTag = spawnerWords.GetComponent<spawnwords> ().myTag;
			if (Input.touchCount == 1 && Input.GetTouch(0).phase==TouchPhase.Began && !Panel.isPanelShow ) {
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchpos = new Vector2 (wp.x, wp.y);
				RaycastHit2D hitinformation = Physics2D.Raycast (touchpos, Camera.main.transform.forward);
				if (GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchpos) && gameObject.tag[0] ==spawnWordTag[wordIndex]) {
				
					myString += spawnWordTag [wordIndex];
					Debug.Log (myString);
					// an animation will active
					myAnimator.SetBool ("isTouch",true);

				    Destroy (alphabuble);
					musicplay.GetComponent<AudioSource> ().clip = musicplay.GetComponent<addAudioclip> ().CorrectSound;
					musicplay.GetComponent<AudioSource> ().Play ();
					// When the correct word will have touched onother word will be instantiate
					if (wordIndex < spawnWordTag.Length) {
						wordIndex++;
						spawnwords.ind++;
					}
					if (wordIndex == spawnWordTag.Length) {

						spawnwords.ind = 0;
						wordIndex = 0;
						score.scoreSta += 3;

					}

			

			}
				else if (GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchpos)
					&& hitinformation.collider !=null && gameObject.tag!=spawnWordTag[wordIndex].ToString() 
					&& gameObject.tag!="DownCollider" && gameObject.tag !="Candy") {
					healthController.GetComponent<HealthScript> ().Hit ();
					musicplay.GetComponent<AudioSource> ().clip = musicplay.GetComponent<addAudioclip> ().IncorrectSound;
					musicplay.GetComponent<AudioSource> ().Play ();
				}
			}
		}

	}

	void EndTouch(){
		if (Input.GetTouch (0).phase == TouchPhase.Canceled)
			myAnimator.SetBool ("isTouch",false);

	}
}


