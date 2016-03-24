using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public Text CurrentFrame, Speed, Cart;

	public Animator main_animator;

	public GameObject cart;

	public Transform cart1, cart2;

	public string playbackspeed;

	public string currentcar;

	public int switcher;


	public float playbacktime;

	public AnimatorClipInfo[] animationclip;

	public GameObject[] Cart1Seats;

	public GameObject[] Cart2Seats;

	private int currentseat;

	// Use this for initialization
	void Start () {
		main_animator = cart.GetComponent<Animator> ();
		playbackspeed = "x1";
	
	

		//animationclip = main_animator.GetCurrentAnimatorClipInfo (0);
	}
	
	// Update is called once per frame
	void Update () {

		currentcar = transform.parent.name;
		Cart.text = currentcar;
		Speed.text = playbackspeed;

		switch (switcher) {

		case 0: 
			playbackspeed = "x1"; 
			main_animator.speed = 1;

		break;
		case 1: 
			playbackspeed = "x2";
			main_animator.speed = 2;
			break;

		case 2:
			playbackspeed = "x3";
			main_animator.speed = 3;
			break;

		case 3:
			playbackspeed = "Paused";
			main_animator.speed = 0;

			break;
		}
	}

	public void PauseAnimation()
	{
		switcher = 3;
	}

	public void StartAnimation()
	{
		switcher = 0;

	}

	public void IncreaseSpeed()
	{
		if (switcher < 2) {

			switcher += 1;

		}
	}

	public void DecreaseSpeed()
	{
		if (switcher > 0) {
			switcher -= 1;
		}
	}

	public void ChangeSeat()
	{
		if (transform.parent == cart1) {
			if (currentseat >= Cart1Seats.Length - 1) {
				currentseat = 0;
				transform.position = Cart1Seats [currentseat].transform.position;
				return;
			}

			currentseat += 1;
			transform.position = Cart1Seats [currentseat].transform.position;
		}
		if (transform.parent == cart2) {
			if (currentseat >= Cart2Seats.Length - 1) {
				currentseat = 0;
				transform.position = Cart2Seats [currentseat].transform.position;
				return;
			}

			currentseat += 1;
			transform.position = Cart2Seats [currentseat].transform.position;
		}

	}
	public void ChangeCar()
	{


		if (transform.parent == cart1) {
			transform.parent = cart2;
			transform.position = Cart2Seats [0].transform.position;
			currentseat = 0;
		} else {
			transform.parent = cart1;
			transform.position = Cart1Seats [0].transform.position;
			currentseat = 0;
		}
	}
}
