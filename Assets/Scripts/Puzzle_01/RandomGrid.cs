using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomGrid : MonoBehaviour {

	public GameObject boardSquare;
    public GameObject puzzleSpawn;

    private int[] grid = new int[12];

	public List<int> Cards = new List<int>
    {
        0,0,1,1,2,2,3,3,4,4,5,5
    };

	private int[] makeGrid() {

		for (int i=0; i<grid.Length; i++) {
			int pos = Random.Range (0,Cards.Count);
			grid[i] = Cards[pos];
			Cards.RemoveAt(pos);
		}

		return grid;
	}
	
	public void buildLevel() {
		int[] currentLayout = makeGrid();
		
		int rows = 0;
		int column = 0;
		
		for(int i = 0; i < currentLayout.Length; i++) {
			GameObject square = Instantiate (boardSquare) as GameObject;
			
			switch (currentLayout[i]){
			case 0:
				square.AddComponent<Card_01>();
				break;
			case 1:
				square.AddComponent<Card_02>();
				break;
			case 2:
				square.AddComponent<Card_03>();
				break;
			case 3:
				square.AddComponent<Card_04>();
				break;
			case 4:
				square.AddComponent<Card_05>();
				break;
			case 5:
				square.AddComponent<Card_06>();
				break;
            }
			
			square.transform.position = new Vector3 (puzzleSpawn.transform.position.x + rows*(square.GetComponent<Renderer>().bounds.size.x+.07f),
                                                     puzzleSpawn.transform.position.y, 
                                                     puzzleSpawn.transform.position.z - ((square.GetComponent<Renderer>().bounds.size.y + .2f) * column));

            square.transform.eulerAngles = new Vector3(180f, 90f, -180f);
			
			square.GetComponent<Collider>().enabled=false;
			
			column++;
			if (column==4) {
				column = 0;
				rows++;
			}
		}
	}
}
