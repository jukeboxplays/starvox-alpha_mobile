using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_enemy_count : MonoBehaviour {
	Transform enemy_image;
	public List<Transform> enemys = new List<Transform>();

	// Use this for initialization
	void Start () {
		enemy_image = this.transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void add_enemy(Color32 color, int tier, int color_var){
		Color32 new_color = new Color32(color.r, color.g, color.b, color.a);
		Transform new_enemy = Instantiate(enemy_image);
		new_enemy.GetComponent<UI_image_script>().tier = tier;
		new_enemy.GetComponent<UI_image_script>().color_var = color_var;
		new_enemy.transform.parent = this.transform;
		new_enemy.GetComponent<Image>().color = new_color;
		enemys.Add(new_enemy);
		update_view();
	}


	void update_view(){

		enemys.Sort(sort_by_color); //FAZER SELECT SORT
		float pos = 240f;
		foreach (var enemy in enemys){
			enemy.transform.position = new Vector3(pos, 30, 1);
			pos = pos + 2f;
		}
		
	}

	static int sort_by_color(Transform p1, Transform p2)
     {
		 UI_image_script enemy1 = p1.GetComponent<UI_image_script>();
		 UI_image_script enemy2 = p2.GetComponent<UI_image_script>();
		 enemy1.score = enemy1.tier * 1000 + enemy1.color_var;
		 enemy2.score = enemy2.tier * 1000 + enemy2.color_var;
         return enemy1.score.CompareTo(enemy2.score);
     }


/* 
	void update_list(){
		
		foreach (var enemy in enemys){
			//Sorting Method
		}

	}*/
}
