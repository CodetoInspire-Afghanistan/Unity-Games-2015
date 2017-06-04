using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class Character : MonoBehaviour {
    [SerializeField]
    protected Transform knifePos;

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    [SerializeField]
    private GameObject knifePrefab;
    [SerializeField]
    protected Stat healthStat;

    [SerializeField]
    private EdgeCollider2D swordCollider;

    [SerializeField]
    private List<string> damageSources;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public bool TakingDamage { get; set; }

    public Animator MyAnimator { get; private set; }

    public EdgeCollider2D SwordCollider
    {
        get
        {
            return swordCollider;
        }
    }

    // Use this for initialization
    public virtual void Start ()
    {
        facingRight = true;

        MyAnimator = GetComponent<Animator>();

        healthStat.Initialize();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public abstract IEnumerator TakeDamage();

    public abstract void Death();

    public virtual void ChangeDirection()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
    public virtual void ThrowKnife(int value)
    {
        if (facingRight) 
        {
           GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.right);
        }
        else 
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, knifePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Knife>().Initialize(Vector2.left);
        }
    }
    public void MeleeAttack()
    {
        SwordCollider.enabled = true;
        Vector3 tmpPos = swordCollider.transform.position;
        swordCollider.transform.position = new Vector3(swordCollider.transform.position.x + 0,01, swordCollider.transform.position.y);
        swordCollider.transform.position = tmpPos;
    }
 
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSources.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
    }
}
