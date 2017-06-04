using UnityEngine;
using System.Collections;
using System;

public class Enemy : Character
{
    private IEnemyState currentState;

    public GameObject Target { get; set; }

    [SerializeField]
    private float meleeRange;

    [SerializeField]
    private float throwRange;

    private Vector3 startPos;

    [SerializeField]
    private Transform leftEdge;

    [SerializeField]
    private Transform rightEdge;

    private Canvas healthCavas;

    private bool dropItem = true;

    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;

            }

            return false;
        }
    }
    public bool InThrowRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;

            }

            return false;
        }
    }

    public override bool IsDead
    {
        get
        {
            return healthStat.CurrentValue <= 0;
        }
    }

    public override void Start()
    {   //Calls the base start
        base.Start();

        this.startPos = transform.position;

        Player.Instance.Dead += new DeadEventHandler(RemoveTarget);

        ChangeState(new IdleState());

        healthCavas = transform.GetComponentInChildren<Canvas>();
    }



    // Update is called once per frame
    void Update()
    {
        if (!IsDead) 
        {
            if (!TakingDamage) 
            {
                currentState.Execute();
            }

            LookAtTarget();
        }

    }

    public void RemoveTarget()
    {
        Target = null;

        ChangeState(new PatrolState());
    }
    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }
    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    public void Move()
    {
        if (!Attack)
        {
            if ((GetDirection().x > 0 && transform.position.x < rightEdge.position.x) || (GetDirection().x < 0 && transform.position.x > leftEdge.position.x))
            {
                MyAnimator.SetFloat("speed", 1);

				if(GetDirection().x>0){
					transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));

				}
				else if(GetDirection().x<0){
					transform.Translate(GetDirection() * (-movementSpeed * Time.deltaTime));

				}
            }
            else if (currentState is PatrolState)
            {
                ChangeDirection();
            }
            else if (currentState is RangedState)
            {
                Target = null;
                ChangeState(new IdleState());
            }

        }

    }
    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        currentState.OnTriggerEnter(other);
    }

    public override IEnumerator TakeDamage()
    {
        if (!healthCavas.isActiveAndEnabled)
        {
            healthCavas.enabled = true;
        }

        healthStat.CurrentValue -= 10;

        if (!IsDead) 
        {
            MyAnimator.SetTrigger("damage");
        }
        else 
        {
            if (dropItem)
            {
                GameObject coin = (GameObject)Instantiate(GameManager.Instance.CoinPrefab, new Vector3(transform.position.x, transform.position.y ), Quaternion.identity);
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), coin.GetComponent<Collider2D>());
                dropItem = false;
            }
   
            MyAnimator.SetTrigger("die");
            yield return null;
        }
    }
    public override void Death()
    {
        dropItem = true;
        MyAnimator.ResetTrigger("die");
        MyAnimator.SetTrigger("idle");
        healthStat.CurrentValue = healthStat.MaxVal;
        transform.position = startPos;
        healthCavas.enabled = false;
    }

    public override void ChangeDirection()
    {
        Transform tmp = transform.FindChild("EnemyHealthBarCanvas").transform;
        Vector3 pos = tmp.position;
        tmp.SetParent(null);

        base.ChangeDirection();

        tmp.SetParent(transform);
        tmp.position = pos;
    }
}
