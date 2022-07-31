using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrog : Enemy
{
    public Transform left;
    public Transform right;
    public float foot;
    public float cycle;

    private Rigidbody2D rigidbody;
    //private Animator animator;

    private Vector2 leftPoint;
    private Vector2 rightPoint;
    private float face;
    private float clock;
    protected override void Start()
    {
        base.Start();
        rigidbody = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();

        clock = cycle;
        face = -1;

        leftPoint = new Vector2(left.position.x, left.position.y);
        rightPoint = new Vector2(right.position.x, right.position.y);
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;
        if(clock <= 0)
        {
            clock = cycle;
            Jump();
        }
    }

    void Jump()
    {
        if(face == -1)
        {
            if (transform.position.x - foot < leftPoint.x)
            {
                face = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (transform.position.x + foot > rightPoint.x)
            {
                face = -1;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        rigidbody.velocity = new Vector2(face * foot, 2.5f);
        animator.SetTrigger("Jump");
    }
}
