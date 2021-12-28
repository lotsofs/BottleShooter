using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public BulletTrail trailObject;
	public GameObject gunBarrelExit;
	AudioSource soundFile;

	private void Start() {
		soundFile = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			soundFile.Play();

			RaycastHit hit;
			Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10000);
			if (hit.transform != null) {
				IBreakable breakable = hit.transform.GetComponent<IBreakable>();
				if (breakable != null) {
					breakable.Break();
				}
				GameObject trail = (GameObject)Instantiate(trailObject.gameObject, transform.position, transform.rotation);
				trail.GetComponent<BulletTrail>().SetTrail(gunBarrelExit.transform.position, hit.point);
			}
			else {
				GameObject trail = (GameObject)Instantiate(trailObject.gameObject, transform.position, transform.rotation);
				trail.GetComponent<BulletTrail>().SetTrail(gunBarrelExit.transform.position, transform.TransformDirection(Vector3.forward) * 100f);
			}
		}
	}
}
