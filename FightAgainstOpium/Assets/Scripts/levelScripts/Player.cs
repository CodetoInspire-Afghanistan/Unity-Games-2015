using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public delegate void DeadEventHandler();
public class Player : Character
{
	public AudioClip safferon;
	public Button[] buttons;
	public GameObject Shell1;
 	public Transform fire;

	 
 

	public CameraFollow newCamera;

	//public Transform newPos;
	//public Transform newPos2;
	//public Transform newPos3;
 	public AudioClip AttackMusic;
	public AudioClip ThrowMusic;
	public AudioClip SlideMusic;
	public AudioClip JumpMusic;
	public AudioClip coinMusic;
	//public AudioClip newMusic;
    private static Player instance;

    private IUseable useable;

    private int coins;

	public GameObject bridge;

	//public static int life;

    [SerializeField]
    private float climbSpeed;

    private Vector2 startPos;

    public event DeadEventHandler Dead;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private bool airControl;

    [SerializeField]
    private float jumpForce;

    private bool immortal = false;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float immortalTime;

	PolygonCollider2D [] all;

    private float direction;

    private bool move;

    private float btnHorizontal;

    public Rigidbody2D MyRigidbody { get; set; }

    public bool Slide { get; set; }

    public bool Jump { get; set; }

    public bool OnGround { get; set; }

    public bool OnLadder { get; set; }

    private bool Falling
    {
        get
        {
            return MyRigidbody.velocity.y < 0;
        }
    }

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    public override bool IsDead
    {
        get
        {
            if (healthStat.CurrentValue <= 0)
            {
                OnDead();
            }

            return healthStat.CurrentValue <= 0;
        }
    }

