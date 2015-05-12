using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
	public float health = 0f;	
	private Transform player;		// Reference to the player.

	private Vector3 healthScale;	
	private SpriteRenderer healthBar;	
//	public GameObject prueba;
	void Awake ()
		{
			// Setting up the reference.
			healthBar = GetComponent<SpriteRenderer>();
//		player = prueba.transform;

			player = this.transform.parent.transform;
			healthScale = healthBar.transform.localScale;
		
	}

	public void QuitarVida(float vida){
		health += vida;
	}
		
	public void ReponeVida(){
		health = 0;
	}
	void Update ()
	{
		// Set the position to the player's position with the offset.


			transform.position = player.position + offset;
	
		
	
	/*transform.localScale = new Vector3(
	transform.material.color = Color.Lerp(Color.green, Color.red, 1 - curHealth * 0.01f);
		
		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);*/
		healthBar.material.color = Color.Lerp (Color.black, Color.green, 1 + health * 0.3f); //0.008f);
		
		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.004f, 1, 1);

	}



	/*
	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBarLength;
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width /2;
	}
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
	}
	void OnGUI(){

		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);
		
	//	GUI.Box(new Rect(targetPos.x, targetPos.y, 60, 20), curHealth + "/" + maxHealth);


		GUI.Box (new Rect(targetPos.x,targetPos.y, healthBarLength, 20), curHealth + "/" + maxHealth);
	}
	public void AddjustCurrentHealth(int adj){
		curHealth += adj;
		if(curHealth <0)
			curHealth = 0;
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		if(maxHealth <1)
			maxHealth = 1;
		healthBarLength =(Screen.width /2) * (curHealth / (float)maxHealth);
	}*/
}
