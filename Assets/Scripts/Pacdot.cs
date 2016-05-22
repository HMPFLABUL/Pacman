using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {

    
    void Start()
    {
       SpriteRenderer s = gameObject.GetComponent<SpriteRenderer>();
        s.sprite = GameManager.dotsSprites[Random.Range(0, GameManager.dotsSprites.Count)]; 
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "pacman")
		{
			GameManager.score += 10;
		    GameObject[] pacdots = GameObject.FindGameObjectsWithTag("pacdot");
            gameObject.SetActive(false);
            //Debug.Log(pacdots.Length);
		    if (pacdots.Length == 1)
		    {
		        GameObject.FindObjectOfType<GameGUINavigation>().LoadLevel();
                GameManager.rekt.Play();

		    }
		}
	}
}