    // Use this for initialization
    public override void Start()
    {
		all = GameObject.FindObjectsOfType<PolygonCollider2D> () as PolygonCollider2D[];
        base.Start();
		//life = 3;
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        MyRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!TakingDamage && !IsDead)
        {
            if (transform.position.y <= -30f)
            {
                Death();

            }
            HandleInput();
 			

        }
			
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        if (!TakingDamage && !IsDead)
        {
            float horizontal = Input.GetAxis("Horizontal");

            float vertical = Input.GetAxis("Vertical");

            OnGround = IsGrounded();

            if (move)
            {
                this.btnHorizontal = Mathf.Lerp(btnHorizontal, direction, Time.deltaTime * 2);
				HandleMovement(btnHorizontal,vertical);
                Flip(direction);
            }
            else
            {
                HandleMovement(horizontal, vertical);

                Flip(horizontal);
            }



            HandleLayers();
        }

    }


    private void Use()
    {
        if (useable != null)
        {
            useable.Use();
        }
    }

    public void OnDead()
    {
        if (Dead != null)
        {
            Dead();
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Lose");
        }
    }



    private void HandleMovement(float horizontal, float vertical)
    {
        if (Falling)
        {
            gameObject.layer = 10;
            MyAnimator.SetBool("land", true);
        }
        if (!Attack && !Slide && (OnGround || airControl))
        {
            MyRigidbody.velocity = new Vector2(horizontal * movementSpeed, MyRigidbody.velocity.y);
        }
        if (Jump && MyRigidbody.velocity.y == 0 && !OnLadder)
        {
            MyRigidbody.AddForce(new Vector2(0, jumpForce));
        }
        if (OnLadder)
        {
            MyAnimator.speed = vertical != 0 ? Mathf.Abs(vertical) : Mathf.Abs(horizontal);
            MyRigidbody.velocity = new Vector2(horizontal * climbSpeed, vertical * climbSpeed);
        }

        MyAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !OnLadder && !Falling)
        {
            MyAnimator.SetTrigger("jump");
            Jump = true;
			AudioSource.PlayClipAtPoint (JumpMusic,transform.position,1f);

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MyAnimator.SetTrigger("attack");
			AudioSource.PlayClipAtPoint (AttackMusic,transform.position,1f);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            MyAnimator.SetTrigger("slide");
			AudioSource.PlayClipAtPoint (SlideMusic,transform.position,1f);

        }
	 
        if (Input.GetKeyDown(KeyCode.V))
        {

		
            MyAnimator.SetTrigger("throw");
			AudioSource.PlayClipAtPoint (ThrowMusic,transform.position,1f);
  				//Invoke ("Fire",0.00001f);

			}

        


		if (Input.GetKeyDown(KeyCode.G))
		{

			Fire ();



		}
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            ChangeDirection();
        }
    }

    private bool IsGrounded()
    {
        if (MyRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }



    private void HandleLayers()
    {
        if (!OnGround)
        {
            MyAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            MyAnimator.SetLayerWeight(1, 0);
        }
    }

    public override void ThrowKnife(int value)
    {
        if (!OnGround && value == 1 || OnGround && value == 0)
        {
            base.ThrowKnife(value);
        }
    }

    private IEnumerator IndicateImmortal()
    {
        while (immortal)
        {
            spriteRenderer.enabled = false;

            yield return new WaitForSeconds(.1f);

            spriteRenderer.enabled = true;

            yield return new WaitForSeconds(.1f);
        }
    }

    public override IEnumerator TakeDamage()
    {
        if (!immortal)
        {
            healthStat.CurrentValue -= 10;

            if (!IsDead)
            {
                MyAnimator.SetTrigger("damage");
                immortal = true;

                StartCoroutine(IndicateImmortal());
                yield return new WaitForSeconds(immortalTime);

                immortal = false;
            }
            else
            {
                MyAnimator.SetLayerWeight(1, 0);
                MyAnimator.SetTrigger("die");
				for(int i=0;i<all.Length;i++){
					all [i].enabled = false;
				}
            }

        }
    }

    public override void Death()
    {
		
		for(int i=0;i<all.Length;i++){
			all [i].enabled = true;
		
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex == 2) {
				Instantiate (bridge, new Vector3(27.85f,-1.76f,0), Quaternion.identity);
		}
        MyRigidbody.velocity = Vector2.zero;
        MyAnimator.SetTrigger("idle");
        healthStat.CurrentValue = healthStat.MaxVal;
				transform.position = startPos;


    }
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Lose");
			GameManager.collectedCoins = 0;


	}

    public void BtnJump()
    {
        MyAnimator.SetTrigger("jump");
        Jump = true;
    }

    public void BtnAttack()
    {
        MyAnimator.SetTrigger("attack");
    }

    public void BtnSlide()
    {
        MyAnimator.SetTrigger("slide");
    }

    public void BtnTrow()
    {
        MyAnimator.SetTrigger("throw");
    }

    public void BtnMove(float direction)
    {
        this.direction = direction;
        this.move = true;
    }

    public void BtnStopMove()
    {
        this.direction = 0;
        this.btnHorizontal = 0;
        this.move = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Springy") {
			MyRigidbody.AddForce(new Vector2(0, 800));

			
		}

	
		
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Coin")
		{
			GameManager.collectedCoins++;
			Destroy(other.gameObject);
			AudioSource.PlayClipAtPoint (coinMusic,transform.position,1f);
		}
		
        if (other.tag == "Useable")
        {
            useable = other.GetComponent<IUseable>();
        } 
		if(other.tag=="newPosition"){
			newCamera.yMin = -9.6f;
		}

		if(other.tag=="fPosition"){
			newCamera.yMin = 1.48f;
		}

		if(other.tag=="collider1"){
			buttons [0].gameObject.SetActive (true);
			AudioSource.PlayClipAtPoint (safferon,transform.position);


		}

		if(other.tag=="collider2"){
			buttons [1].gameObject.SetActive (true);
			AudioSource.PlayClipAtPoint (safferon,transform.position);

		}

		if(other.tag=="collider3"){
			buttons [2].gameObject.SetActive (true);
			AudioSource.PlayClipAtPoint (safferon,transform.position);

		}




        base.OnTriggerEnter2D(other);
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Useable")
        {
            useable = null;
        }
    }



	void Fire(){

		GameObject Missile = 	Instantiate(Shell1,fire.transform.position,Quaternion.identity) as GameObject;
		//Missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (5,0.5f);
		Missile.GetComponent<Rigidbody2D> ().gravityScale = 3f;

	}

}
