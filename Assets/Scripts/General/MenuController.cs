using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public Canvas MainCanvas;

	public void LoadPortfolio1()
	{
		SceneManager.LoadScene (1);
	}
	public void LoadPortfolio2()
	{
		SceneManager.LoadScene (2);
	}
	public void LoadPortfolio3()
	{
		SceneManager.LoadScene (3);
	}
	public void LoadPortfolio4()
	{
		SceneManager.LoadScene (4);
	}
		
}
