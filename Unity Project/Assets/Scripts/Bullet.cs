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
			Destroy(gameObject);
		}
		
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (player && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>())
		{
			collision.gameObject.GetComponent<Enemy>().Hit(damage);
			Destroy(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
