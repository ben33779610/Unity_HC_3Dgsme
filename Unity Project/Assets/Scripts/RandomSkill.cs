using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomSkill : MonoBehaviour
{
	[Header("模糊圖片,技能圖片")] 
	public Sprite[] Blurry;				//模糊圖片
	public Sprite[] Skill;                  //技能圖片
	[Header("捲動速度")][Range(0.0001f, 3.0f)]
	public float speed = 0.1f;
	[Header("捲動次數")][Range(1, 10)]
	public int count = 3;
	

	public AudioClip scrollsound;
	public AudioClip getskill;

	private Image img;				//圖片元件
	private Button btn;             //按鈕元件
	
	private AudioSource auo;

	private string[] skillname = { "連續射擊", "正向箭", "背向箭", "側向箭", "血量提升", "攻擊提升", "攻速提升", "爆擊提升" };
	private Text nameskill;							//技能名稱

	private GameObject skillpanel;			//技能元件
	private int index;										//技能編號

	void Start()
    {
		img = GetComponent<Image>();
		btn = GetComponent<Button>();
		auo = GetComponent<AudioSource>();
		nameskill = transform.GetChild(0).GetComponent<Text>(); //取得子物件
		skillpanel = GameObject.Find("技能背景");
		StartCoroutine(ScrollEffect());
	}

	public void ChooseSkill()
	{
		skillpanel.SetActive(false);
		

	}

	//定義協程
	/// <summary>
	/// 技能捲動
	/// </summary>
	/// <returns></returns>
	private IEnumerator ScrollEffect()
	{
		btn.interactable = false;   //按鈕無法點選
									//迴圈
		for (int j = 0; j < count; j++)
		{
			for (int i = 0; i < Blurry.Length; i++)             //圖片元件.圖片 = 模糊圖片陣列
			{
				auo.PlayOneShot(scrollsound, 0.2f);
				img.sprite = Blurry[i];
				yield return new WaitForSeconds(speed);
			}
		}

		index = Random.Range(1, Skill.Length);				//隨機
		img.sprite = Skill[index];											
		nameskill.text = skillname[index];						//技能名稱
		btn.interactable = true;                                         //按鈕可點

	}
	
	
	
	
	

}
