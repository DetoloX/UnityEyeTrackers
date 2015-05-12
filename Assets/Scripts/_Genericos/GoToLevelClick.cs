using UnityEngine;
using System.Collections;

public class GoToLevelClick : MonoBehaviour {
	public int level =0;
	// Use this for initialization
	void Start () {
	
	}


	void OnMouseDown () {
		Application.LoadLevel (level);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
