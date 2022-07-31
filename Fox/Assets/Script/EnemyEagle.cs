using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEagle : Enemy
{
    // Start is called before the first frame update
    public Transform top;
    public Transform bottom;
    public float speed;

    private Rigidbody2D rigidbody;

    private int face;
    private Vector2 topPoint;
    private Vector2 bottomPoint;
    protected override void Start()
    {
        base.Start();
        rigidbody = GetComponent<Rigidbody2D>();
        face = 1;

        topPoint = new Vector2(top.position.x, top.position.y);
        bottomPoint = new Vector2(bottom.position.x, bottom.position.y);
        Destroy(top.gameObject);
        Destroy(bottom.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    void Fly()
    {
        if (face == 1)
        {
            if (transform.position.y + speed > topPoint.y)
            {
                face = -1;
            }
        }
        else
        {
            if (transform.position.y - speed < bottomPoint.y)
            {
                face = 1;
            }
        }
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, speed * face);
    }
}
