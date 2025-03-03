using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //collision是个参数，它的变量类型是Collider2D
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform); //設置父對象
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            collision.gameObject.transform.SetParent(null); //解除父對象
        }
    }
}
