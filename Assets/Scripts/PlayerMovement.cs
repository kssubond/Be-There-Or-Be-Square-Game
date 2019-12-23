using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float tapForce = 10f;
    public float tiltSmooth = 5f;
    public Vector3 startPos;

    public AudioSource tapSound;
    public AudioSource dieSound;


    private bool isDead = false;

    private Rigidbody2D rb;
    private Quaternion downRotation;
    private Quaternion forwardRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
    }

    void Update()
    {
        if(isDead == false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                transform.rotation = forwardRotation;
                rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
                tapSound.Play();
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "DeadZone")
        {
            rb.simulated = false;
            isDead = true;
            GameControl.instance.BirdDied();
            dieSound.Play();
        }

        else
        {
            isDead = false;
        }
    }
}
