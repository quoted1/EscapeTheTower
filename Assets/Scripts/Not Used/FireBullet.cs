using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public GameObject Bullet;
	public Transform FirePos;
	public float FireStr;
	public Transform FireDir;
	public GameObject PlayerChar;

	//For the Cone
	public float ConeSize;
	float Width;
	float Height;

	void Update () {
		Width = Random.Range(-1f, 1f) * ConeSize;
		Height = Random.Range(-1f, 1f) * ConeSize;

		Vector3 FireDir = (GameObject.Find ("MainCamera").GetComponentInChildren<InteractionController> ().CrosshairCoords - this.transform.position).normalized;

		Debug.DrawRay (transform.position, FireDir, Color.blue);
			
		if (Input.GetMouseButtonDown (0)) 
		{
			GameObject bullet = Instantiate (Bullet, FirePos.transform.position, FirePos.transform.rotation) as GameObject;
			Physics.IgnoreCollision (bullet.GetComponent<SphereCollider> (), PlayerChar.GetComponent<CapsuleCollider> ());
			bullet.GetComponent<Rigidbody>().AddForce (FireDir * FireStr + transform.forward * Width + transform.up * Height);
		}
	}
}
