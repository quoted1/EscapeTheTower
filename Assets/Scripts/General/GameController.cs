using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private GameObject[] PuzzleObjects;
    private GameObject[] PlayerObjects;
	private GameObject[] BoardSquares;
	private GameObject PuzzleCam;
    private bool Puzzle_01_Complete;
    private GameObject Win_Explo_Prefab;
    private bool PuzzleWon;

    private AudioSource wrongAnswerFart;

    void Start ()
    {

		PuzzleCam = GameObject.Find ("Puzzle_01_Camera");

        PuzzleObjects = GameObject.FindGameObjectsWithTag("PuzzleObject");
        foreach(GameObject i in PuzzleObjects)
        {
            i.SetActive(false);
        }
		PuzzleCam.SetActive (false);

		PlayerObjects = GameObject.FindGameObjectsWithTag ("Player");

        Puzzle_01_Complete = false;

        Win_Explo_Prefab = Resources.Load("Fire_Explosion") as GameObject;

        PuzzleWon = false;

        wrongAnswerFart = GameObject.Find("WrongAnswerFart").GetComponent<AudioSource>();

    }

    public void puzzleStart()
    {
        if (Puzzle_01_Complete == false)
        {
            PuzzleCam.SetActive(true);
            foreach (GameObject i in PuzzleObjects)
            {
                i.SetActive(true);
                Debug.Log("puzzle obj shown");
            }

            foreach (GameObject e in PlayerObjects)
            {
                e.SetActive(false);
                Debug.Log("player obj hidden");
            }
            //unLock cursor for puzzle
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log(Camera.main.name);

            GameObject.Find("PuzzleController").GetComponent<PuzzleController>().gameStart();

        }
        else
        {
            PuzzleCam.SetActive(true);
            foreach (GameObject i in PuzzleObjects)
            {
                i.SetActive(true);
                Debug.Log("puzzle obj shown");
            }

            foreach (GameObject e in PlayerObjects)
            {
                e.SetActive(false);
                Debug.Log("player obj hidden");
            }

            //unLock cursor for puzzle
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log(Camera.main.name);

            puzzleRestart();
        }
    }

	public void brdsqrSet()
	{
		BoardSquares = GameObject.FindGameObjectsWithTag ("BoardSquare");
		Debug.Log (BoardSquares.Length);
	}

	public void puzzleEnd()
	{
        PuzzleCam.SetActive(false);
		foreach (GameObject i in PuzzleObjects)
		{
			i.SetActive(false);
			Debug.Log("puzzle obj hidden");
		}
        
        foreach (GameObject e in PlayerObjects)
		{
			e.SetActive(true);
			Debug.Log("player obj shown");
		}

        Puzzle_01_Complete = true;

        GameObject Win_Explo = Win_Explo_Prefab;
        GameObject Win_Explo_Clone =  Instantiate(Win_Explo, GameObject.Find("Puzzle_01_Explo").transform) as GameObject;
        DestroyObject(Win_Explo_Clone, 4.0f);

        if (PuzzleWon == false)
        {
            PuzzleWon = true;
            GameObject.Find("GameController").GetComponent<ScoreController>().ScoreUp();
        }
        
    }

	public void puzzleRestart()
	{

        foreach (GameObject b in BoardSquares)
        {
            Destroy(b);
            Debug.Log("deleting squares");
        }

        GameObject.Find("PuzzleController").GetComponent<RandomGrid>().Cards = new List<int>{0,0,1,1,2,2,3,3,4,4,5,5};
        GameObject.Find("PuzzleController").GetComponent<PuzzleController>().gameStart();
        GameObject.Find("PuzzleController").GetComponent<PuzzleController>().timeLeft = 30;

    }

    public void WrongAnswerFartStart()
    {
        StartCoroutine(WrongAnswerFart()); 
    }
    IEnumerator WrongAnswerFart()
    {
        wrongAnswerFart.Play();
        yield return new WaitForSeconds(wrongAnswerFart.clip.length);
    }
}
