using UnityEngine;

public class Bullet : MonoBehaviour
{
	/// <summary>
	/// 子彈的傷害
	/// </summary>
	public float damage;

	/// <summary>
	/// 勾選Trigger的物件碰撞到執行一次
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<player>().Hit(damage);
			Destroy(this);
		}
	}
}
