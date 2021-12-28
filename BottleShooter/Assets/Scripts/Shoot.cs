using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000);
		    if (hit.transform != null) {
                IBreakable breakable = hit.transform.GetComponent<IBreakable>();
                if (breakable != null) {
                    breakable.Break();
				}
			}
        }
    }
}
