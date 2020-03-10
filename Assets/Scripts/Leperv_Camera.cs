using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leperv_Camera : MonoBehaviour
{
    void Update() {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity)) {
            GameObject.Find("Skull").transform.eulerAngles = new Vector3(hit.point.y * 1f - 30f, -hit.point.x * 1f, 0f);
        }
    }
}
