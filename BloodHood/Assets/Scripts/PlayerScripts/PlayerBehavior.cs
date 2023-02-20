using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public enum playerState
    {
        idle, running, swiningKnife, shooting, ko
    }

    public enum playerDirection
    {
        left, right
    }

    static public playerState state = playerState.idle;
    Rigidbody2D rb;
   static  public int life;
    private int maxLife = 5;
    public float speed = 10f;
    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float jumpPower = 12f;
    public static playerDirection direction;
    public float maxJumpingHeight =17f;
    static public float jumpingHeight = 0f;
    public Animator playerAnim = null;
    private Vector2 positionStartedJumping; 
    static public bool onGround;
    static public bool jumping;
    public static bool swiningKnife = false;
    public static bool turned;
    public AudioClip slashSE;
    public AudioClip jumpSE;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        direction = playerDirection.right;
        onGround = true;
        turned = false;
        positionStartedJumping = new Vector2(0f, 0f);
        jumpingHeight = 0.0f;
        jumping = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (MissionClear.missionClear == false && PauseSystem.paused == false)
        {
            jumping = true;
            xSpeed = Input.GetAxis("Horizontal") * speed;
            // ySpeed = Input.GetAxis("Vertical") * jumpPower;
            if (xSpeed > 0)
            {
                if (onGround == true)
                {
                    playerAnim.Play("bloodhood_walk");
                }
                direction = playerDirection.right;
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log(direction);
            }
            else if (0 > xSpeed)
            {
                if (onGround == true)
                {
                    playerAnim.Play("bloodhood_walk");
                }
                direction = playerDirection.left;
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                Debug.Log(direction);
            }
            else
            {
                if (onGround == true)
                {
                    playerAnim.Play("bloodhood_idle");
                }
            }

            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey("joystick button 0")) && jumpingHeight <= maxJumpingHeight && jumping == false && onGround == true)
            {
                audioSource.PlayOneShot(jumpSE);
                playerAnim.Play("bloodhood_jump");
                jumping = true;
                ySpeed = jumpPower;
                rb.AddForce(new Vector2(0, ySpeed));
            }
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey("joystick button 0")) && jumpingHeight <= maxJumpingHeight && jumping == true)
            {
                playerAnim.Play("bloodhood_jump");
                ySpeed = jumpPower;
                jumpingHeight += 1f;
                rb.AddForce(new Vector2(0, ySpeed));
            }
            else if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp("joystick button 0")) || jumpingHeight > maxJumpingHeight)
            {
                playerAnim.Play("bloodhood_jump");
                jumping = false;
                ySpeed = 0f;
            }
            Debug.Log(jumping);
            rb.AddForce(new Vector2(xSpeed, 0));

            if ((Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown("joystick button 2")) && Knife.slashing == false)
            {
                audioSource.PlayOneShot(slashSE);
                swiningKnife = true;
            }
            else { state = playerState.idle; }

            if (Invincible_Hit.invincibled_Hit == true)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (Invincible_Hit.invincibled_Hit == false)
            {
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }


            if (life <= 0)
            {
                SceneManager.LoadScene("Scenes/MissionFailed");
            }
        }

        if(PauseSystem.paused == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if(PauseSystem.paused == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;

rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
