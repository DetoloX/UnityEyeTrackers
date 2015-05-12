using UnityEngine;
using System.Collections;

abstract  class GameController  {
	private float vida;
	// Use this for initialization
	void Start () {
	
	}

	public float Vida
	{
		get { return vida; }
		set { vida = value; }
	}


	// Update is called once per frame
	void Update () {
	
	}


	protected virtual int RestarVida()
	{
		Debug.Log("esto es del GameController");
		return 0;
	}


}
