using System.Collections;
using UnityEngine;

public class LearnCoroutine : MonoBehaviour
{

	private IEnumerator Test()
	{
		yield return new WaitForSeconds(2);
		for (int cou = 0; cou < 10; cou++)
		{
			print(cou);
		}
		print("等待中");
		yield return new WaitForSeconds(2);
		print("2秒");

	}
    
    void Start()
    {


		StartCoroutine(Test());
		print("AAA");
    }


}
