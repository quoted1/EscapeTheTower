using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_02_Controller : MonoBehaviour {

    public bool[] routeCheck = new bool[12];
    private bool puzzleFinished;


    // Use this for initialization
    void Start () {

        for (int i = 0; i < routeCheck.Length; i++)
        {
            routeCheck[i] = false;
        }
        puzzleFinished = false;
    }

    private bool Puzzle_02_win()
    {
        for (int i = 0; i < routeCheck.Length; ++i)
        {
            if (routeCheck[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public void winCheck()
    {
        if (Puzzle_02_win() == true && puzzleFinished == false)
        {
            Debug.Log("route correct");
            //win code
            GameObject.Find("GameController").GetComponent<ScoreController>().ScoreUp();
            puzzleFinished = true;
            GameObject.Find("Puzzle_02_Stream").SetActive(true);
        }
    }
}
