using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Leperv_Changes : MonoBehaviour
{
    public int actualColor = 0;
    public Color[] eyeAlbedo;
    [ColorUsageAttribute(true,true)]
    public Color[] eyeEmission;
    public Color[] skullLight;
    public Color[] backLight;
    [ColorUsageAttribute(true,true)]
    public Color[] particleColor;
    public Color[] backgroundColor;

    void Start() {
        changeColors();
        StartCoroutine(changeColorsRoutine());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            actualColor += 1;
            if (actualColor >= eyeAlbedo.Length) actualColor = 0;
            changeColors();
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            actualColor -= 1;
            if (actualColor < 0) actualColor = eyeAlbedo.Length - 1;
            changeColors();
        }
    }

    private void changeColors() {
        GameObject.Find("Left").GetComponent<MeshRenderer>().material.SetColor("_Albedo", eyeAlbedo[actualColor]);
        GameObject.Find("Left").GetComponent<MeshRenderer>().material.SetColor("_Emission", eyeEmission[actualColor]);
        GameObject.Find("Right").GetComponent<MeshRenderer>().material.SetColor("_Albedo", eyeAlbedo[actualColor]);
        GameObject.Find("Right").GetComponent<MeshRenderer>().material.SetColor("_Emission", eyeEmission[actualColor]);

        GameObject.Find("SkullLight").GetComponent<Light>().color = skullLight[actualColor];
        GameObject.Find("BackLight").GetComponent<Light>().color = backLight[actualColor];

        GameObject.Find("leperv_ambiance").GetComponent<VisualEffect>().SetVector4("Color", particleColor[actualColor]);
        GameObject.Find("leperv_ambiance2").GetComponent<VisualEffect>().SetVector4("Color", particleColor[actualColor]);

        Camera.main.backgroundColor = backgroundColor[actualColor];
    }

    IEnumerator changeColorsRoutine() {
        while (true) {
            yield return new WaitForSeconds(1f);
            changeColors();
        }
    }
}
