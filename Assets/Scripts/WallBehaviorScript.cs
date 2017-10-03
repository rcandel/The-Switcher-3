﻿using UnityEngine;
using System.Collections;

public class WallBehaviorScript : MonoBehaviour {
	public static bool isSwitched = false;
	private bool wasSwitched = false;
	public bool isReversed = false;

	void Start(){
		if (isReversed) {
			var sr = GetComponent<SpriteRenderer> ();
			sr.color = new Color (1, 1, 1, 0.5f);

			GetComponent<Collider2D> ().isTrigger = true;
		}
	}

	public void DoSwitchSstate()
	{
		isSwitched = !isSwitched;
		wasSwitched = !wasSwitched;

		var effect = GetComponent<AudioSource> ();
		effect.Play ();

		UpdateState ();
	}

	public void Update()
	{
		if (wasSwitched != isSwitched) {
			UpdateState ();
			wasSwitched = isSwitched;
		}		
	}

	private void UpdateState()
	{
		var switchOn = isReversed ? !isSwitched : isSwitched;

		if (switchOn)
			SwitchToState2 ();
		else
			SwitchToState1 ();
	}

	private void SwitchToState2()
	{
		var sr = GetComponent<SpriteRenderer> ();
		sr.color = new Color (1, 1, 1, 0.5f);

		GetComponent<Collider2D> ().isTrigger = true;
	}

	private void SwitchToState1()
	{
		var sr = GetComponent<SpriteRenderer> ();
		sr.color = Color.white;

		GetComponent<Collider2D> ().isTrigger = false;
	}
}
