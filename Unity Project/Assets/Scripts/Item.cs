using UnityEngine;

public class Item : MonoBehaviour
{
	/// <summary>
	/// 是否通關 取得所有的道具
	/// </summary>
	[HideInInspector]	//在屬性面板上隱藏
	public bool pass;
	[Header("音效")]
	public AudioClip sound;

	private AudioSource aud;

	private Transform player;

    void Start()
    {
		player = GameObject.Find("機器人").transform;
		aud = GetComponent<AudioSource>();
		HandleCollision();

	}

	private void Update()
	{
		Goplayer();
	}

	private void HandleCollision()
	{
		Physics.IgnoreLayerCollision(10, 8);
		Physics.IgnoreLayerCollision(10, 9);
		
	}

	private void Goplayer()
	{
		if (pass)
		{
			Physics.IgnoreLayerCollision(10, 10);
			transform.position = Vector3.Lerp(transform.position, player.position, 0.8f * Time.deltaTime * 10);

			if (Vector3.Distance(transform.position, player.position) < 1.5f && !aud.isPlaying)
			{
				aud.PlayOneShot(sound, 0.3f);
				Destroy(gameObject, 0.3f);
			}
		}

		
	}
}
