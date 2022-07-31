using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform camera;
    public float moveRate;
    private float startPoint;
    private float cameraPoint;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position.x;
        cameraPoint = camera.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(startPoint + moveRate * (camera.position.x - cameraPoint), transform.position.y);
    }
}
