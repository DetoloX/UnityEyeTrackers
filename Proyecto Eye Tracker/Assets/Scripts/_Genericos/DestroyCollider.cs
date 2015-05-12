using UnityEngine;
using System.Collections;

public class DestroyCollider : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Aim")
			Destroy (other.gameObject);
	}
}
