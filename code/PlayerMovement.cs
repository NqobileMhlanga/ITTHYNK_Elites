using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()

    {  
        horizontalInput = Input.GetAxis("Horizontal");

         //move player left or right
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);

        //make player jump
        if(Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

}