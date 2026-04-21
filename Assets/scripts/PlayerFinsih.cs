using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFinish : MonoBehaviour
{
    private bool isPlayerArrived = false;
    private bool isPlayer1Arrived = false;
    public float waitTime = 2f; 
    private float timer = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.CompareTag("Player")) isPlayerArrived = true;
        if (other.CompareTag("Player1")) isPlayer1Arrived = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("Player")) isPlayerArrived = false;
        if (other.CompareTag("Player1")) isPlayer1Arrived = false;
        timer = 0;
    }

    private void Update()
    {
     
        if (isPlayerArrived && isPlayer1Arrived)
        {
            timer += Time.deltaTime;
         
            if (timer >= waitTime)
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                isPlayerArrived = false;
                isPlayer1Arrived = false;
                timer = 0;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }

    void OnDrawGizmos()
    {
       
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }
}