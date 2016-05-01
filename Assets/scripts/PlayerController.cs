using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int rodCount;
    private GameObject ground;
    private GroundiesScript groundiesScript;
    private ArrayList rods;
    private float rr;
    private GameObject aRod;

    // Use this for initialization
    void Start () {
	rb = GetComponent<Rigidbody> ();
	ground = GameObject.Find("Ground");
	groundiesScript = ground.GetComponent<GroundiesScript>();
	rods = groundiesScript.rods;
    }
	
    // Update is called once per frame
    void Update () {

	//	    mess with some lights
    }

    void FixedUpdate () {
	if (Input.GetKeyDown("z")) {
	    int rodCount = groundiesScript.rods.Count;
	    Debug.Log("z key pressed: " + rodCount);

	    for (int i=0; i< 10; i++) {
		float rr = Random.Range(0F, 1.0F);
		int ir = (int) Mathf.Floor( rr * rodCount );
		//		Debug.Log("z updating item " + ir);
		//		aRod = (GameObject) groundiesScript.rods[ ir ];
		//		aRod.GetComponent<Renderer>().material.color = Color.white;
		aRod = (GameObject) rods[ ir ];
		aRod.GetComponent<Renderer>().material.color = Color.white;
	    }
	    
	}
	if (Input.GetKeyDown("x")) {
	    int rodCount = groundiesScript.rods.Count;

	    Debug.Log("x key pressed: " + rodCount);
	    
	    for (int i=0; i < rodCount; i++) {
		aRod = (GameObject) rods [ i ];
		aRod.GetComponent<Renderer>().material.color = Color.black;
	    }
	}

	float moveHorizontal = Input.GetAxis ("Horizontal");
	float moveVertical = Input.GetAxis ("Vertical");
	Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
	rb.AddForce (movement * speed);
    }

}
