using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour, IBreakable
{

	public delegate void OnBroken();
	public event OnBroken BreakEvent;


	public void Start() {
		
	}

	public void Break() {
		BreakEvent?.Invoke();
		Destroy(this.gameObject);
	}
}
