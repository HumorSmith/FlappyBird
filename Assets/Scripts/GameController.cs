using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
	public static GameController instance;
	public bool isGameOver = false;
	public GameObject gameOverText;
	public float scrollSpeed = -1.5f; 
	private int score;
	public Text scoreText;
	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update()
	{
		//If the game is over and the player has pressed some input...
		if (isGameOver && Input.GetMouseButtonDown(0)) 
		{
			//...reload the current scene.
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void BirdDied(){
		
		gameOverText.SetActive (true);
		isGameOver = true;
		//Set the game to be over.

	}

	public void BirdScored(){
		if(isGameOver){
			return;
		}
		score++;
		scoreText.text = "Score:" + score.ToString();
	}

}
