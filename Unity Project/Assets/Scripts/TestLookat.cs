using UnityEngine;

public class TestLookat : MonoBehaviour
{

	public Transform target;

    void Update()
    {
		transform.LookAt(target);


    }
}
