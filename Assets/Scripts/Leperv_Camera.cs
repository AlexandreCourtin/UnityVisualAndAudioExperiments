using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leperv_Camera : MonoBehaviour
{
    void Update() {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity)) {
            transform.eulerAngles = new Vector3(-hit.point.y * .5f, hit.point.x * .5f, 0f);
            // mousePosition = Vector3.Lerp(mousePosition, hit.point, reactionTime * Time.deltaTime);
        }
    }
}
