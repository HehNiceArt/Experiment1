using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    public float gravity = 9.81f;
    public float totalTime = 3.41f;
    public float initialVelocity = 0f;
    public float depth = 0;
    public GameObject target;
    Rigidbody2D rb;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float d = OwnDepthCalc();
        Debug.Log(d);
        PositionCalc(d);
    }

    private void Update()
    {
        cam.transform.position = new Vector3(rb.position.x, rb.position.y, cam.transform.position.z);

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        if (rb.transform.position.y <= target.transform.position.y)
        {
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

    void PositionCalc(float d)
    {
        rb.position = new Vector2(target.transform.position.x, depth);
    }

    float OwnDepthCalc()
    {
        //d = vi * t + 0.5 * a * t * t
        float d = initialVelocity * totalTime + 0.5f * (-gravity) * (totalTime * totalTime);

        depth = d;
        return depth;
    }
}
