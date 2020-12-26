using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Controller : MonoBehaviour
{
    public AudioClip[] musics;
    public One_CircleVisualizer[] circles;
    public Vector3[] oneColorsMin;
    public Vector3[] twoColorsMin;
    public Vector2 inputPosition;
    public float[] powersOne;
    public float[] powersTwo;
    public float[] yFactorsOne;
    public float[] yFactorsTwo;
    public float[] yFallOffOne;
    public float[] yFallOffTwo;
    public int actualMusic = 0;
    public int actualColor = 0;
    public int actualPattern = 0;

    AudioSource audioSource;
	bool touched;
    bool hasTouched;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        touched = false;
        hasTouched = false;

        if (musics.Length > 0) {
            actualMusic -= 1;
            actualColor -= 1;
            actualPattern -= 1;
            changeMusic();
            changeColors();
            changePattern();
        }
    }

    void Update() {
        //Touch Gestion
		touched = false;
		if (touch() && !hasTouched) {
			hasTouched = true;
			touched = true;
		}
		else if (!touch() && hasTouched) {
			hasTouched = false;
		}

        if (Input.GetKeyDown(KeyCode.M)
            || (touched && inputPosition.x < Screen.width/2)) {
            changeMusic();
        }
        if (Input.GetKeyDown(KeyCode.C)
            || (touched && inputPosition.x >= Screen.width/2 && inputPosition.y >= Screen.height/2)) {
            changeColors();
        }
        if (Input.GetKeyDown(KeyCode.P)
            || (touched && inputPosition.x >= Screen.width/2 && inputPosition.y < Screen.height/2)) {
            changePattern();
        }
    }

    private bool touch() {
		if (Input.GetMouseButton(0)) {
            inputPosition = Input.mousePosition;
			return true;
		}
		for (int i = 0; i < Input.touchCount; i++) {
            inputPosition = Input.GetTouch(0).position;
			return true;
		}
		return false;
	}

    private void changeMusic() {
        actualMusic += 1;
        if (actualMusic >= musics.Length) {
            actualMusic = 0;
        }
        audioSource.clip = musics[actualMusic];
        audioSource.Play();
    }

    private void changeColors() {
        actualColor += 1;
        if (actualColor >= oneColorsMin.Length) {
            actualColor = 0;
        }
        circles[0].colorMin = oneColorsMin[actualColor];
        circles[1].colorMin = twoColorsMin[actualColor];
    }

    private void changePattern() {
        actualPattern += 1;
        if (actualPattern >= powersOne.Length) {
            actualPattern = 0;
        }
        circles[0].power = powersOne[actualPattern];
        circles[0].yFactor = yFactorsOne[actualPattern];
        circles[0].yFallOff = yFallOffOne[actualPattern];
        circles[1].power = powersTwo[actualPattern];
        circles[1].yFactor = yFactorsTwo[actualPattern];
        circles[1].yFallOff = yFallOffTwo[actualPattern];
    }
}
