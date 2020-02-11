﻿using UnityEngine;

public class player : MonoBehaviour
{
	[Header("速度"), Range(0, 1500)]
	public float speed;

	public PlayerData data;

	Rigidbody rig;           //剛體

	FixedJoystick joystick; //虛擬搖桿

	Animator anim;

	Transform target;

	private LevelManager levelmanger;

	private HpValueManger hpvaluemanger;

	private float Timer;
	private void Start()
	{

		rig = GetComponent<Rigidbody>();
		//GameObject.Find("物件名稱").GetComponent<T>();		T --泛型(任一個形式
		joystick = GameObject.Find("虛擬搖桿").GetComponent<FixedJoystick>();
		anim = GetComponent<Animator>();
		target = GameObject.Find("目標").transform;
		levelmanger = FindObjectOfType<LevelManager>();         //尋找類型  該類型只有一個
		hpvaluemanger = GetComponentInChildren<HpValueManger>();//尋找在子物件的該類型
	}

	/// <summary>
	/// 固定執行1秒50次
	/// </summary>
	private void FixedUpdate()
	{
		Move();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "傳送區域")
		{
			StartCoroutine(	levelmanger.NextLevel());
		}

	}


	/// <summary>
	/// 移動方法
	/// </summary>
	private void Move()
	{

		float h = joystick.Horizontal;
		float v = joystick.Vertical;
		
		
		rig.AddForce(-h*speed,0,-v*speed);
		
		anim.SetBool("跑步開關", h != 0 || v != 0);

		Vector3 pos = transform.position;
		target.position = new Vector3(pos.x - h, 0.4f, pos.z -v);
		Vector3 targetPostion = new Vector3(target.position.x, pos.y, target.position.z);	//目標座標(目標的x,原本的y,目標的z)
		transform.LookAt(targetPostion);
		if (v == 0 && h == 0)
		{
			Timer += Time.deltaTime;
			if (Timer > data.atkcd)
			{
				Attack();
				Timer = 0;
			}
		}
	}

	public void Attack()
	{
		anim.SetTrigger("攻擊開關");
		
	}

	/// <summary>
	/// 受傷
	/// </summary>
	/// <param name="damage"></param>
	public void Hit(float damage)
	{
		if (anim.GetBool("死亡開關")) return;
		data.Hp -= damage;
		hpvaluemanger.SetHpbar(data.Hp, data.maxHp);
		StartCoroutine(hpvaluemanger.ShowText(damage, "-", Color.white));
		if (data.Hp < 0) Dead();
	}

	private void Dead()
	{
		anim.SetBool("死亡開關", true);
		enabled = false;    //這個腳本停用
		StartCoroutine(levelmanger.ShowRevial());
	}

	public void Revial()
	{
		anim.SetBool("死亡開關", false);
		enabled = true;
		data.Hp = data.maxHp;
		levelmanger.HideRevial();
	}
}
