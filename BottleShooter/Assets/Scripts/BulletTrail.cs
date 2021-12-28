using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
	public float fadeSpeed = 2f;
	public Color color;

	LineRenderer lineRenderer;

	// Start is called before the first frame update
	void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	public void SetTrail(Vector3 startPos, Vector3 endPos) {
		Debug.Log(lineRenderer);
		lineRenderer.SetPosition(0, startPos);
		lineRenderer.SetPosition(1, endPos);
	}

	// Update is called once per frame
	void Update()
	{
		color.a = Mathf.Lerp(color.a, 0, Time.deltaTime * fadeSpeed);
		lineRenderer.startColor = color;
		lineRenderer.endColor = color;
		if (color.a <= 0.01f) {
			Destroy(this.gameObject);
		}
	}
}
