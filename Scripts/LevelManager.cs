using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		brick.brickCount = 0;
		Application.LoadLevel(name);
	}
	public void QuitGame(){
		Application.Quit();
	}
	public void LoadNextLevel(){
		brick.brickCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	public void BrickDestroyed(){
		if(brick.brickCount <= 0){
		LoadNextLevel();
		}
	}
}
