using UnityEngine;
using System.Collections;

public class colorful_keys : MonoBehaviour {
	
	public KeyCode the_key_code;
	public Material[] materials;
	public bool glow_flag;
	private Renderer rend;
	//private int pressed_flag = 0;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		glow_flag = false;
		//pressed_flag = 0;
		rend.material = materials[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(glow_flag)
			rend.material = materials[1];
		else 
			rend.material = materials[0];
		return; 
	}
	/*	if (materials.Length == 0)
			return;


		if(pressed_flag == 0 && Input.GetKeyDown (the_key_code))
		{
			rend.material = materials[1];
			pressed_flag = 1;
		}
		else if(Input.GetKeyUp (the_key_code)) {
			rend.material = materials[0];
			pressed_flag = 0;
		}

	}*/

}

