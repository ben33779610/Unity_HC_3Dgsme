using UnityEngine;

public class LearnArray : MonoBehaviour
{

	public		int[] a;

	public		float[] b;

	public Vector3[] c;

	public player[] d;

	public float[] e = new float[5];
	public string[] f = new string[] { "紅水", "藍水", "白水" };
	public Vector2[] g = { new Vector2(1, 0), new Vector2(2, 9) };

	private void Start()
	{
		print("道具" + f[0]);

		e[1] = 99.9f;

		print("VECTOR2數:"+g.Length);

		
	}
}
