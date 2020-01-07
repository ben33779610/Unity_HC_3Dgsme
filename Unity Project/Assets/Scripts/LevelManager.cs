using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public GameObject skill;			 
	public GameObject objlight;
	[Header("自動開門")]
	public bool autodoor;
	[Header("自動顯示技能")]
	public bool autoskill;

	private Animator animdoor;


	private void Start()
	{
		animdoor = GameObject.Find("門板").GetComponent<Animator>();
		if (autoskill) Showskill();
		if (autodoor) Invoke("Showdoor", 3);

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

}
