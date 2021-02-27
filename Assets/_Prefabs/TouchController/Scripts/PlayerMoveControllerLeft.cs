﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveControllerLeft : MonoBehaviour {

	// PUBLIC
	public SimpleTouchControllerLeft leftController;
	public SimpleTouchControllerLeft rightController;
	public Transform headTrans;
	public float speedMovements = 5f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 3000f;

	public float hM;
	public float vM;

	// PRIVATE
	private Rigidbody _rigidbody;
    private bool continuousRightController = true;

    void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		rightController.TouchEvent += RightController_TouchEvent;
	}

	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchEvent (Vector2 value)
	{
		if(!continuousRightController)
		{
			UpdateAim(value);
		}
	}

	void Update()
	{
		
		hM = Input.GetAxis("Horizontal");
		vM = Input.GetAxis("Vertical");
		

		if (continuousRightController)
		{
			UpdateAim(rightController.GetTouchPosition);
		}
	}

	private void FixedUpdate()
	{
		_rigidbody.MovePosition(transform.position + (transform.forward * vM * Time.deltaTime * speedMovements) +
		(transform.right * hM * Time.deltaTime * speedMovements) );
	}
	void UpdateAim(Vector2 value)
	{
		if(headTrans != null)
		{
			Quaternion rot = Quaternion.Euler(0f,
				transform.localEulerAngles.y - value.x * Time.deltaTime * -speedProgressiveLook,
				0f);

			_rigidbody.MoveRotation(rot);

			rot = Quaternion.Euler(headTrans.localEulerAngles.x - value.y * Time.deltaTime * speedProgressiveLook,
				0f,
				0f);
			headTrans.localRotation = rot;

		}
		else
		{

			Quaternion rot = Quaternion.Euler(transform.localEulerAngles.x - value.y * Time.deltaTime * speedProgressiveLook,
				transform.localEulerAngles.y + value.x * Time.deltaTime * speedProgressiveLook,
				0f);

			_rigidbody.MoveRotation(rot);
		}
	}

	void OnDestroy()
	{
		rightController.TouchEvent -= RightController_TouchEvent;
	}

}
