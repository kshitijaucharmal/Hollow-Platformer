using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  [Range(1f, 10f)]public float moveSpeed = 5f;
  public float jumpForce = 700f;
  public Rigidbody2D rb;
  public Transform GroundCheck;
  public LayerMask canJumpOnLayer;

  private float movement;
  private bool isGrounded = true;

  private Quaternion flipped = Quaternion.Euler(new Vector3(0, 180, 0));
  private Quaternion notFlipped = Quaternion.Euler(new Vector3(0, 0, 0));

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    movement = Input.GetAxisRaw("Horizontal");

    if(movement < 0){
      movement = movement * moveSpeed * 100 * Time.deltaTime;
      transform.rotation = flipped;
    }
    else if(movement > 0){
      movement = movement * moveSpeed * 100 * Time.deltaTime;
      transform.rotation = notFlipped;
    }

    isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.05f, canJumpOnLayer);
    if(Input.GetButtonDown("Jump") && isGrounded){
      rb.velocity = new Vector2(rb.velocity.y, jumpForce);
    }
    if(Input.GetButtonUp("Jump") && rb.velocity.y > 0){
      rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
    }
  }

  void FixedUpdate(){
    rb.velocity = new Vector2(movement, rb.velocity.y);
  }
}
