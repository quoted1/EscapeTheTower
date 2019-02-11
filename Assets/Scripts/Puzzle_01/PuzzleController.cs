using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour {

	public int squaresSelected = 0;
	public int timeLeft;
	public int Lives;

	private bool gameWon = false;

    public Text livesLeftTextBox;
	public Text timeLeftTextBox;

	private GameObject gameController;

    void Start()
    {
        Lives = 3;
    }

	public void gameStart () {
		gameController = GameObject.Find ("GameController");

        gameWon = false;
		
		this.GetComponent<RandomGrid>().buildLevel(); //build the grid -- see RandomGrid.cs
		turnOnColliders();	//activate game board - switch on all colliders
		Invoke ("myTimer", 1.0f);

		timeLeftTextBox.text  = "Time Left: " + timeLeft;
		livesLeftTextBox.text = "Lives: " + Lives;

		gameController.GetComponent<GameController> ().brdsqrSet ();


	}

	public void myTimer() {
		timeLeft--;
		timeLeftTextBox.text = "Time Left: " + timeLeft;
		if (timeLeft > 0 && gameWon == false) {
			Invoke ("myTimer", 1.0f);
		} else if (gameWon == true) {
            Debug.Log("game won script");
            
            gameController.GetComponent<GameController>().puzzleEnd();
        }
        if (timeLeft <= 0 )
        {
            updateLives();
			gameController.GetComponent<GameController> ().puzzleRestart ();
			Debug.Log ("Restarting");
        }
        if (Lives == 0)
        {
            gameController.GetComponent<GameController>().puzzleEnd();
            Lives = 3;
            gameController.GetComponent<ScoreController>().ScoreDown();
        }
    }

	public void checkForPair() {	//checks the board for a matching pair	
		if(squaresSelected == 2) { //has player selected 2 squares
			squaresSelected=0; //reset counter
			BoardSquare[] squaresToTest = getAllSquaresToTest(); // get the 2 squares
			StartCoroutine(checkMatchingPairs(0.5f, squaresToTest)); //move to a coroutine - allows for 0.5secs to pass before checking
		}
	}

	private void updateLives()
    {
		Lives--;
		livesLeftTextBox.text = "Lives: " + Lives;
	}

	private IEnumerator checkMatchingPairs(float waitTime, BoardSquare[] squares)
    {
		turnOffColliders(); //makes board inactive, player can't keep pressing - this is called before the pause
		yield return new WaitForSeconds(waitTime); //pause


		if(squares[0].GetType() == squares[1].GetType())
        {
			Color color = new Color(0.0f,0.6f,0.0f, 0.25f);
			squares[0].changeSquareStatus(color); //update square 1 with found status -- see BoardSquare.cs
			squares[1].changeSquareStatus(color); //update square 2 with found status -- see BoardSquare.cs

			addMoreTime(squares[0].timeBonus);
		}
		else changeUnPairedSquaresToDefault(squares); //squares don't match - see method

		if(checkEndGame())
        { 
			gameWon = true;
			GlobalValues.PlayerTurns = Lives;
			GlobalValues.TimeLeft = timeLeft;
			Debug.Log ("PuzzleCompleted");
			

		}
		else
        {
			turnOnColliders();	//activate game board - switch on all colliders
		}
	}

	private void addMoreTime(int timeBonus) {
		timeLeft+=timeBonus;
	}

	public BoardSquare[] getAllSquaresToTest() {
		BoardSquare[] totest = new BoardSquare[2]; //create an array size 2 for the 2 squares selected
		int count = 0;
		BoardSquare[] squares = GameObject.FindObjectsOfType<BoardSquare> () as BoardSquare[];
		foreach (BoardSquare square in squares) {
			if (square.toTest && !square.found) { //only find squares that have the value toTest==true and not been found
				totest[count] = square; //add to array in slot 0 and then slot 1
				count++;
			}
		}
		return totest;
	}
 
	private void turnOnColliders() { //to activate gameboard turn on all colliders
		BoardSquare[] squares = GameObject.FindObjectsOfType<BoardSquare> () as BoardSquare[];
		foreach(BoardSquare square in squares) {
			if (!square.found) {
				square.GetComponent<Collider>().enabled = true;	
			}
		}
	}

	private void turnOffColliders() { //to deactivate gameboard turn on all colliders
		BoardSquare[] squares = GameObject.FindObjectsOfType<BoardSquare> () as BoardSquare[];
		foreach(BoardSquare square in squares) {
			if (!square.found) {
				square.GetComponent<Collider>().enabled = false;	
			}
		}
	}

	private void changeUnPairedSquaresToDefault(BoardSquare[] squares) { //squares don't match, need to reset square
		foreach (BoardSquare square in squares) {
			square.resetSquare(); //see method in BoardSquare.cs
		}
	}

	public bool checkEndGame() { //check to see if all squares have found set to true
		BoardSquare[] squares = GameObject.FindObjectsOfType<BoardSquare> () as BoardSquare[];
		foreach (BoardSquare square in squares) {
			if (!square.found) { //only find squares that have the value toTest==true and not been found
				return false;
			}
		}
		return true;
	}




}


