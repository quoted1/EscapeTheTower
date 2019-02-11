using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSquare_06 : Puzzle_02_Controller {

	public void Pipe_Check()
	{
		if(this.transform.eulerAngles.y >= 269 && this.transform.eulerAngles.y <= 271)
		{
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[5] = true;
            Debug.Log("pipecorrect");
        }
        else
        {
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[5] = false;
            Debug.Log("pipewrong");
        }
    }
    public void RouteCheck()
    {
        GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().winCheck();
    }
}