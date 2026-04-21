using UnityEngine;

public class JumpSpring : MonoBehaviour
{
    [Header("Jump Set")]
    public float jumpForce = 12f; 
    public Animator springAnim;  

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
       
            springAnim.SetBool("IsCompressed", true);
       
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 0);
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        if (other.CompareTag("Player1"))
        {

            springAnim.SetBool("IsCompressed", true);

            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 0);
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

  
    public void OnSpringAnimEnd()
    {
      
        springAnim.SetBool("IsCompressed", false);
    }
}