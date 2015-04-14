using UnityEngine;
using System.Collections;

public class ren : MonoBehaviour {


	public static MeshRenderer mesh;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		mesh = GetComponent<MeshRenderer> ();

		mesh.enabled = false;
	}
}
