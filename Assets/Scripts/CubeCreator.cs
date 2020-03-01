using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
	public GameObject cubeObject;

	public int cubesToCreateX = 10;
	public int cubesToCreateY = 10;
	public float posZ = 10f;

	void Start() {
		for (int i = 0 ; i < cubesToCreateX ; i++) {
			for (int j = 0 ; j < cubesToCreateY ; j++) {
				GameObject cube = Instantiate(cubeObject, new Vector3((i * 2) - cubesToCreateX, (j * 2) - cubesToCreateY,
					posZ),
					Quaternion.identity);

				cube.transform.parent = transform;
			}
		}
	}
}
