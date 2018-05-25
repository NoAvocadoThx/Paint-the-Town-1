﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum state {N, R, G, B, RG, RB, GB, RGB, D};

public class Colorable : MonoBehaviour {


	private Animator animator;
	private Texture texture;
	private ParticleSystem particle;

	public state curState;
	Material mat;
	float t = 0.01f;

	// Use this for initialization
	void Start () {
		curState = state.N;
		animator = GetComponent<Animator> ();
		if (animator != null) {
			animator.SetBool("Play", false);
			Debug.Log("disabled");
		}
		mat = GetComponent<Renderer> ().material;
	}

	
	// Update is called once per frame
	void Update () {
		if (curState != state.D) {
			if (curState == state.RGB) {
				GetComponent<Renderer> ().material.SetFloat ("_Transition", Mathf.Lerp (0.01f, 1.0f, t));
				t += 0.5f * Time.deltaTime;
			}
			if (mat != null) {
				if(mat.GetFloat ("_Transition") >= 1.0f)
					curState = state.D;
			}
		}
/*		if(animator != null)
			Debug.Log(animator.GetBool ("Play"));
		if (Input.GetMouseButton (0)) {
			curState = state.RGB;
			Debug.Log ("something");
		}
		if (curState == state.RGB) {
			if (animator != null) {
				animator.SetBool ("Play", true);
			}
			Debug.Log ("works");
		}*/
    }

	public void ChangeState(string states){
		if (curState == state.D) {
		}
		else if (states == "Red") {
			if (curState == state.N)
				curState = state.R;
			else if (curState == state.G)
				curState = state.RG;
			else if (curState == state.B)
				curState = state.RB;
			else if (curState == state.GB)
				curState = state.RGB;
		} else if (states == "Blue") {
			if (curState == state.N)
				curState = state.B;
			else if (curState == state.G)
				curState = state.GB;
			else if (curState == state.R)
				curState = state.RB;
			else if (curState == state.RG)
				curState = state.RGB;
		} else if (states == "Green") {
			if (curState == state.N)
				curState = state.G;
			else if (curState == state.R)
				curState = state.RG;
			else if (curState == state.B)
				curState = state.GB;
			else if (curState == state.RB)
				curState = state.RGB;
		}
	}
}
