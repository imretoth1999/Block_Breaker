using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	private Ball ball;
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
		MoveWithMouse();
		}else{
			AutoPlay();
		}
	}
	void AutoPlay(){
		Vector3 paddle = new Vector3 (0.5f,this.transform.position.y,this.transform.position.z);
		Vector3 ballp = ball.transform.position;
		paddle.x = Mathf.Clamp(ballp.x,0.3f,15.7f);
		this.transform.position = paddle;
	}
	void MoveWithMouse(){
		Vector3 paddle = new Vector3 (0.5f,this.transform.position.y,this.transform.position.z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddle.x = Mathf.Clamp(mousePosInBlocks,0.3f,15.7f);
		this.transform.position = paddle;
	}
}
