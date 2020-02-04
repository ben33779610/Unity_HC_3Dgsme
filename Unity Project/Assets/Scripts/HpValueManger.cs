using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class HpValueManger : MonoBehaviour
{

	private Image Hpbar;		//血條
	private Text hptext;        //數值
	private RectTransform hprect;

    void Start()
    {
		Hpbar = transform.GetChild(1).GetComponent<Image>();
		hptext = transform.GetChild(2).GetComponent<Text>();
		hprect = transform.GetChild(2).GetComponent<RectTransform>();

	}
	private void Update()
	{
		FixAngle();
		
	}

	/// <summary>
	/// 固定血條
	/// </summary>
	private void FixAngle()
	{
		transform.eulerAngles = new Vector3(35.66f, 180, 0);
	}

	/// <summary>
	/// 更新血量
	/// </summary>
	/// <param name="curHp">目前血量</param>
	/// <param name="Hpmax">最大血量</param>
	public void SetHpbar(float curHp, float Hpmax)
	{
		Hpbar.fillAmount =  curHp / Hpmax;
	}

	public IEnumerator ShowText(float value, string mark, Color color)
	{
		hptext.text = mark + value;
		color.a = 0;
		hptext.color = color;
		hprect.anchoredPosition = Vector2.up * 53.4f;

		for (int i = 0; i < 20; i++)
		{
			hptext.color += new Color(0, 0, 0, 0.05f);
			hprect.anchoredPosition += Vector2.up * 5;
			yield return new WaitForSeconds(0.1f);
		}
		yield return new WaitForSeconds(1f);
		hptext.color = new Color(0, 0, 0, 0);
	}
}
