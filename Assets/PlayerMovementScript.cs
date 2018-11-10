using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float boostSpeed = 40f;
    float h_move = 0f;
    float boost = 0f;
    bool jump;
	// Use this for initialization
	void Start () {
        jump = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Horizontal") || Input.GetMouseButton(1))
        {
            boost = boostSpeed;
        }

        h_move = runSpeed+boost;
        boost = 0;

        if (Input.GetButtonDown("Jump") || Input.GetMouseButton(2))
        {
            jump = true;
        }
	}
    private void FixedUpdate()
    {
        controller.Move(h_move*Time.deltaTime, false, jump);
        jump = false;
    }
}
