//Set Move to 1 to start, and 0 to stop movement.
// Movement System 0.1


using UnityEngine;
using System.Collections;
public class MovementSystem : MonoBehaviour {


	//Enable another timer
	public GameObject OtherTimer;
	public bool EnableSecondTime;

	//Setup Sounds
	public AudioSource AudioObject;
	public bool UseAudio;

	//Setup Postition
	public float CurrentX;
	public float CurrentY;
	public float CurrentZ;

	//Setup Movement Speed
	public float MoveSpeed;

	//Setup Movement Timer
	public float MovementTime;
	public float CurrentMovementTime;
	public float MovementDifference;
	public float ValueTIme;

	//Setup Object to move
	public GameObject ObjectToMove;

	//Setup Directions to move
	public float MoveX;
	public float MoveY;
	public float MoveZ;
	public bool MoveXPositive;
	public bool MoveYPositive;
	public bool MoveZPositive;


	//Start or Stop the movement

	public int Move;

	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
		CurrentMovementTime = System.DateTime.Now.Millisecond;
		MovementDifference = CurrentMovementTime;
		//Setup start positions
		CurrentX = ObjectToMove.transform.position.x;
		CurrentY = ObjectToMove.transform.position.y;
		CurrentZ = ObjectToMove.transform.position.z;
		ObjectToMove.transform.position = new Vector3 (CurrentX, CurrentY, CurrentZ);
	}
	
	// Update is called once per frame
	void Update () 
	
	{
	
	 CurrentMovementTime = System.DateTime.Now.Millisecond;
		//Check if ready to move

		if (Move == 1) 
		{
			if (UseAudio == true) {AudioObject.enabled = true;}
			if (CurrentMovementTime == MovementDifference) {} else

			{
				MovementDifference = CurrentMovementTime;
				ValueTIme +=1;
				//Move in the set directions
				//X Direction
				if (MoveX ==1f) 
				{
					if (MoveXPositive == true)
					{CurrentX+= MoveSpeed; }
					else {CurrentX-= MoveSpeed;}
				}
				//Y Direction
				if (MoveY ==1f) 
				{
					if (MoveYPositive == true)
					{CurrentY+= MoveSpeed; }
					else{CurrentY-= MoveSpeed;}
				}
				//Z Direction

				if (MoveZ ==1f) 
				{
					if (MoveZPositive == true)
					{CurrentZ+= MoveSpeed; }
					else{CurrentZ-= MoveSpeed;}
				}

				//Move the object
				ObjectToMove.transform.position = new Vector3(CurrentX,CurrentY,CurrentZ);
				if (ValueTIme == MovementTime) { 
					Move=0; 
					if (UseAudio == true) {AudioObject.enabled = false;}
					ValueTIme = 0f;
					if (EnableSecondTime = true) {OtherTimer.GetComponent<MovementSystem>().Move = 1; }
				}
			}
		}
	}

//ButtonVariables

	public void ButtonStart()
        {Move = 1;}

	public void PositiveXButton()
	{MoveXPositive = true;}
	public void PositiveYButton()
	{MoveYPositive = true;}
	public void PositiveZButton()
	{MoveZPositive = true;}
	public void NegZButton()
	{MoveZPositive = false;}
	public void NegXButton()
	{MoveXPositive = false;}
	public void NegYButton()
	{MoveYPositive = false;}
}
