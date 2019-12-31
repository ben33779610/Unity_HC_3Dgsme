using UnityEngine;
using UnityEngine.UI;

public class RandomSkill : MonoBehaviour
{
	[Header("模糊圖片")] 
	public Sprite[] Blurry;
	public Sprite[] Skill;

	private Image img;				//圖片元件
	private Button btn;				//按鈕元件




	void Start()
    {
		img = GetComponent<Image>();
		btn = GetComponent<Button>()

	}

	//定義協程
	//按鈕無法點選
	//迴圈
	//圖片元件.圖片 = 模糊圖片陣列
	//隨機
	//按鈕可點
    
}
