﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //Public References
    public Transform playerTransform;

    //Public Parameter
    public float rotationSpeed;
    public float maxDistanceToPlayer;


	void Start () {
	
	}
	
	
	void Update () {
        Vector2 axisInput = GetAnalogInput();
        RotationHorizontal(axisInput.x);
        RotationVertical(axisInput.y);
        //TranslateToMaxDistance();
        LookAtPlayer();
	}


    private Vector2 GetAnalogInput()
    {
        float xInput = Input.GetAxisRaw("JoystickRightX");
        float yInput = Input.GetAxisRaw("JoystickRightY");
        return new Vector2(xInput, yInput);
    }

    private void RotationHorizontal(float horizontalInput)
    {
        this.transform.RotateAround(playerTransform.position, Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }

    private void RotationVertical(float verticalInput)
    {
        this.transform.RotateAround(playerTransform.position, Vector3.right, rotationSpeed * verticalInput * Time.deltaTime);
    }

    private void TranslateToMaxDistance()
    {
        float distanceDelta = maxDistanceToPlayer - Vector3.Distance(this.transform.position, playerTransform.position);
        Vector3 directionPlayerToCamera = (this.transform.position - playerTransform.position).normalized;
        if(distanceDelta < 0f)
        {
            this.transform.Translate(directionPlayerToCamera * distanceDelta);
        } else
        {
            this.transform.Translate(directionPlayerToCamera * distanceDelta);
        }
    }

    private void LookAtPlayer()
    {
        this.transform.LookAt(playerTransform.position);
    }




}
