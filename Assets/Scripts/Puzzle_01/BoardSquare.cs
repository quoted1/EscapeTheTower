using UnityEngine;
using System.Collections;

public class BoardSquare : MonoBehaviour
{
	public int timeBonus {get; set;}
	public bool toTest = false;  //indicates whether the square needs to be tested against a another
	public bool found = false; //indicates whether the square has already been matched

	public Texture2D[] images = new Texture2D[3];
	protected GameObject gameManager;

    private Color color; 
	

	protected virtual void Awake ()
	{
		images [0] = Resources.Load ("BlueCardback") as Texture2D;
		images [1] = Resources.Load ("Square") as Texture2D;
        images [2] = Resources.Load ("Square") as Texture2D;
        Debug.Log("image1,2,3 loaded");
        this.GetComponent<Renderer>().material.mainTexture = images[0];
        
        timeBonus = 3; 
	}

	protected virtual void Start() {
		this.GetComponent<Renderer>().material.mainTexture = images [0];
		gameManager = GameObject.Find("PuzzleController");
        color = new Color(1.0f, 0.0f, 0.0f, 0.1f);
    }

	protected virtual void OnMouseDown ()
	{
        gameManager.GetComponent<PuzzleController>().squaresSelected++;
		this.GetComponent<Renderer>().material.mainTexture = images [1];
		this.GetComponent<Collider>().enabled = false;
		toTest = true;
		onSquareSelected ();
        Debug.Log("mouseclicked");
	}

	protected virtual void onSquareSelected ()
	{
		gameManager.GetComponent<PuzzleController>().checkForPair();	//all checking for pairs happens in GameManager script
		Debug.Log("Square Selected");
	}

	//called from GameManager when a pair is matched
	public void changeSquareStatus(Color color){		
		this.color = color;
		updateEndGraphic();		
	}

	//changes square to found status
	protected virtual void updateEndGraphic ()
	{
		this.toTest=false;
		this.found = true;
		this.GetComponent<Renderer>().material.color = color;
		//this.GetComponent<Renderer>().material.mainTexture = images [2];	 
	}
	
	public virtual void resetSquare ()
	{	
		this.toTest = false;
		this.GetComponent<Renderer>().material.mainTexture = images [0];
		this.GetComponent<Collider>().enabled = true;
	}

	public void showSquare() {
		this.GetComponent<Renderer>().material.mainTexture = images [1];
	}

}
