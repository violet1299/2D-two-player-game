using UnityEngine;
using UnityEngine.UI;


public class items2 : MonoBehaviour
{
    private int kiwis = 0;

    [SerializeField] private Text kiwisText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("kiwi"))
        {
            Destroy(collision.gameObject);
            kiwis++;
            kiwisText.text = "kiwi" + kiwis;
        }
    }

}
