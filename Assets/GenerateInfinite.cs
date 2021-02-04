using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class Tile{
	public GameObject theTile;
	public float creationTime;
	

	public Tile(GameObject t, float ct){
		theTile = t;
		creationTime = ct;
	}
}

public class GenerateInfinite : MonoBehaviour {


	public float distance_counter;
	Text distance_text;
	public static int score_counter;
	public GameObject plane;
	public GameObject player;
	public GameObject enemy;
	public GameObject life;
	public GameObject meteor;
	public GameObject pillar;
	Text life_text;

	public GameObject counter;
	public GameObject distance;

	public GameObject[] ui_elements;
	public GameObject score;

	Text score_text;
	int planeSize = 10;
	int halfTilesX = 10;
	int halfTilesZ = 10;
	FlyControl player_script;
	Vector3 startPos;
	IEnumerator coroutine;
	Hashtable tiles = new Hashtable();

	// Use this for initialization
	void Start () {
	player = GameObject.FindWithTag("Player");

	score_text = score.GetComponent<Text>();
	distance_text = distance.GetComponent<Text>();
	life_text = life.GetComponent<Text>();
	player_script = player.transform.GetChild(0).GetComponent<FlyControl>();

	coroutine = start_counter();
	StartCoroutine(coroutine);
	score.GetComponent<Text>().text = "0";

	 this.gameObject.transform.position = Vector3.zero;
	 startPos = Vector3.zero;

	 float updateTime = Time.realtimeSinceStartup;

	 for (int x = -halfTilesX; x < halfTilesX; x++){
		 for (int z = -halfTilesZ; z < halfTilesZ; z++){
			 Vector3 pos = new Vector3((x * planeSize+startPos.x),
			 							0,
										 (z*planeSize+startPos.z));
			 GameObject t = (GameObject) Instantiate(plane, pos, Quaternion.identity);

			 string tilename = "Tile_" + ((int)(pos.x)).ToString()+"_"+((int)(pos.z)).ToString();
			 t.name = tilename;
			 Tile tile = new Tile(t, updateTime);
			 tiles.Add(tilename, tile);
		 }
	 }	


	distance_counter = 0f;
	 
	 //Hard

	 InvokeRepeating("meteor_spawn", 3f, 0.3f);
	 InvokeRepeating("pillar_spawn", 0.1f, 1f);

    InvokeRepeating("pillar_spawn2", 0.1f, 1f);

	if (SceneManager.GetActiveScene().buildIndex == 1){
    InvokeRepeating("enemy_wave", 3f, 4f);
	}


	}
	
	private void change_dist(){
		distance_counter += 5f;
	}
	public IEnumerator start_counter(){
	
         counter.GetComponent<Text>().text = "3";
		 yield return new WaitForSeconds(1);
		 counter.GetComponent<Text>().text = "2";
		 yield return new WaitForSeconds(1);
		 counter.GetComponent<Text>().text = "1";
		 yield return new WaitForSeconds(1);
		 counter.GetComponent<Text>().text = "GO!";
		 yield return new WaitForSeconds(1);
		 counter.SetActive(false);

		

        foreach (GameObject element in ui_elements)
        {
           element.SetActive(true);
        }
		InvokeRepeating("change_dist", 0f, 0.5f);
	}
	// Update is called once per frame
	void Update () {

		distance_text.text = distance_counter.ToString();
		
		life_text.text = player_script.life.ToString();
		

		int xMove = (int)(player.transform.position.x - startPos.x);
		int zMove = (int)(player.transform.position.z - startPos.z);

		if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize){
			float updateTime = Time.realtimeSinceStartup;

			int playerX = (int)(Mathf.Floor(player.transform.position.x/planeSize)*planeSize);
			int playerZ = (int)(Mathf.Floor(player.transform.position.z/planeSize)*planeSize);

			for (int x = -halfTilesX; x < halfTilesX; x++){
				for (int z = -halfTilesZ; z < halfTilesZ; z++){
					Vector3 pos = new Vector3((x * planeSize+playerX),
			 							0,
										 (z*planeSize+playerZ));
				
				string tilename = "Tile_" + ((int)(pos.x)).ToString()+"_"+((int)(pos.z)).ToString();
			 	
				if(!tiles.ContainsKey(tilename)){
					GameObject t = (GameObject) Instantiate(plane, pos, Quaternion.identity);
					t.name = tilename;
			 		Tile tile = new Tile(t, updateTime);
					tiles.Add(tilename, tile);	
				}
				else{
					(tiles[tilename] as Tile).creationTime = updateTime;
				}
				

				}

			}			
		}


		
	}

	public void change_score(){
		score_counter = (int)(score_counter + distance_counter/50 + 10);
		score_text.text = score_counter.ToString();
	}

	void meteor_spawn(){
        Instantiate(meteor, new Vector3(Random.Range(-50,50),
									   Random.Range(7,14), 
									   player.transform.position.z + 200), 
						    Quaternion.identity);
    }

    void pillar_spawn()
    {
        //pillar.transform.GetChild(1).GetComponent<GameObject>()
        Instantiate(pillar, new Vector3(Random.Range(-80, -20),
                                        Random.Range(10, 15),
                                        player.transform.position.z + 200),
                            Quaternion.Euler(Random.Range(10, 45),
                                             Random.Range(10, 350),
                                             Random.Range(10, 45)));
    }

    void pillar_spawn2()
    {
        //pillar.transform.GetChild(1).GetComponent<GameObject>()
        Instantiate(pillar, new Vector3(Random.Range(20, 80),
                                        Random.Range(10, 15),
                                        player.transform.position.z + 200),
                            Quaternion.Euler(Random.Range(10, 45),
                                             Random.Range(10, 350),
                                             Random.Range(10, 45)));
    }

    void enemy_wave(){
		
		IEnumerator coroutine;

		coroutine = Wave(0.5f, Random.Range(4, 6), Random.Range(-9, -6), Random.Range(3,5));

        StartCoroutine(coroutine);
	}
    
	void enemy_spawn(float pos_x, float pos_y, float end_pos_x, int wave_tier, int move_type, int leave_type, 
                     float timing, int times, float distance, float player_distance){

        GameObject instance = Instantiate(enemy, new Vector3(pos_x,
									        pos_y, 
									        player.transform.position.z + 80), 
						                    Quaternion.identity) as GameObject;

		enemy_script script = instance.GetComponent<enemy_script>();
		script.set_end_pos_x(end_pos_x);
		script.set_tier(wave_tier);

		script.set_timing(timing);
		script.set_loop(times);
		script.set_dist(distance);
		script.set_playerdist(player_distance);
		script.set_type(move_type, leave_type);

		script.set_color(Random.Range(0,254));
	}

	 private IEnumerator Wave(float waitTime, int num_enemys, float initial_pos, float distance)
    {
		float pos_y = Random.Range(7f,14f);
		int wave_tier = Random.Range(1,7);
		int leave = Random.Range(0,1);
		int times = Random.Range(1,5);
		float player_distance = Random.Range(5f,20f);
		for(int i = 0; i < num_enemys; i++)
        {
			yield return new WaitForSeconds(waitTime);
        	enemy_spawn(80, pos_y, initial_pos + distance*i, wave_tier, i%2, leave, i*waitTime, times, distance, player_distance);

		}
	}

}
