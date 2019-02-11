using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	bool LoadingInitiated;
	GameObject[] PauseMenuObjects;
	public AudioSource Menuforward;
	public AudioSource Menubackward;
	public Text Scoretext;


	void Awake()
	{
		bool LoadingInitiated = false;
	}

	void Start ()
	{
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		PauseMenuObjects = GameObject.FindGameObjectsWithTag ("Menuitem");
		Hidepausemenu ();


		if (scene.buildIndex == 2) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		} else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}


	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (Time.timeScale == 1) 
			{
				//GameObject.Find ("FirePos").GetComponentInChildren<Gun> ().MenuOpengun = true;
				Time.timeScale = 0;
				Showpausemenu ();
				Debug.Log ("Menu shown");
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Debug.Log ("cursor unlocked");
			}
			else if (Time.timeScale == 0) 
			{
				//GameObject.Find ("FirePos").GetComponentInChildren<Gun> ().MenuOpengun = false;
				Time.timeScale = 1;
				Hidepausemenu ();
				Debug.Log ("Menu Hidden");
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Debug.Log ("Cursor locked");
			}
		}
		//Scoretext.text = GameObject.Find ("GameController").GetComponentInChildren<GameController> ().Killed + "/10";
	}

	public void Showpausemenu ()
	{
		foreach (GameObject Menuitem in PauseMenuObjects) 
		{
			Menuitem.SetActive (true);
		}
	}

	public void Hidepausemenu ()
	{
		foreach (GameObject Menuitem in PauseMenuObjects) 
		{
			Menuitem.SetActive (false);
		}
	}

	public void RestartClick ()
	{
		if (!LoadingInitiated) 
		{
			StartCoroutine (Restartload ());
			LoadingInitiated = true;
		}
	}
	IEnumerator Restartload()
	{
		Time.timeScale = 1;
		Menubackward.Play();
		yield return new WaitForSeconds (Menubackward.clip.length);
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
		Debug.Log ("scene restarted");
	}

	public void StartgameClick ()
	{
		if (!LoadingInitiated) 
		{
			StartCoroutine (Startgameload ());
			LoadingInitiated = true;
		}
	}
	IEnumerator Startgameload()
	{
		Time.timeScale = 1;
		Menuforward.Play();
		yield return new WaitForSeconds (Menuforward.clip.length);
		SceneManager.LoadScene (2);
		Debug.Log ("Game started");
	}

	public void InfoscreenClick ()
	{
		if (!LoadingInitiated) 
		{
			StartCoroutine (Infoscreenload ());
			LoadingInitiated = true;
		}
	}
	IEnumerator Infoscreenload()
	{
		Time.timeScale = 1;
		Menuforward.Play();
		yield return new WaitForSeconds (Menuforward.clip.length);
		SceneManager.LoadScene (1);
		Debug.Log ("Infoscreen loaded");
	}

	public void loadmenuClick ()
	{
		if (!LoadingInitiated) 
		{
			StartCoroutine (loadmenuload ());
			LoadingInitiated = true;
		}
	}
	IEnumerator loadmenuload()
	{
		Time.timeScale = 1;
		Menubackward.Play();
		yield return new WaitForSeconds (Menubackward.clip.length);
		SceneManager.LoadScene (0);
		Debug.Log ("Menuscreen loaded");
	}
		
	public void ExitgameClick ()
	{
		if (!LoadingInitiated) 
		{
			StartCoroutine (ExitgameLoad ());
			LoadingInitiated = true;
		}
	}
	IEnumerator ExitgameLoad()
	{
		Time.timeScale = 1;
		Menubackward.Play();
		yield return new WaitForSeconds (Menubackward.clip.length);
		Application.Quit ();
	}

}
