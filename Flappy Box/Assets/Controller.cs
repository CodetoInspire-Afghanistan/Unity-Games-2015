using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour {
	private bool isGrounded;
	private float radius=0.7f;
	private float force=350f;
	public Transform coinsParent;
	public Transform groundPoint;
	public LayerMask ground;
	public AudioSource audioSource;
	public AudioClip jump;
	public AudioClip coin;
	public AudioClip win;
	public Animator animator;
	public int coins;
	public TextMesh score;
	bool jumped;
	float jumpTime=0;
	float jumpDelay=0.5f;
	public Game gameComponent;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle (groundPoint.position,radius,ground);
		if(isGrounded){
			if (Input.GetMouseButtonDown (0)) {
				gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up*force);
				audioSource.clip = jump;
				audioSource.Play ();
				jumpTime = jumpDelay;
				jumped = true;
				animator.SetTrigger ("jumped");
				print ("jump");

			}
		}
		jumpTime -= Time.deltaTime;
		if (jumpTime<=0 && isGrounded && jumped) {
			animator.SetTrigger ("landed");
			print ("land");
			jumped = false;
		}
	}
	void OnTriggerEnter2D(Collider2D collider2d){
		if (collider2d.tag == "Coin") {
			coins++;	
			score.text = coins + " ";
			Destroy (collider2d.gameObject);
			audioSource.clip = coin;
			audioSource.Play ();
		} else if (collider2d.tag == "DeadZone") {
			Game.shownDialogType = Game.DialogType.LOSE;
			gameComponent.OnGameLose (Game.LoseReason.WRONG_CHOICE);
		}
		else if(collider2d.tag=="Finish"){
			//audioSource.clip = win;
			//audioSource.Play ();
			Game.winStarsCount = 3;
			Game.shownDialogType = Game.DialogType.WIN;
			gameComponent.OnGameWin ();
		}




	}
}























