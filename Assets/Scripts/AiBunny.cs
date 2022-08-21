using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBunny : MonoBehaviour
{
  [HideInInspector]
  public bool moving;
  private bool turn;

  [SerializeField] public LayerMask groundLine;
  [SerializeField] private Vector3[] positions; 
  [SerializeField] private Rigidbody2D patrolBunny;
  [SerializeField] private float movingSpeed;

  public BoxCollider2D groundColl;
  public SpriteRenderer sprite;
  public Animator bunnyAnimation;
  public Transform groundCheck;



    void Start()
    {
      Debug.Log("AiBunny movement started.");
      patrolBunny = GetComponent<Rigidbody2D>();
      groundColl = GetComponent<BoxCollider2D>();
      bunnyAnimation = GetComponent<Animator>();
      sprite = GetComponent<SpriteRenderer>();
      moving = true;

    }


    void Update()
    {
        if (moving)
        {
              Patrol();
        }
    }
   
    private void FixedUpdate()
    {
      if(moving)
      {
        turn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLine);
      }
    }


  
    void Patrol()
    {
      if (turn)
      {
        Flip();
      }
      patrolBunny.velocity = new Vector2(movingSpeed * Time.fixedDeltaTime, patrolBunny.velocity.y);
    }


    void Flip()
    {
      moving = false;
      transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
      movingSpeed *= -1;
      moving = true;
     }
}
