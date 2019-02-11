using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSquare_04 : Puzzle_02_Controller {

	public void Pipe_Check()
	{
		if(this.transform.eulerAngles.y >= 89 && this.transform.eulerAngles.y <= 91)
		{
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[3] = true;
            Debug.Log("pipecorrect");
        }
        else
        {
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[3] = false;
            Debug.Log("pipewrong");
        }
    }
    public void RouteCheck()
    {
        GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().winCheck();
    }
}
