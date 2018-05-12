using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaScript : MonoBehaviour {

	private GameObject gameControllerGameObject; //Reference to the Game Controller GameObject;
	private string gameControllerTag = "GameController"; //Game Controller's tag;
	private Animator anima;
	private float life = 5.0f;
	private int scoreOnDeath = 125;
	public string bulletTag = "Bullet";
	private PhysicsScript physs;
	public string[] playerTags;
	public GameObject player;
	public bool followPlayer = true;
	public float followSpeedMultiplier = 0.009f;
	public float followSpeed = 5.0f;

	GameObject FindOneRandomPlayer()
	{
		PlayerScript[] players = GameObject.FindObjectsOfType<PlayerScript> ();
		try
		{
			int pos = Random.Range (0, players.Length);
			return players[pos].gameObject;
		}
		catch 
		{
			this.enabled = false; 
			return null;
		}
	}

	void Awake()
	{	
		gameControllerGameObject = GameObject.FindGameObjectWithTag (gameControllerTag);
		anima = GetComponent<Animator> ();
		physs = this.gameObject.GetComponent<PhysicsScript> ();	
		player = FindOneRandomPlayer ();
	}
	// Use this for initialization
	void Start ()
	{
		

	}
	void FixedUpdate()
	{
		if (followPlayer == true)
		{
			if (player != null) 
			{
				transform.rotation = physs.LookAt2D (this.gameObject, player);
				transform.Translate (Vector2.right * followSpeed * followSpeedMultiplier);
			}
			else 
			{
				player = FindOneRandomPlayer ();
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (gameControllerGameObject.GetComponent<GameControllerScript> ().GameOver == true)
		{
			anima.Play ("anim_bacteria_idle");
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == bulletTag)
		{
			this.life -= 1.0f;
			Destroy (other.gameObject);
			if (this.life <= 0.0f) 
			{
				Destroy (this.gameObject);
				gameControllerGameObject.GetComponent<GameControllerScript> ().Score += scoreOnDeath;
			}
		}
	}
}
