using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));

    }
}
