using UnityEngine;

public class Bullet : MonoBehaviour
{
	/// <summary>
	/// 子彈的傷害
	/// </summary>
	public float damage;
	public bool player;

	/// <summary>
	/// 勾選Trigger的物件碰撞到執行一次
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		if (!player && other.tag == "Player")
		{
			other.GetComponent<player>().Hit(damage);

		}
		else if (player && other.tag == "Enemy")
		{
			other.GetComponent<Enemy>().Hit(damage);
		}
		
	}
}
