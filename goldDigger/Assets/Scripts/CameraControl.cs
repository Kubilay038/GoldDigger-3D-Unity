using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float softness;
    public float sensitivity;

    Vector2 transitionPos;
    Vector2 camPos;

    GameObject player;
    void Start()
    {
        player = transform.parent.gameObject;
    }
    void LateUpdate()
    {
        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mousePos = Vector2.Scale(mousePos, new Vector2(softness * sensitivity, sensitivity * softness));
        transitionPos.x = Mathf.Lerp(transitionPos.x, mousePos.x, 1f / softness);
        transitionPos.y = Mathf.Lerp(transitionPos.y, mousePos.y, 1f / softness);
        camPos += transitionPos;

        transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(camPos.x, player.transform.up);
    }
}
