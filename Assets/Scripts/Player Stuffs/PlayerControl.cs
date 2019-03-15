using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Image = UnityEngine.Experimental.UIElements.Image;

public class PlayerControl : MonoBehaviour
{

    public float Speed;
    public float JumpHeight;
    
    public bool OnGround;

    private Rigidbody _rb;
    
    private int _count;

    void Start()
    {
        OnGround = false;
        _rb = GetComponent<Rigidbody>();
        _count = 0;
    }

    void FixedUpdate()
    {
        Speed = PowerUps.Speed;
        JumpHeight = PowerUps.JumpHeight;
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        _rb.AddForce(movement * Speed);
        {
            if (Input.GetButton("Jump") && (OnGround))
            {
                _rb.velocity = new Vector2(_rb.velocity.x / 1.2f , JumpHeight);
                OnGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }

        if (other.gameObject.CompareTag("Low"))
        {
           Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"));
        {
            OnGround = false;
        }
    }
}