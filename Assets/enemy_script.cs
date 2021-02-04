using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_script : MonoBehaviour {
     GameObject player;
	 float speed = 40f;
	 float end_pos_x = -9;
	 public int tier;

	 public int move_type;
	 public int leave_type;
	 public int color_var;

	 float time_to_wait = 2f;

	float time_up = 0.4f;
	float time_sides;
	int state;
	UI_enemy_count UI_script;
	float distance;
	float move_speed = 4.5f;

	int loop_max;

    float player_dist = 5f;

	int loop = 0;
	IEnumerator change_state;
	IEnumerator coroutine;

	 int queue;

    
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		UI_script = GameObject.FindWithTag("UI_count").GetComponent<UI_enemy_count>();
		state = 1;        
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += transform.forward * speed * (Time.deltaTime);

        if (this.transform.position.z < player.transform.position.z - 200f) {
            FlyControl script = player.transform.GetChild(0).GetComponent<FlyControl>();

            script.life = script.life - 5f;
			Destroy(this.gameObject);
		}

		switch (state)
        {
			
        case 1:
			if (transform.position.x > end_pos_x){
				transform.position += transform.right * -speed * (Time.deltaTime);
			}
			if(this.transform.position.z < player.transform.position.z + player_dist){
				speed = 50f;
				state += 1;
			}
			break;
		case 2:
			change_state = state_change(time_to_wait);
			StartCoroutine(change_state);
			state += 1;
			break;
		case 3:
			break;
		case 4:
			int mod;
			if (loop%2 ==0 ){
				mod = 2;
			} else {
				mod = 1;
			}
			change_state = state_change(time_up*mod);
			StartCoroutine(change_state);
			state += 1;
			break;
		case 5:
			if (move_type == 0){
				transform.position += transform.up * -move_speed * (Time.deltaTime);
			} else {
				transform.position += -transform.up * -move_speed * (Time.deltaTime);
			}
			break;
		case 6:
			change_state = state_change(time_sides);
			StartCoroutine(change_state);
			state += 1;
			break;
		case 7:
			int mod2;
			if (loop%2 ==0 ){
				mod2 = -1;
			} else {
				mod2 = 1;
			}
			if (move_type == 0){
				transform.position += transform.right * -move_speed * (Time.deltaTime) * mod2;
			} else {
				transform.position += -transform.right * -move_speed * (Time.deltaTime) * mod2;
			}
			break;
		case 8:
			change_state = state_change(time_up * 2);
			StartCoroutine(change_state);
			state += 1;
			break;
		case 9:
			if (move_type == 0){
				transform.position += -transform.up * -move_speed * (Time.deltaTime);
			} else {
				transform.position += transform.up * -move_speed * (Time.deltaTime);
			}
			break;
		case 10:
		 	loop += 1;
			 if (loop < loop_max){
				 state = 4;
			 } else {
				 state += 1;
			 }			
			break;
		case 11:
			speed -= 1f;
			break;

    	}
	}

	public IEnumerator state_change(float waitTime){
		yield return new WaitForSeconds(waitTime);
		state += 1;
		if (transform.position.x > end_pos_x){
			transform.position += transform.right * -speed/2 * (Time.deltaTime);
		}

		if(this.transform.position.z < player.transform.position.z + 20f){
			speed = 50f;
		}

    	}

	public void set_end_pos_x (float pos_x) {
		end_pos_x = pos_x;
	}

public void set_loop (int times) {
		loop_max = times;
	}

	public void set_dist(float dist){
		distance = dist;
		time_sides = dist * 0.2f;
		time_up = dist * 0.05f;
	}

	public void set_playerdist(float dist){
		player_dist = dist;
	}
	public void set_timing(float timing){
		time_to_wait -= timing;
	}

	public void set_tier (int set) {
		tier = set;
	}

	public void set_type (int t1, int t2) {
		move_type = t1;
		leave_type = t2;
	}
    
	public void set_color (int color_var) {
		Color32 color =  new Color32(255, 255, 255, 255);
		this.color_var = color_var;
		switch (tier)
        {
        case 1:
			color = new Color32(255, (byte)color_var, 0, 255);
			break;
		case 2:
			color = new Color32((byte)(255 - color_var), 255, 0, 255);
			break;
		case 3:
			color = new Color32(0, 255, (byte)color_var, 255);
			break;
		case 4:
			color = new Color32(0,(byte)(255 - color_var), 255, 255);
			break;
		case 5:
			color = new Color32((byte)color_var, 0, 255, 255);
			break;
		case 6:
			color = new Color32(255, 0, (byte)(255 - color_var), 255);
			break;
		}

		this.GetComponent<Renderer>().material.color = color;
	}

	public void OnTriggerEnter(Collider col)
    {        
		GenerateInfinite script = GameObject.FindWithTag("GameController").GetComponent<GenerateInfinite>();
		script.change_score();
        UI_script.add_enemy(this.GetComponent<Renderer>().material.color, this.tier, this.color_var);
        //Destroy(this.gameObject);
        GetComponent<ExplosionScript>().explodingRead = true;
    }

	

/* ENEMY TIERS
1    255    0   0
     255    254 0

2    255    255 0
     1      255 0

3    0   255 0
     0   255 254

4    0   255 255
     0   1   255

5    0   0   255
     254 0   255

6    255 0   255
     255 0   1
 */
 
}
