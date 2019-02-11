using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public int PuzzleScore = 0;
    public int RiddleScore = 0;
    public int totalScore = 0;
    private GameObject Star_01;
    private GameObject Star_02;
    private GameObject Star_03;
    private GameObject Star_04;
    private GameObject Star_05;
    private GameObject Win_Explo_Prefab;

    private void Start()
    {
        Star_01 = GameObject.Find("Star_01");
        Star_02 = GameObject.Find("Star_02");
        Star_03 = GameObject.Find("Star_03");
        Star_04 = GameObject.Find("Star_04");
        Star_05 = GameObject.Find("Star_05");
        ScoreUpdater();
        Win_Explo_Prefab = Resources.Load("Fire_Explosion") as GameObject;
    }

    public void ScoreUp()
    {
        if(totalScore <= 4)
        {
            totalScore++;
            ScoreUpdater();
        }
    }
    public void ScoreDown()
    {
        if (totalScore >= 1)
        {
            totalScore--;
            ScoreUpdater();
        }
    }
    private void ScoreUpdater()
    {
        if (totalScore <= 0)
        {
            Star_01.SetActive(false);
            Star_02.SetActive(false);
            Star_03.SetActive(false);
            Star_04.SetActive(false);
            Star_05.SetActive(false);
            totalScore = 0;


        }
        else if (totalScore == 1)
        {
            //do action
            Star_01.SetActive(true);
            Star_02.SetActive(false);
            Star_03.SetActive(false);
            Star_04.SetActive(false);
            Star_05.SetActive(false);

           
        }
        else if (totalScore == 2)
        {
            //do action
            Star_01.SetActive(true);
            Star_02.SetActive(true);
            Star_03.SetActive(false);
            Star_04.SetActive(false);
            Star_05.SetActive(false);

            
        }
        else if (totalScore == 3)
        {
            //do action
            Star_01.SetActive(true);
            Star_02.SetActive(true);
            Star_03.SetActive(true);
            Star_04.SetActive(false);
            Star_05.SetActive(false);

            
        }
        else if (totalScore == 4)
        {
            //do action
            Star_01.SetActive(true);
            Star_02.SetActive(true);
            Star_03.SetActive(true);
            Star_04.SetActive(true);
            Star_05.SetActive(false);

            
        }
        else if (totalScore >= 5)
        {
            //do action
            Star_01.SetActive(true);
            Star_02.SetActive(true);
            Star_03.SetActive(true);
            Star_04.SetActive(true);
            Star_05.SetActive(true);

           
        }

    }
   
}
