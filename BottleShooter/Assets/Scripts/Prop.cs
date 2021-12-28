using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IBreakable
{
	public void Break() {
		Destroy(this.gameObject);
	}
}
