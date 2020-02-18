using System.Collections;
using UnityEngine;
using System.Linq; // 引用查詢API

public class player : MonoBehaviour
{
	[Header("速度"), Range(0, 1500)]
	public float speed;

	public PlayerData data;
	[Header("子彈")]
	public GameObject bullet;

	private Rigidbody rig;           //剛體
	private FixedJoystick joystick; //虛擬搖桿
	private Animator ani;
	private Transform target;
	private LevelManager levelmanger;
	private HpValueManger hpvaluemanger;
	private Vector3 bulletpos;
	private float Timer;
	private Enemy[] enemy;      //抓到所有敵人
	private float[] enemydis;		//取得敵人距離
	private void Start()
	{

		rig = GetComponent<Rigidbody>();
		//GameObject.Find("物件名稱").GetComponent<T>();		T --泛型(任一個形式
		joystick = GameObject.Find("虛擬搖桿").GetComponent<FixedJoystick>();
		ani = GetComponent<Animator>();
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
		ani.SetBool("跑步開關", h != 0 || v != 0);
		Vector3 pos = transform.position;
		target.position = new Vector3(pos.x - h, 0.4f, pos.z -v);
		Vector3 targetPostion = new Vector3(target.position.x, pos.y, target.position.z);	//目標座標(目標的x,原本的y,目標的z)
		transform.LookAt(targetPostion);
		if (v == 0 && h == 0)
		{
				Attack();
		}
	}

	/// <summary>
	/// 受傷
	/// </summary>
	/// <param name="damage"></param>
	public void Hit(float damage)
	{
		if (ani.GetBool("死亡開關")) return;
		data.Hp -= damage;
		hpvaluemanger.SetHpbar(data.Hp, data.maxHp);
		StartCoroutine(hpvaluemanger.ShowText(damage, "-", Color.white));
		if (data.Hp < 0) Dead();
	}

	private void Dead()
	{
		ani.SetBool("死亡開關", true);
		enabled = false;    //這個腳本停用
		StartCoroutine(levelmanger.ShowRevial());
	}

	public void Revial()
	{
		ani.SetBool("死亡開關", false);
		enabled = true;
		data.Hp = data.maxHp;
		levelmanger.HideRevial();
	}

	public void Attack()
	{
		if (Timer < data.atkcd)
		{
			Timer += Time.deltaTime;
		}
		else
		{
			
			//抓出所有敵人
			enemy = FindObjectsOfType<Enemy>();
			if (enemy.Length == 0)
			{
				levelmanger.Pass();
				return;
			}
			Timer = 0;
			ani.SetTrigger("攻擊開關");
			//所有敵人的距離
			enemydis = new float[enemy.Length];
			//距離陣列=新的浮點數陣列[數量]
			for (int i = 0; i < enemy.Length; i++)
			{
				enemydis[i] = Vector3.Distance(transform.position, enemy[i].transform.position);
				//距離=三為向量(A,B)
			}
			
			float min = enemydis.Min();
			int index = enemydis.ToList().IndexOf(min);
			Vector3 enemypos = enemy[index].transform.position;
			enemypos.y = transform.position.y;
			transform.LookAt(enemypos);

			StartCoroutine(Createbullet());
		}
	}

	/// <summary>
	/// 繪製圖示
	/// </summary>
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		bulletpos = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
		Gizmos.DrawSphere(bulletpos, 0.1f);

	}
	private IEnumerator Createbullet()
	{
		Vector3 angle = transform.eulerAngles;  //角色本身的角度
		Quaternion qua = Quaternion.Euler(angle.x + 180, angle.y, angle.z);//角度要轉換需要四元角度
		yield return new WaitForSeconds(data.attackDelay);
		bulletpos = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
		GameObject temp = Instantiate(bullet, bulletpos, qua);
		temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletspeed);//增加向前推力
		temp.AddComponent<Bullet>();
		temp.GetComponent<Bullet>().damage = data.atk;
		temp.GetComponent<Bullet>().player = true;
		Destroy(temp, 2);
	}
}
