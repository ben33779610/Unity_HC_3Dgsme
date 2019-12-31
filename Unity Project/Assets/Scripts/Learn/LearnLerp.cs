using UnityEngine;

public class LearnAPI : MonoBehaviour
{

	float a = 0, b = 1.0f;
    void Start()
    {
		print( Mathf.Lerp(a, b, 0.8f)  );
		print(Color.Lerp(Color.red, Color.green, 0.4f));
    }

    
}
