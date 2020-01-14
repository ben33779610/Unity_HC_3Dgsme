using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	public EnemyData data;

	public Transform playerpos;			//玩家位置

	private Animator ani;				//動畫

	private NavMeshAgent nav;			//導覽網格代理器




	//摺疊 ctrl+m+o
	//展開 ctrl+m+l 

	private void Start()
	{
		ani = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
		playerpos = GameObject.FindWithTag("Player").GetComponent<Transform>();
		nav.stoppingDistance = data.stopdis;
		nav.speed = data.speed;
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
	}
	/// <summary>
	/// 受傷
	/// </summary>
	/// <param name="damage">傷害</param>
	private void Hit(float damage)
	{

	}
	/// <summary>
	/// 死亡
	/// </summary>
	private void Dead()
	{

	}
}
