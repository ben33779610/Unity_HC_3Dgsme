using UnityEngine;


	[CreateAssetMenu(fileName ="玩家資料",menuName = "Data/玩家資料")]
public class PlayerData : ScriptableObject
{
	[Header("玩家血量")]
	public float Hp;

	private float maxHp;//玩家最大血量

}
