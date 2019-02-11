using UnityEngine;
using System.Collections;

public class Selfdestruct : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		Destroy (gameObject, 2f);
	}

	void OnCollisionEnter (Collision col)
	{
		Destroy (gameObject);
	}
}
