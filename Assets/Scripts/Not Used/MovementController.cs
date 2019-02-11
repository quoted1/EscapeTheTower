using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

    public Rigidbody PRB;
    public float MaxwalkSpeed;
    private float Gravity = -9.81f;
    private bool isGrounded;
    private Vector3 MaxwlkSpdFwd;
    private Vector3 MaxwlkSpdBck;
    private Vector3 MaxwlkSpdLft;
    private Vector3 MaxwlkSpdRgt;
    private Vector3 GrndChkCtr;
    private Vector3 GrndChkCtrOffset;

    void Start()
    {
        PRB = GetComponent<Rigidbody>();
        Debug.Log("rigidbody set");
        PRB.freezeRotation = true;
        MaxwlkSpdFwd = new Vector3(0, PRB.velocity.y, MaxwalkSpeed);
        MaxwlkSpdBck = new Vector3(0, PRB.velocity.y, -MaxwalkSpeed);
        MaxwlkSpdLft = new Vector3(-MaxwalkSpeed, PRB.velocity.y, 0);
        MaxwlkSpdRgt = new Vector3(MaxwalkSpeed, PRB.velocity.y, 0);

    }

    void FixedUpdate()
    {
        //forward & backwards
        if (Input.GetKey(KeyCode.W))
        {
            PRB.velocity = transform.forward * MaxwalkSpeed;
            Debug.Log("moving forward" + PRB.velocity);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PRB.velocity = transform.forward * -MaxwalkSpeed;
            Debug.Log("moving backwards" + PRB.velocity);
        }
        else if (isGrounded == false)
        {
            Debug.Log("Falling");
            PRB.AddForce(transform.up * Gravity);
            //PRB.velocity = transform.up * Gravity;
        }

        //Left & Right
        if (Input.GetKey(KeyCode.A))
        {
            PRB.velocity = transform.right * -MaxwalkSpeed;
            Debug.Log("moving left" + PRB.velocity);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PRB.velocity = transform.right * MaxwalkSpeed;
            Debug.Log("moving right" + PRB.velocity);
        }
        else if (isGrounded == false)
        {
            Debug.Log("Falling");
            PRB.AddForce(transform.up * Gravity);
            //PRB.velocity = transform.up * Gravity;
        }

        //Forward & left or forward & right
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            PRB.velocity = transform.forward * MaxwalkSpeed + transform.right * -MaxwalkSpeed;
            Debug.Log("moving left" + PRB.velocity);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            PRB.velocity = transform.forward * MaxwalkSpeed + transform.right * MaxwalkSpeed;
            Debug.Log("moving right" + PRB.velocity);
        }
        else if (isGrounded == false)
        {
            Debug.Log("Falling");
            PRB.AddForce(transform.up * Gravity);
            //PRB.velocity = transform.up * Gravity;
        }

        //Backward & left or Backward & right
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            PRB.velocity = transform.forward * -MaxwalkSpeed + transform.right * -MaxwalkSpeed;
            Debug.Log("moving left" + PRB.velocity);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            PRB.velocity = transform.forward * -MaxwalkSpeed + transform.right * MaxwalkSpeed;
            Debug.Log("moving right" + PRB.velocity);
        }
       else if (isGrounded == false)
        {
            Debug.Log("Falling");
            PRB.AddForce(transform.up * Gravity);
            //PRB.velocity = transform.up * Gravity;
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Walkable")
        {
            Debug.Log("Grounded");
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Walkable")
        {
            Debug.Log("!Grounded");
            isGrounded = false;
        }
    }
}