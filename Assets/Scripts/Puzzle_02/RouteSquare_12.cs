using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteSquare_12 : Puzzle_02_Controller {

	public void Pipe_Check()
	{
		if(this.transform.eulerAngles.z >= 89 && this.transform.eulerAngles.z <= 91)
		{
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[11] = true;
            Debug.Log("pipecorrect");
        }
        else if (this.transform.eulerAngles.z >= 269 && this.transform.eulerAngles.z <= 271)
        {
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[11] = true;
            Debug.Log("pipecorrect");
        }
        else
        {
            GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().routeCheck[11] = false;
            Debug.Log("pipewrong");
        }
    }
    public void RouteCheck()
    {
        GameObject.Find("Puzzle_02").GetComponent<Puzzle_02_Controller>().winCheck();
    }
}
