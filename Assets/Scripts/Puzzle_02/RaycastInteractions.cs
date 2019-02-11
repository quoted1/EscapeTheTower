using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractions : MonoBehaviour {

	public RaycastHit Hit;
	public Vector3 CrosshairCoords;
	private int PlayerLayerMask = 1 << 8;
	private GameObject Obj;

	void FixedUpdate ()
	{
		//raycasting
		Vector3 Fwd = this.transform.forward;
		Debug.DrawRay (transform.position, Fwd * 2f, Color.yellow);
		Physics.Raycast (transform.position, Fwd, out Hit, 2f, ~PlayerLayerMask);
		CrosshairCoords = Hit.point;

		//input interactions
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			Debug.Log ("E Pressed");
			ObjInteraction ();
		}
	}

	void ObjInteraction()
	{
		//to pick up an object
		Obj = Hit.transform.gameObject;
		if (Obj.tag == "Interactable") 
		{
			Debug.Log ("object interacted");
			// collection code goes here
		}
	}


}
