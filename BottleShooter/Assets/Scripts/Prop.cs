using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IBreakable
{
	public void Break() {
		this.transform.localScale *= 0.9f;
	}
}
