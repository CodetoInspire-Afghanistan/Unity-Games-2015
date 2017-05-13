using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WordTouching : MonoBehaviour {
	Panel panel;
	bool stopTouch;
	Spawner spawner;
	 GameObject healthController;
	[SerializeField]
	private float speed;
    [SerializeField]
	private GameObject[] Health;
    public static int health;
	[SerializeField ]
	private Text Scoretext;
	private GameObject SpawnerWords;
	public static string spawnerWordTag;
	public static int wordIndex;
	public static string myString;
    GameObject MusicPlay;


      
void Start () {
		// for accessing the gameobject
		MusicPlay = GameObject.Find ("musicP") as GameObject;
		healthController = GameObject.Find ("HealthController");
		spawner = GameObject.FindObjectOfType<Spawner> ();
        health = 0;

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 4) {
			SpawnerWords = GameObject.Find ("SpawnWords");
		
		}
	}
	// called methods 
	void Update () {
		spawnerTransform ();

		touch ();
		touchCandy ();

			
		//for going to next level by take  score for each level and each level has specify score

		if ((score.scoreSta >=20 && score.scoreSta<30) &&  UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 1) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (2);
			} 
	
		if ((score.scoreSta>=40 && score.scoreSta<50)&&  UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 2 ){
			UnityEngine.SceneManagement.SceneManager.LoadScene (3);
				}
		if ((score.scoreSta>=60 && score.scoreSta<70)&&UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 3){
			UnityEngine.SceneManagement.SceneManager.LoadScene (4);
		
				}
		if ((score.scoreSta>=90 &&score.scoreSta<93) && UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 4){
			UnityEngine.SceneManagement.SceneManager.LoadScene (5);

		}

		}
	//method for touching on gameobject   

	void touch ()
	{
		//gameobject will destroy or also by teaching the correct word our score will be  increased and the correct sound will  be played
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 1
			|| UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 2 ) {

			if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began && !Panel.isPanelShow) {
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				Vector2 touchpos = new Vector2 (wp.x, wp.y);
				RaycastHit2D hitinformation = Physics2D.Raycast (touchpos, Camera.main.transform.forward);
				if (GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchpos) && gameObject.tag == spawner.myTag ) {
					Destroy (gameObject);
					Destroy (spawner.myGameObject);
					MusicPlay.GetComponent<AudioSource> ().clip = MusicPlay.GetComponent<addAudioclip> ().CorrectSound;
					MusicPlay.GetComponent<AudioSource> ().Play ();
					score.scoreSta++;
					spawner.myLetters ();


					//  by teaching incorrect word our health will be decreased and incorrect sound will be played 
				} else if (GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchpos)&& gameObject.tag!=spawner.myTag
				        && hitinformation.collider != null  && gameObject.tag != "DownCollider" && gameObject.tag != "Candy") {
					    healthController.GetComponent<HealthScript> ().Hit ();
					MusicPlay.GetComponent<AudioSource> ().clip = MusicPlay.GetComponent<addAudioclip> ().IncorrectSound;
					MusicPlay.GetComponent<AudioSource> ().Play ();
				
				
				}  
			}
		}

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 4) {
			spawnerWordTag = SpawnerWords.GetComponent<spawnwords> ().myTag;
			
			if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began && !Panel.isPanelShow) {
				
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			
				Vector2 touchpos = new Vector2 (wp.x, wp.y);
				RaycastHit2D hitinformation = Physics2D.Raycast (touchpos, Camera.main.transform.forward);
				// When the correct word will have touched onother word will be instantiate
				if (GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchpos) && gameObject.tag[0] ==spawnerWordTag[wordIndex]) {
					myString += spawnerWordTag [wordIndex];

					Destroy (gameObject);
					MusicPlay.GetComponent<AudioSource> ().clip = MusicPlay.GetComponent<addAudioclip> ().CorrectSound;
					MusicPlay.GetComponent<AudioSource> ().Play ();


					if (wordIndex < spawnerWordTag.Length) {
						wordIndex++;
						spawnwords.ind++;
					}
					if (wordIndex == spawnerWordTag.Length) {
						
						spawnwords.ind = 0;
						wordIndex = 0;
						score.scoreSta += 5;
					}
				}
				else if (GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchpos)
					&& hitinformation.collider !=null && gameObject.tag!=spawnerWordTag[wordIndex].ToString() 
					&& gameObject.tag!="DownCollider" && gameObject.tag !="Candy") {
					healthController.GetComponent<HealthScript> ().Hit ();
					MusicPlay.GetComponent<AudioSource> ().clip = MusicPlay.GetComponent<addAudioclip> ().IncorrectSound;
					MusicPlay.GetComponent<AudioSource> ().Play ();

				}
			}
		}
	}
	//touching on candy for giving score
	// this method for tack prize and extra score
		
	  void touchCandy ()
	{
		if (Input.touchCount ==1 && Input.GetTouch(0).phase==TouchPhase.Began && gameObject.tag == "Candy"  ) {
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchpos = new Vector2 (wp.x, wp.y);
			if (GetComponent<BoxCollider2D> () == Physics2D.OverlapPoint (touchpos)) {
				
				Destroy (this.gameObject);
				score.scoreSta+=3;
		}
		}   


	}
	//level 1 or 4 gameobject's comes form  down
	//level 3 or 2 gameobject's  comes top
	void spawnerTransform(){
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 2
			||UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 3) {
			transform.Translate (new Vector3 (0, 1, 0) *speed* Time.deltaTime);
		}
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 1
			|| UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex==4) {
			transform.Translate (new Vector3 (0, -1, 0) *speed* Time.deltaTime);
	
		}
	}

}