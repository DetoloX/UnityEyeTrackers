using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioListener))]
[RequireComponent(typeof(AudioSource))]
public class MusicaSingleton: MonoBehaviour {


	private static MusicaSingleton instance = null;
	public static MusicaSingleton Instance {
			get
			{
				if (instance == null)
				{
				instance = (MusicaSingleton)FindObjectOfType(typeof(MusicaSingleton));
				}
				return instance;
			}
		}
		
		public void Play() {
			GetComponent<AudioSource> ().Play ();
		}
		
		
		public void Stop() {
			GetComponent<AudioSource> ().Stop ();
		
		}
	public bool IsPlaying(){
		AudioSource audio = GetComponent<AudioSource>();
		return audio.isPlaying;
	}


	void Awake() {
		if (instance != null && instance != this) {
			Destroy(gameObject); return; 
		} else { 
			instance = this; 
			DontDestroyOnLoad(gameObject);
		}

	}
}