using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour {

	public RaycastHit Hit;
	public Vector3 CrosshairCoords;
    private bool HoldingObj;
    private GameObject Obj;
    private GameObject HeldObj;
    private string HeldObjName;
    private Transform HeldObjTrans;
    private int PlayerLayerMask = 1 << 8;

    public Image Crosshair;
    public Sprite Crosshair_01;
    public Sprite Crosshair_02;

    public Text keycode_Prompt;

    //for object rotation
    private float mouseX;
    private float mouseY;
    private Vector3 HeldObjVector3 = Vector3.zero;
    public float mouseSens = 3;

    //Riddle complete Controls
    private bool Riddle_Clock = false;
    private bool Riddle_Candle = false;
    private bool Riddle_Envelope = false;

    private GameObject ESCMenu;
    public bool ESCMenuB;

    [SerializeField]
    private Vector2 mouseLimit = new Vector2(80, 280);

    void Start()
    {
        keycode_Prompt = GameObject.Find("Keycode_Prompt").GetComponent<Text>();
        keycode_Prompt.text = "";
        //if holding object check
        HoldingObj = false;
        ESCMenuB = false;
        ESCMenu = GameObject.Find("ESCMenu");
        ESCMenu.SetActive(false);
    }

    void FixedUpdate () 
	{
        //raycasting
		Vector3 Fwd = this.transform.forward;
		Debug.DrawRay (transform.position, Fwd*2f, Color.yellow);
		Physics.Raycast (transform.position, Fwd, out Hit, 2f, ~PlayerLayerMask);
		CrosshairCoords = Hit.point;

        //input interactions
        if (Input.GetKeyUp(KeyCode.E) )
        {
            Debug.Log("E Pressed");
            ObjInteraction();
        }
        if (Input.GetKey(KeyCode.Mouse0) && HoldingObj == true)
        {
            Debug.Log("rotating obj");
            this.gameObject.GetComponentInParent<FirstPersonController>().LockMovement = true;
            ObjRotation();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            this.gameObject.GetComponentInParent<FirstPersonController>().LockMovement = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            RiddleCheck();
            Debug.Log("riddlecheck");
        }
        if (Input.GetKeyUp(KeyCode.Escape) && ESCMenuB == true)
        {
            Debug.Log("MenuClosed");
            ESCMenu.SetActive(false);
            //GameObject.Find("Player_HUD_Canvas").SetActive(true);
            ESCMenuB = false;
        }
        if (Input.GetKeyUp(KeyCode.Escape) && ESCMenuB == false)
        {
            Debug.Log("MenuOpened");
            ESCMenu.SetActive(true);
            //GameObject.Find("Player_HUD_Canvas").SetActive(true);
            ESCMenuB = true;
        }


        //raycast interactions
        if (Hit.transform == null && keycode_Prompt.text != "")
        {
            keycode_Prompt.text = "";
            Spritechange_01();
            Debug.Log("hit.null.elseif");
        }
        else if (Hit.transform != null)
        {
            if(Hit.transform.gameObject.tag == "Interactable" || Hit.transform.gameObject.tag == "PuzzleTrigger" || Hit.transform.gameObject.tag == "SmallRiddleObject" || Hit.transform.gameObject.tag == "LargeRiddleObject")
            {
                Spritechange_02();
                //Debug.Log ("sprite_02");

                if (Hit.transform.gameObject.tag == "Interactable" || Hit.transform.gameObject.tag == "SmallRiddleObject")
                {
                    keycode_Prompt.text = "Pickup [E]";
                }
                if (Hit.transform.gameObject.tag == "PuzzleTrigger")
                {
                    keycode_Prompt.text = "Start [E]";
                }
            }
        }
        else if (keycode_Prompt.text != "")
        {
            keycode_Prompt.text = "";
            Spritechange_01();
            Debug.Log("hit.null.else");
        }
        
        
	}

    void ObjInteraction()
    {
        //to pick up an object
        if (HoldingObj == false)
        {
            Obj = Hit.transform.gameObject;
            HeldObjName = Obj.name;
            if (Obj.tag == "Interactable" || Obj.tag == "SmallRiddleObject")
            {
                Debug.Log(HeldObjName + " Picked Up");
                Destroy(Obj);
                HeldObj = Instantiate(Obj, this.transform.Find("HoldPoint").position, this.transform.Find("HoldPoint").rotation, this.transform.Find("HoldPoint")) as GameObject;
                Destroy(HeldObj.GetComponent<Rigidbody>());
                HeldObj.name = "HeldObj";
                HoldingObj = true;
                HeldObjTrans = HeldObj.transform;
                //return;
            }
        }
        else if (HoldingObj == true)
        {
            Debug.Log("Dropped" + HeldObjName);
            Destroy(HeldObj);
            HeldObj = Instantiate(HeldObj, this.transform.Find("HoldPoint").position, this.transform.Find("HoldPoint").rotation) as GameObject;
            HeldObj.AddComponent<Rigidbody>();
            HeldObj.name = HeldObjName;
            HoldingObj = false;
        }

        if (Obj.tag == "PuzzleTrigger")
        {
            GameObject.Find("GameController").GetComponent<GameController>().puzzleStart();

        }

		if (Obj.tag == "Puzzle_02_Pipe")
		{
			Obj.transform.localEulerAngles += new Vector3(0,90,0);
            Obj.SendMessage("Pipe_Check");
            Obj.SendMessage("RouteCheck");
            Debug.Log("piperotated");

        }
    }

    void RiddleCheck()
    {
       
        //start of riddle check
        if (HoldingObj == true)
        {
            if (HeldObj.tag == "SmallRiddleObject")
            {
                Debug.Log(HeldObjName);
                if (HeldObjName == "Candle" && Riddle_Candle == false || HeldObjName == "Envelope" && Riddle_Envelope == false)
                {
                    Debug.Log("RiddleSolved");
                    GameObject.Find("GameController").GetComponent<ScoreController>().ScoreUp();

                    if (HeldObjName == "Candle")
                    {
                        Riddle_Candle = true;
                    }
                    if (HeldObjName == "Envelope")
                    {
                        Riddle_Envelope = true;
                    }
                }
            }
            else //if heldobj isnt a riddle answer or riddle already complete
            {
                if (HeldObjName == "Candle" || HeldObjName == "Envelope")
                {
                    Debug.Log("you have already completed that riddle");
                    GameObject.Find("GameController").GetComponent<GameController>().WrongAnswerFartStart();
                }
                else if (HeldObjName != "Candle" || HeldObjName != "Envelope")
                {
                    Debug.Log("That is not the answer");
                    GameObject.Find("GameController").GetComponent<ScoreController>().ScoreDown();
                    GameObject.Find("GameController").GetComponent<GameController>().WrongAnswerFartStart();
                }
            }
        }
        else if (Hit.transform.name == "Clock" && Riddle_Clock == false)
            {
                Debug.Log("RiddleSolved");
                GameObject.Find("GameController").GetComponent<ScoreController>().ScoreUp();
                if (Hit.transform.gameObject.name == "Clock")
                {
                    Riddle_Clock = true;
                }
            }
        }

    void Spritechange_01()
    {
        Crosshair.sprite = Crosshair_01;
    }
    void Spritechange_02()
    {
        Crosshair.sprite = Crosshair_02;
    }

    void ObjRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        HeldObjVector3 = HeldObjTrans.eulerAngles;

        HeldObjVector3.y += mouseX * mouseSens;
        HeldObjVector3.x += -mouseY * mouseSens;

        HeldObjTrans.eulerAngles = HeldObjVector3;
    }
}
