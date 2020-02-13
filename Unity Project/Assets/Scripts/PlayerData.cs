using UnityEngine;


	[CreateAssetMenu(fileName ="玩家資料",menuName = "Data/玩家資料")]
public class PlayerData : ScriptableObject
{
	[Header("玩家血量")]
	public float Hp;
	[Header("玩家最大血量")]
	public float maxHp;
	[Header("攻擊力"), Range(10, 1000)]
	public float atk;
	[Header("攻擊冷卻")]
	public float atkcd;
	[Header("攻擊位置Y")]
	public float attackY;
	[Header("攻擊位置Z")]
	public float attackZ;
	[Header("子彈速度"),Range(150, 5000)]
	public float bulletspeed;
	public float attackDelay;
}
