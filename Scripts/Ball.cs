using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBall;
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBall = this.transform.position - paddle.transform.position;
	}
	
	void Update () {
		if (!hasStarted){
			this.transform.position = paddle.transform.position + paddleToBall;
			if (Input.GetMouseButtonDown(0)){
				print ("Mouse clicked");
				this.rigidbody2D.velocity = new Vector2(2f,10f);
				hasStarted = true;	
			}
		}
	}
	void OnCollisionEnter2D(Collision2D c){
		Vector2 tweak = new Vector2(Random.Range (0f,0.2f),Random.Range (0f,0.2f));
		if (hasStarted){
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
