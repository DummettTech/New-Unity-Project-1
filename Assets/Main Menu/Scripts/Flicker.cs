using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

	public float duration = 5.0f;
	public Light light;
	public float intec = 1.5f;

	void Start ()
	{
		light = GetComponent<Light> ();
	}
	

	void Update () 
	{


		float a = Time.time / duration * intec * Mathf.PI;
		float amplitude = Mathf.Cos (a) * 0.5f + 0.5f;
		light.intensity = amplitude;
	}
}
