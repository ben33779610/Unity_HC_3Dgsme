using UnityEngine;

public class player : MonoBehaviour
{
	[Header("速度"), Range(0, 1500)]
	public float speed;

	Rigidbody rig;           //剛體

	FixedJoystick joystick; //虛擬搖桿

	Animator anim;
	
	private void Start()
	{

		rig = GetComponent<Rigidbody>();
		//GameObject.Find("物件名稱").GetComponent<T>();		T --泛型(任一個形式
		joystick = GameObject.Find("虛擬搖桿").GetComponent<FixedJoystick>();
		anim = GetComponent<Animator>();
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
			
	}

}
