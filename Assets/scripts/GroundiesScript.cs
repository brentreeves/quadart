using UnityEngine;
using System.Collections;

public class GroundiesScript : MonoBehaviour {
    public float Rodcount;
    public float BEGINX = -9.0f;
    public float BEGINY = 0f;
    public float BEGINZ = -9.0f;
    public int CLUSTERSIZE = 3;
    public float CLUSTERSPACE = .6f;
    
    public ArrayList rods = new ArrayList ();

    private GameObject pattern;
    private GameObject aRod;
    private Color cc;

    void makeRow( float beginX, float beginY, float beginZ) {
					      
	//	pattern = Resources.Load ("Rod") as GameObject;
	pattern = Resources.Load ("RodSquare") as GameObject;
	for (int blocks=0; blocks< 32; blocks++) {
	    for (int i=0; i< CLUSTERSIZE; i++) {
		for (int j=0; j< CLUSTERSIZE; j++) {

		    // or... create one from scratch instead
		    //		    GameObject aRod = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		    //		    cylinder.transform.position = new Vector3(-2, 1, 0);
		    
		    Vector3 v;
		    float xx = (float) (i * CLUSTERSPACE);
		    float yy = (float) (j * CLUSTERSPACE);

		    cc.r = .1f;
		    cc.g = .1f;
		    cc.b = .1f;
		    for (int k=0; k<10; k++) {
			aRod = Instantiate (pattern);
			v = new Vector3 ( (float) (beginX + (1.0 * blocks * (CLUSTERSIZE * CLUSTERSPACE)) + xx), 
					  (float) (.5 + k), 
					  (float) (beginZ + (1.7 * blocks * (CLUSTERSIZE * CLUSTERSPACE)) + yy));
			aRod.transform.position = v;
			aRod.GetComponent<Renderer>().material.color = cc; // Color.grey;

			rods.Add ( (GameObject) aRod);
		    }

		    //			    }
		}
	    }
	}
    }

    // Use this for initialization
    void Start () {
	Debug.Log ("GroundScript Start()");

	makeRow(-30, 0, -100);
	makeRow(-50, 0, -76);
    }

    // Update is called once per frame
    void Update () {
	//	Debug.Log ("GroundiesScript Update() rods: " + rods.Count);
    }
}
