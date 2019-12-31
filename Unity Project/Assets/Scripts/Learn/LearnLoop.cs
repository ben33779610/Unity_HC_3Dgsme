using UnityEngine;

public class LearnLoop : MonoBehaviour
{
	
    void Start()
    {


		int count = 0;
		while (count < 5)
		{
			print(++count);
		}

		for (int cou = 0; cou <5; cou++)
		{
			print(cou);
		}




	}

   
}
