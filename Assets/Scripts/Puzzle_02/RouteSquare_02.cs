using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSquare_02 : Puzzle_02_Controller {

	public void Pipe_Check()
	{
        if (this.transform.eulerAngles.z >= 359 || this.transform.eulerAngles.z <= 1)
        {
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[1] = true;
            Debug.Log("pipecorrect");
        }
        else if (this.transform.eulerAngles.z >= 179 && this.transform.eulerAngles.z <= 181)
        {
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[1] = true;
            Debug.Log("pipecorrect");
        }
        else
        {
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[1] = false;
            Debug.Log("pipewrong");
        }
    }
    public void RouteCheck()
    {
        GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().winCheck();
    }
}
