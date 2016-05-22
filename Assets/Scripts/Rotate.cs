using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public bool rotate;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (rotate)
        {
            transform.Rotate(new Vector3(0f, 0f, speed));
        }


	}
}
