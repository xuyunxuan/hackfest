﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyInputVR.Core;

public class SelectCharacter : MonoBehaviour {
	public string NowSelect;
	bool touchPadPressed;
	public GameObject[] Character;
	public PhotonView CharacterManager;
    Vector3 myOrientation = Vector3.zero;
    
    void OnEnable()
	{
		#if !UNITY_EDITOR && UNITY_ANDROID
		EasyInputHelper.On_Motion += localMotion;
		#endif
		EasyInputHelper.On_ClickStart += localClickStart;
		EasyInputHelper.On_ClickEnd += localClickEnd;

	}

	void OnDestroy()
	{
		#if !UNITY_EDITOR && UNITY_ANDROID
		EasyInputHelper.On_Motion -= localMotion;
		#endif
		EasyInputHelper.On_Click -= localClickStart;
		EasyInputHelper.On_Click -= localClickEnd;
	}
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{       
		if (Input.GetKeyUp (KeyCode.S)) 
		{
            touchPadPressed = true;
		}
	}
	void OnCollisionStay(Collision collision)
	{ 
		if (touchPadPressed == true) 
		{
			if (collision.transform.name == "lee") 
			{
				Invoke ("SelectLee", 0.9f);
				GetComponent<Animator>().Play("BlackOut");
				GetComponent<BoxCollider> ().enabled = false;
			}
			if (collision.transform.name == "wong") 
			{
				Invoke ("SelectWong", 0.9f);
				GetComponent<Animator>().Play("BlackOut");
				GetComponent<BoxCollider> ().enabled = false;
			}
			if (collision.transform.name == "du") 
			{
				Invoke ("SelectDu", 0.9f);
				GetComponent<Animator>().Play("BlackOut");
				GetComponent<BoxCollider> ().enabled = false;
			}
		}
	}
	public void SelectLee()
	{
		CharacterManager.RPC ("selectLee", PhotonTargets.All, false);
		PhotonNetwork.Instantiate(this.Character[0].name, new Vector3(0f,0f,0f), Quaternion.identity, 0);
	}
	public void SelectWong()
	{
		CharacterManager.RPC ("selectWong", PhotonTargets.All, false);
		PhotonNetwork.Instantiate(this.Character[1].name, new Vector3(0f,0f,0f), Quaternion.identity, 0);
	}
	public void SelectDu()
	{
		CharacterManager.RPC ("selectDu", PhotonTargets.All, false);
		PhotonNetwork.Instantiate(this.Character[2].name, new Vector3(0f,0f,0f), Quaternion.identity, 0);
	}
	public void DestroySelf()
	{
        Destroy(gameObject.transform.parent.gameObject);
		Destroy (gameObject);
	}
    void localMotion(EasyInputVR.Core.Motion motion)
    {
        myOrientation = motion.currentOrientationEuler;
    }

    void localClickStart(ButtonClick button)
	{
		//if (button.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTouchClick)
		//{
		//    brakePressed = true;
		//}
		if (button.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTouchClick)
		{
            touchPadPressed = true;
		}
	}

	void localClickEnd(ButtonClick button)
	{
		//if (button.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTouchClick)
		//{
		//    brakePressed = false;
		//}
		if (button.button == EasyInputConstants.CONTROLLER_BUTTON.GearVRTouchClick)
		{
            touchPadPressed = false;
		}
	}
}
