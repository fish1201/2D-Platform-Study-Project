using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private CapsuleCollider2D collider;
    private LayerMask groundMask;
    private BoxCollider2D bodyCollider;

    public Text collectionText;
    //public AudioSource collectionAudio;
    //public AudioSource dieAudio;
    public Transform cellingCheck;

    private int collectionNum;
    private bool canDoubleJump;
    private bool isHurt;

    public float speed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        groundMask = LayerMask.GetMask("Ground");
        canDoubleJump = true;
        collectionNum = 0;
        isHurt = false;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isHurt)
        {
            Move();
            Crouch();
        }
        SwitchAnim();
    }

    void Move()
    {
        // Ë®Æ½ÒÆ¶¯
        float horizontalMove = Input.GetAxis("Horizontal");
        float faceFlip = Input.GetAxisRaw("Horizontal");
        animator.SetBool("run", false);
        if (horizontalMove != 0)
        {
            rigidbody.velocity = new Vector2(horizontalMove * speed, rigidbody.velocity.y);
            animator.SetBool("run", true);
        }
        if(faceFlip != 0)
        {
            transform.localScale = new Vector3(faceFlip, 1, 1);
        }

        // ÌøÔ¾
        if(Input.GetButtonDown("Jump"))
        {
            if(collider.IsTouchingLayers(groundMask))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
                animator.SetBool("jump", true);
                canDoubleJump = true;
            }
            else if(canDoubleJump)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, doubleJumpSpeed);
                animator.SetBool("jump", true);
                canDoubleJump = false;
            }
            
        }
    }

    void SwitchAnim()
    {
        //animator.SetBool("idle", false);
        if(animator.GetBool("jump"))
        {
            if(rigidbody.velocity.y < 0)
            {
                animator.SetBool("jump", false);
                animator.SetBool("fall", true);
            }
        }
        else if(isHurt)
        {
            if(Mathf.Abs(rigidbody.velocity.x) < 0.1f)
            {
                isHurt = false;
                animator.SetBool("run", false);
                animator.SetBool("hurt", false);
            }
        }
        else if(collider.IsTouchingLayers(groundMask))
        {
            animator.SetBool("fall", false);
            //animator.SetBool("idle", true);
        }
        else if(rigidbody.velocity.y < 0 && animator.GetBool("fall") == false)
        {
            animator.SetBool("fall", true);
        }
    }

    void Crouch()
    {
        if(!Physics2D.OverlapCircle(cellingCheck.position, 0.2f, groundMask))
        {
            if (Input.GetButton("Crouch"))
            {
                animator.SetBool("crouch", true);
                bodyCollider.enabled = false;
            }
            else
            {
                animator.SetBool("crouch", false);
                bodyCollider.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collection"))
        {
            collision.tag = "Untagged";
            //collectionAudio.Play();
            SoundManager.instance.CollectionAudio();
            Destroy(collision.gameObject);
            collectionNum += 1;
            collectionText.text = collectionNum.ToString();
        }
        else if(collision.CompareTag("Deadline"))
        {
            //dieAudio.Play();
            SoundManager.instance.PlayerDieAudio();
            Invoke("Restart", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(animator.GetBool("fall"))
            {
                //Destroy(collision.gameObject);
                collision.gameObject.GetComponent<Enemy>().JumpOn();
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed/2);
                animator.SetBool("jump", true);
                canDoubleJump = false;
            }
            else
            {
                health -= 1;
                rigidbody.velocity = new Vector2(Mathf.Sign(transform.position.x - collision.gameObject.transform.position.x) * 3, rigidbody.velocity.y);
                isHurt = true;
                animator.SetBool("hurt",true);
            }
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
