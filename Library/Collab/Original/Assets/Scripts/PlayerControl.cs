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
    
    public Text CountText;
    
    public bool OnGround;

    private Rigidbody _rb;
    
    private int _count;
    public int Health;
    public int NumOfHearts;

    public UnityEngine.UI.Image[] Hearts;
 
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    

    public PlayerControl(object vector3)
    {

    }

    void Start()
    {
        OnGround = true;
        _rb = GetComponent<Rigidbody>();
        _count = 0;
    }

    void FixedUpdate()
    {
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
        
        if (Health > NumOfHearts)
        {
            Health = NumOfHearts;
        }
        
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
            
            if (i < NumOfHearts)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpPower"))
        {
            other.gameObject.SetActive(false);
            JumpHeight = 34;
            yield return new WaitForSeconds(10);
            JumpHeight = 17; 
        }

        if (other.gameObject.CompareTag("SanicBoi"))
        {
            other.gameObject.SetActive(false);
            Speed = 75;
            yield return new WaitForSeconds(10);
            Speed = 50;
        }

        if (other.gameObject.CompareTag("MarioStar"))
        {
            
        }

        if (other.gameObject.CompareTag("Cocaine"))
        {
            other.gameObject.SetActive(false);
            Speed = 125;
            JumpHeight = 25;
            yield return new WaitForSeconds(10);
            Speed = 50;
            JumpHeight = 17;
            
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
            SceneManager.LoadScene(scene.name);        }
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