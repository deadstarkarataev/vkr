using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Hero : Entity
{
	public Transform attackPos;
	public LayerMask enemy;
	public float attackRange;
	public Joystick joystick;
	public static Hero Instance { get; set; }

	[SerializeField] private float speed = 3f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private AudioSource jumpSound;
	[SerializeField] private AudioSource Hit;
	[SerializeField] private AudioSource MissHit;
	private bool isGrounded = true;

	private Rigidbody2D rb;
	private Animator anim;
	private SpriteRenderer sprite;

	public bool isAttacking = false;
	public bool isRecharged = true;

	private void Awake()
	{
		Instance = this;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
		isRecharged = true;
	}
	private void Start()
	{

		lives = 2;
	}

	private void FixedUpdate()
	{
		CheckGround();
	}

	private void Update()
	{
		if (isGrounded && !isAttacking) State = States.idle;

		if (!isAttacking && joystick.Horizontal != 0)
			Run();

		if (!isAttacking && isGrounded && joystick.Vertical > 0.5f)
			Jump();
		//if(Input.GetKeyDown(KeyCode.Escape))
		//      {
		//	SceneManager.LoadScene(0);
		//      }
	}

	private void Run()
	{
		if (isGrounded) State = States.run;

		Vector3 dir = transform.right * joystick.Horizontal;

		transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

		sprite.flipX = dir.x < 0.0f;
	}

	private void Jump()
	{
		rb.velocity = Vector2.up * jumpForce;
		jumpSound.Play();
	}

	private States State
	{
		get { return (States)anim.GetInteger("state"); }
		set { anim.SetInteger("state", (int)value); }
	}
	private void CheckGround()
	{
		Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
		isGrounded = collider.Length > 1;

		if (!isGrounded) State = States.jump;
	}
	public override void GetDamage()
	{
		lives -= 1;
		if (lives == 0)
		{
			Die();
			SceneManager.LoadScene(0);
		}

		Debug.Log(lives);
	}


	public void Attack()
	{
		if (isGrounded && isRecharged)
		{
			State = States.attack;
			isAttacking = true;
			isRecharged = false;

			StartCoroutine(AttackAnimation());
			StartCoroutine(AttackCoolDown());

		}
	}
	private void OnAttack()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);

		if (colliders.Length == 0)
			MissHit.Play();
		else
			Hit.Play();

		for (int i = 0; i < colliders.Length; i++)
		{
			colliders[i].GetComponent<Entity>().GetDamage();
		}
	}
	private IEnumerator AttackAnimation()
	{

		yield return new WaitForSeconds(0.2f);
		isAttacking = false;
	}

	private IEnumerator AttackCoolDown()
	{

		yield return new WaitForSeconds(0.5f);
		isRecharged = true;
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}
}

public enum States
{
	idle,
	run,
	jump,
	attack
}
