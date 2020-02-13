using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public EnemyData data;

	public Transform playerpos;			//玩家位置

	private Animator ani;				//動畫

	private NavMeshAgent nav;           //導覽網格代理器

	private float Timer;

	private HpValueManger hpvaluemanger;

	//摺疊 ctrl+m+o
	//展開 ctrl+m+l 

	private void Start()
	{
		ani = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
		hpvaluemanger = GetComponentInChildren<HpValueManger>();
		playerpos = GameObject.FindWithTag("Player").GetComponent<Transform>();
		nav.stoppingDistance = data.stopdis;
		nav.speed = data.speed;
		Timer = data.cd-0.5f;
		data.curhp = data.hp;
	}
	private void Update()
	{
		Move();
	}

	/// <summary>
	/// 等待
	/// </summary>
	private void Wait()
	{
		ani.SetBool("跑步開關", false);
		Timer += Time.deltaTime;

		if (Timer > data.cd)
		{
			Attack();
			Timer = 0;
		}
	}

	/// <summary>
	/// 移動
	/// </summary>
	private void Move()
	{
		Vector3 postarget = playerpos.position;
		postarget.y = transform.position.y;
		transform.LookAt(postarget);
		ani.SetBool("跑步開關",true);
		nav.SetDestination(playerpos.position);

		//print("剩餘距離" + nav.remainingDistance);  跟目的的勝於距離
		if (nav.remainingDistance < nav.stoppingDistance)
		{
			Wait();
		}
		else
		{
			ani.SetBool("跑步開關", true);
		}
	}

	protected virtual void Attack()
	{
		
		ani.SetTrigger("攻擊開關");
	}

	/// <summary>
	/// 受傷
	/// </summary>
	/// <param name="damage">傷害</param>
	public void Hit(float damage)
	{
		if (ani.GetBool("死亡開關")) return;
		data.curhp -= damage;
		hpvaluemanger.SetHpbar(data.curhp, data.hp);
		StartCoroutine(hpvaluemanger.ShowText(damage, "-", Color.white));
		if (data.curhp < 0) Dead();
	}
	/// <summary>
	/// 死亡
	/// </summary>
	private void Dead()
	{
		ani.SetBool("死亡開關", true);

	}
}
