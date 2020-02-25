using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{
	public PlayerData playerData;

	public void buyhp_500()
	{
		playerData.maxHp += 500;
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene("關卡1");
	}
}
