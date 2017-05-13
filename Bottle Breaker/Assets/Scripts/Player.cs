using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	public float speed = 18;
	float minX ;
	float maxX ;
	public float padding =2.5f;
    private ScoreKeeper scoreKeeper;
    public AudioClip Break_Sound;


	// Use this for initialization
	void Start () {
        scoreKeeper=GameObject.FindObjectOfType<ScoreKeeper>();
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;


}void Update () {

    if (Input.GetKey(KeyCode.LeftArrow)) {

        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    else if (Input.GetKey(KeyCode.RightArrow)) {

        transform.position += Vector3.right * speed * Time.deltaTime;
    }

        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        this.transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }


    void OnCollisionEnter2D(Collision2D col){

        Destroy(col.gameObject);
        AudioSource.PlayClipAtPoint(Break_Sound,this.transform.position);
        scoreKeeper.IncreaseScore();

    }



}