using UnityEngine;
using System.Collections;

public class perform_pressed : MonoBehaviour {
	private int rotated_flag = 0;
	private int need_recover_flag = 0;
	private AudioSource piano_note = null;
	private bool decrease_vol;
	public KeyCode the_key_code;
	// Use this for initialization
	void Start () {
		Transform child_pos = this.transform.GetChild(0);
		Vector3 child_position = child_pos.position;
		Vector3 s = child_position + new Vector3 (0.0f, 0.0f, -0.098436f);
		Vector3 old_pivot_pos = this.transform.position;

		this.transform.position = new Vector3(s.x,s.y,s.z);
		Vector3 b = child_pos.position - this.transform.position + old_pivot_pos;
		child_pos.position = new Vector3(b.x, b.y, b.z);
		rotated_flag = 0;
		need_recover_flag = 0;
		if (GetComponent<AudioSource> () != null) {
			piano_note = GetComponent<AudioSource> ();
			piano_note.playOnAwake = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (the_key_code) && rotated_flag == 0) {  
			this.transform.Rotate (Vector3.right * Time.deltaTime, 5f);
			rotated_flag = 1;
			need_recover_flag = 1;
		} else if (Input.GetKey (the_key_code))
			return;
		else if(need_recover_flag == 1){
			need_recover_flag = 0;
			rotated_flag = 0;
			this.transform.Rotate (Vector3.left * Time.deltaTime, 5f);
		}

		if (piano_note != null) {
			if (Input.GetKeyDown (the_key_code)) {
				piano_note.volume = 1.0f;
				piano_note.Play ();
			}
			if (Input.GetKeyUp (the_key_code)) {
				decrease_vol = true;
			}
			if (decrease_vol == true) {
				piano_note.volume -= piano_note.volume * 0.1f;
			}
		}
	}
}
