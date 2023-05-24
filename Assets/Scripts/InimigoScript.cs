using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class InimigoScript : MonoBehaviour
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

    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
        Input.GetButtonDown("Fire1");
        playerAnimator.SetTrigger("atack");
        idAnimation = 0;
        playerAnimator.SetBool("grounded", true);
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
    }

    void OnCollisionExit2D(Collision2D col)
    {
    }

}
