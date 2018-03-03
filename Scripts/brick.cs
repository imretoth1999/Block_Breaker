using UnityEngine;
using System.Collections;

public class brick : MonoBehaviour {
	
	public AudioClip crack;
	private int timesHit;
	public Sprite[] hitSprites;
	private LevelManager levelmanager;
	public static int brickCount = 0;
	private bool isBreakable;
	public GameObject Particle;
	
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable)
			brickCount++;
		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D(Collision2D c){
		AudioSource.PlayClipAtPoint(crack, transform.position,0.5f);
		if (isBreakable){
			handleHits();
		}
	}
	void handleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			brickCount--;
			levelmanager.BrickDestroyed();
			GameObject puff = Instantiate (Particle, gameObject.transform.position, Quaternion.identity) as GameObject;
			puff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
			}
		else
		{
			LoadSprites();
		}
	}
	void LoadSprites(){
		int s = timesHit - 1;
		if (hitSprites[s]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[s];
			}
	}
	void SimulateWin(){
		levelmanager.LoadNextLevel();
	}
}
