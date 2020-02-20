using UnityEngine;
using System.Collections;

public class FarEnemy : Enemy
{
	[Header("子彈")]
	public GameObject bullet;

	private Vector3 bulletpos; // 子彈位置

	protected override void Attack()
	{
		base.Attack();
		StartCoroutine(Createbullet());
		
	}

	/// <summary>
	/// 生成子彈
	/// </summary>
	/// <returns></returns>
	private IEnumerator Createbullet()
	{
		yield return new WaitForSeconds(data.attackDelay);
		bulletpos = transform.position + transform.forward * data.attackZ + transform.up * data.attackY;
		GameObject temp = Instantiate(bullet, bulletpos, transform.rotation);
		temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletspeed*1.5f);//增加向前推力
		temp.AddComponent<Bullet>();
		temp.GetComponent<Bullet>().damage = data.atk;
		temp.GetComponent<Bullet>().player = false;
		Destroy(temp, 5);
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

}
