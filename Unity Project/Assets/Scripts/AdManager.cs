using UnityEngine;
using UnityEngine.Advertisements;


//繼承只能繼承一個 但介面可以有很多個
//介面通常都是I開頭
//IUnityAdsListener 廣告監聽者 像準備成功失敗 等等
public class AdManager : MonoBehaviour,IUnityAdsListener
{

	private string GoogleId = "3459587";		//Google廣告id
	private string placementrevial = "revial";  //unity廣告id
	private player player;
	private void Start()
	{
		Advertisement.Initialize(GoogleId, true);       //初始化廣告
		Advertisement.AddListener(this);
		player= FindObjectOfType<player>();
	}

	public void ShowAdrevial()			
	{
		if (Advertisement.IsReady(placementrevial))
		{
			Advertisement.Show(placementrevial);
		}

	}
	//準備
	public void OnUnityAdsReady(string placementId)
	{
	}
	//錯誤
	public void OnUnityAdsDidError(string message)
	{
	}
	//開始
	public void OnUnityAdsDidStart(string placementId)
	{
	}
	//完成
	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		if (placementId == placementrevial)
		{
			switch (showResult)
			{
				case ShowResult.Failed:
					print("失敗");
					break;
				case ShowResult.Skipped:
					print("略過");
					break;
				case ShowResult.Finished:
					print("完成");
					player.Revial();
					break;
			}
		}
	}
}
