using UnityEngine;
using UnityEngine.UI;


public class items : MonoBehaviour
{
    private int apples = 0;

    [SerializeField] private Text applesText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);
            apples++;
            applesText.text = "apples:" + apples;
        }
    }
   
}
