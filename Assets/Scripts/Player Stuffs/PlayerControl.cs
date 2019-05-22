using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Image = UnityEngine.Experimental.UIElements.Image;

public class PlayerControl : MonoBehaviour
{

    public float Speed;
    public float JumpHeight;
    
    public bool OnGround;
    public static bool Fade;
    public static bool Temp;

    private Rigidbody _rb;
    
    private int _count;

    // Sets variables
    void Start()
    {
        OnGround = false;
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        Fade = false;
    }

    // Allows movement with movement keys and jump.
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

    // Allows jump when colliding with ground
    private IEnumerable OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
        
        if (other.gameObject.CompareTag("Platform"))
        {
            OnGround = true;
            transform.parent = other.transform;
        }
        
        if (other.gameObject.CompareTag("Next Scene"))
        {
            Fade = true;
            yield return new WaitForSeconds((float) .5);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("S1L2");
        }
    }

    // Allows jump when staying on ground.
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
        
        if (other.gameObject.CompareTag("Platform"))
        {
            OnGround = true;
            transform.parent = other.transform;
        }
    }

    // Stops ability to jump when not touching ground.
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"));
        {
            OnGround = false;
        }
        
        if(other.gameObject.CompareTag("Platform"))
            OnGround = false;
            transform.parent = null;
    }

}