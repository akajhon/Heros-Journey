using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{

    private Animator playerAnimator;
    private Rigidbody2D playerRb;
    private SpriteRenderer spriteRenderer;
    public bool Grounded;
    public int idAnimation;
    public Transform groundCheck; //detectar se o personagem esta pisando no chao

    private float h, v;
    public float speed;
    public float jumpForce;
    public Collider2D standing, crounching; //colisor em pe e agachado

    //ARMAS
    public GameObject[] armas;

    public Camera minhaCamera;   
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        foreach(GameObject o in armas)
        {
            o.SetActive(false);

        }
    }

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
        playerRb.velocity = new Vector2(h * speed, playerRb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (v < 0)
        {
            if ( h >= 0)
            {
                idAnimation = 2;
                spriteRenderer.flipX = false;
                h = 0;

            }
            else
            {
                idAnimation = 2;
                spriteRenderer.flipX = true;
                h = 0;
            }
        }
        else if (h > 0)
        {
            idAnimation = 1;
            spriteRenderer.flipX = false;
        }
        else if (h < 0)
        {
            idAnimation = 1;
            spriteRenderer.flipX = true;
        }
        else
        {
            idAnimation = 0;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (spriteRenderer.flipX == true)
            {
                foreach (GameObject o in armas)
                {
                    o.GetComponent<SpriteRenderer>().flipX = true;
                }
                playerAnimator.SetTrigger("atack");
                idAnimation = 0;
            }
            else
            {
                foreach (GameObject o in armas)
                {
                    o.GetComponent<SpriteRenderer>().flipX = false;
                }
                playerAnimator.SetTrigger("atack");
                idAnimation = 0;
            }
        }


        if (Input.GetButtonDown("Jump") && Grounded)
        {
            playerRb.AddForce(new Vector2(0, 200));
        }

        if (v < 0 && Grounded)
        {
            crounching.enabled = true;
            standing.enabled = false;
        }
        else if (v >= 0 && Grounded)
        {
            crounching.enabled = false;
            standing.enabled = true;
        }

        playerAnimator.SetBool("grounded", Grounded);
        playerAnimator.SetInteger("idAnimation", idAnimation);
        playerAnimator.SetFloat("speedY", playerRb.velocity.y);
    }

    void controleArma(int id)
    {
        foreach (GameObject o in armas)
        {
            o.SetActive(false);
        }

        if (id >= 0 && id < armas.Length)
        {
            armas[id].SetActive(true);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Espinhos")
        {
            GameManager.instance.DecreaseLife(1);
        }

        if (col.gameObject.tag == "Portal")
        {
            String currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "Game") {
                SceneManager.LoadScene("Game2");
            } else if (currentScene == "Game2" && GameManager.instance.score <= 8) {
                SceneManager.LoadScene("Final1CutScene");
            } else if (currentScene == "Game2" && GameManager.instance.score > 8) {
                SceneManager.LoadScene("FinalAlternativoCutScene");
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
    }
}
