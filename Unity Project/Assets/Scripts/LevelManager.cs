using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public GameObject skill;			 
	public GameObject objlight;
	[Header("自動開門")]
	public bool autodoor;
	[Header("自動顯示技能")]
	public bool autoskill;

	private Animator animdoor;
	[Header("轉場畫面")]
	public Image imagecross; //轉場
	[Header("復活畫面")]
	public GameObject panelrevial;
	private AdManager AdManager;
	[Header("復活按鈕")]
	public Button btnrevial;
	private void Start()
	{
		animdoor = GameObject.Find("門板").GetComponent<Animator>();
		imagecross = GameObject.Find("轉場").GetComponent<Image>();
		if (autoskill) Showskill();					//顯示技能
		if (autodoor) Invoke("Showdoor", 3);        //延遲3秒後開門
		AdManager = FindObjectOfType<AdManager>();
		btnrevial.onClick.AddListener(AdManager.ShowAdrevial);
	}

	/// <summary>
	/// 顯示技能
	/// </summary>
	private void Showskill()
	{
		skill.SetActive(true);
	}

	/// <summary>
	/// 開門 燈光
	/// </summary>
	private void Showdoor()
	{
		objlight.SetActive(true);
		animdoor.SetTrigger("開門開關");
	}

	/// <summary>
	/// 下一關
	/// </summary>
	public IEnumerator NextLevel()
	{
		print("載入下一關");
		for (float i = 0; i < 1; i+=0.05f)				
		{			
			imagecross.color += new Color(0, 0, 0, 0.05f); 
			yield return new WaitForSeconds(0.05f);
		}


		SceneManager.LoadScene("關卡2");
	}

	public IEnumerator ShowRevial()
	{
		panelrevial.SetActive(true);
		Text resecond = panelrevial.transform.GetChild(1).GetComponent<Text>();

		for (int i = 3; i > 0 ; i--)
		{
			resecond.text = i.ToString();
			yield return new WaitForSeconds(1);
		}
	}

	public void HideRevial()
	{
		StopCoroutine(ShowRevial());
		panelrevial.SetActive(false);
	}
}
