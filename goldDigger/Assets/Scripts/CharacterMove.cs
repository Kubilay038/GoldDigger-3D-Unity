using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    SpriteRenderer spriteRenderer;
    int coinMeter = 0;
    Rigidbody physical;
    void Start()
    {
        physical = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            physical.AddForce(0, 190, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        x *= Time.deltaTime * speed;
        y *= Time.deltaTime * speed;

        transform.Translate(x, 0f, y);
    }
}
