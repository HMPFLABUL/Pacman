using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameToTitle : MonoBehaviour {

	public Text title;


    void Start()
    {
    }
	void OnMouseEnter()
	{
		switch(name)
		{
		case "HMPFLABUL":
			title.color = Color.yellow;
			break;

		case "HOBBYS":
			title.color = Color.red;
			break;

		case "STUDY":
			title.color = new Color(254f/255f, 152f/255f, 203f/255f);
			break;

		case "GYM":
			title.color = Color.cyan;
			break;

		case "CHORES":
			title.color = new Color(254f/255f, 203f/255f, 51f/255f);
			break;
		}
		
		title.text = name;
	}

	void OnMouseExit()
	{
		title.text = "Pac-Man Clone";
		title.color = Color.white;
	}
}
