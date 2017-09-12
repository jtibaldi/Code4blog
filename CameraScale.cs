using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraScale : MonoBehaviour {
	public int targetWidth = 960;
	public float pixelsToUnits = 1;

	// Update is called once per frame
	void Update () {
		int height = Mathf.RoundToInt (targetWidth / (float)Screen.width * Screen.height);
		Camera.main.orthographicSize = height / pixelsToUnits / 2;
	}
}