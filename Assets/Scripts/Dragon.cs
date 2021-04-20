using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public Sprite newSprite;

    public bool dragonTrigger = false; 
    public bool dragonDied = false;

    // Update is called once per frame
    void Update() 
    {   
    	if(dragonTrigger && Input.GetKeyDown(KeyCode.E) && dragonDied == false) 
	{
		DragonDie();
	}
    }
    
    void OnTriggerEnter(Collider dragon)
    {
     	if (dragon.CompareTag("Player"))
	{
		dragonTrigger = true;
	}
    }
    
    void DragonDie()
    {
    	transform.Translate(0f, -2.5f, 0f);
    	dragonDied = true;
    	spriteRenderer.sprite = newSprite;
        StartCoroutine(WaitJustABit());
    }

    IEnumerator WaitJustABit()
    {
        Debug.Log("oui");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
}
