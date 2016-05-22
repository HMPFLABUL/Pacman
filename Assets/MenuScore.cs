using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScore : MonoBehaviour {

    Text t;
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
        t.text = "HIGH SCORE: "+ + PlayerPrefs.GetInt("HS");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
