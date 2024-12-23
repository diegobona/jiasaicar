
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{

    public Rigidbody2D rb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            rb.MovePosition(rb.position + Vector2.right);  //transform.position����ά��rb.position�Ƕ�ά������ֻ��Ҫ��ά��transform.right��Ҳ����ά��
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            rb.MovePosition(rb.position + Vector2.left); 
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            rb.MovePosition(rb.position + Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            rb.MovePosition(rb.position + Vector2.down);
        }



    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "car")
        {
            Debug.Log("we lost");
            Score.currentScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
