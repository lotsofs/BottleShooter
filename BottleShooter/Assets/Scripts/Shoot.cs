using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public BulletTrail trailObject;
	AudioSource audio;

	private void Start() {
		audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			audio.Play();

			RaycastHit hit;
			Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000);
			if (hit.transform != null) {
				IBreakable breakable = hit.transform.GetComponent<IBreakable>();
				if (breakable != null) {
					breakable.Break();
				}
				GameObject trail = (GameObject)Instantiate(trailObject.gameObject, transform.position, transform.rotation);
				trail.GetComponent<BulletTrail>().SetTrail(this.transform.position - (new Vector3(0f, 0.1f, 0f)), hit.point);
			}
			else {
				GameObject trail = (GameObject)Instantiate(trailObject.gameObject, transform.position, transform.rotation);
				trail.GetComponent<BulletTrail>().SetTrail(this.transform.position - (new Vector3(0f, 0.1f, 0f)), transform.TransformDirection(Vector3.forward) * 100f);
			}
		}
	}
}
