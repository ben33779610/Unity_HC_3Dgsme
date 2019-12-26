using UnityEngine;

public class player : MonoBehaviour
{
	[Header("速度"), Range(0, 1500)]
	public float speed;

	Rigidbody rig;           //剛體

	FixedJoystick joystick; //虛擬搖桿

	Animator anim;

	Transform target;
	private void Start()
	{

		rig = GetComponent<Rigidbody>();
		//GameObject.Find("物件名稱").GetComponent<T>();		T --泛型(任一個形式
		joystick = GameObject.Find("虛擬搖桿").GetComponent<FixedJoystick>();
		anim = GetComponent<Animator>();
		target = GameObject.Find("目標").transform;
	}

	/// <summary>
	/// 固定執行1秒50次
	/// </summary>
	private void FixedUpdate()
	{
		Move();
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
	}

}
