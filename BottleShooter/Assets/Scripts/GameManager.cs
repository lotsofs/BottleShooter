using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Target[] targets;
	public TextMeshProUGUI timeText;
	public TextMeshProUGUI shotsText;
	public TextMeshProUGUI scoreText;
	public Shoot shoot;
	
	int _targetCount = 0;
	int _targetsShot = 0;
	int _shotCount = 0;
	DateTime _startTime = DateTime.UnixEpoch;
	bool _started = false;
	bool _finished = false;

	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		foreach (Target t in targets) {
			t.BreakEvent += TargetShot;
			_targetCount++;
		}
		shoot.ShotEvent += ShotFired;
	}

	void ShotFired() {
		if (_started) {
			_shotCount++;
		}
	}

	void TargetShot() {
		_targetsShot++;
		if (_targetsShot == 1) {
			// start the timer
			_startTime = DateTime.Now;
			_started = true;
			_shotCount = 1; // TODO: We're dealing with race conditions here, the shot isn't counted if it's the starting shot, but it might also be.
		}
	}

	// Update is called once per frame
	void Update() {
		TimeSpan gameTime = DateTime.Now - _startTime;
		double seconds = 0;

		if (_started) {
			seconds = gameTime.TotalSeconds;
		}

		double score = (seconds + _shotCount - _targetsShot) * 10;

		if (!_finished) {
			timeText.text = string.Format("Tiid: <color=#CDB477>{0:0.00}</color>", seconds);
			shotsText.text = string.Format("Rake Skotten: <color=#CDB477>{0}</color> fan'e <color=#CDB477>{1}</color>", _targetsShot, _shotCount);
			scoreText.text = string.Format("Totale Skore: <color=#CDB477>{0:0}</color>", score);
		}
		if (_targetsShot >= _targetCount) {
			_finished = true;
		}
	}
}
