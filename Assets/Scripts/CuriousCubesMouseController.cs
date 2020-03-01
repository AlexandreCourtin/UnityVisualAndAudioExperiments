using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuriousCubesMouseController : MonoBehaviour
{
	public float reactionTime = 5f;

	public Vector3 mousePosition;

	void Start() {
		mousePosition = resetPos();
	}

	void Update() {
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(mouseRay, out hit)) {
			mousePosition = Vector3.Lerp(mousePosition, hit.point, reactionTime * Time.deltaTime);
		}
	}

	Vector3 resetPos() {
		return new Vector3(0f, 0f, 0f);
	}
}
