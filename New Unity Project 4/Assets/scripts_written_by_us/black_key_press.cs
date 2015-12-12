using UnityEngine;
using System.Collections;

public class black_key_press : MonoBehaviour {
	private int rotated_flag = 0;
	private int need_recover_flag = 0;
	public KeyCode the_key_code;
	AudioSource thesource = null;
	// Use this for initialization
	void Start () {
		Transform child_pos = this.transform.GetChild(0);
		Vector3 child_position = child_pos.position;
		Vector3 s = child_position + new Vector3 (0.0f, 0.0f, -0.046f);
		Vector3 old_pivot_pos = this.transform.position;
		
		this.transform.position = new Vector3(s.x,s.y,s.z);
		Vector3 b = child_pos.position - this.transform.position + old_pivot_pos;
		child_pos.position = new Vector3(b.x, b.y, b.z);
		rotated_flag = 0;
		need_recover_flag = 0;

		thesource = GetComponent<AudioSource> ();
		thesource.playOnAwake = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (the_key_code) && rotated_flag == 0) {  
			this.transform.Rotate (Vector3.right * Time.deltaTime, 5f);
			rotated_flag = 1;
			need_recover_flag = 1;
		} else if (Input.GetKey (the_key_code))
			return;
		else if (need_recover_flag == 1) {
			need_recover_flag = 0;
			rotated_flag = 0;
			this.transform.Rotate (Vector3.left * Time.deltaTime, 5f);
		}

		if (Input.GetKeyDown (the_key_code)) {
			thesource.Play ();
		}
		if (Input.GetKeyUp (the_key_code)) {
			thesource.Stop ();
		}
	}
}