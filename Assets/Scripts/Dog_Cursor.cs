using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Cursor : MonoBehaviour
{
    public float reactionTime = 20f;
    public LayerMask lay;
    public Vector3 mousePosition;

    void Start() {
        mousePosition = Vector3.zero;
    }

    void Update() {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity, lay)) {
            mousePosition = Vector3.Lerp(mousePosition, hit.point, reactionTime * Time.deltaTime);
        }
    }
}
