
using UnityEditor.Rendering;
using UnityEngine;

public class Car2 : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed;
    private float minSpeed=0.5f;
    private float maxSpeed=1f;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        
    }


    //处理和输入无关的移动时，最好放到fixupdate中：
    private void FixedUpdate()
    {
        Vector2 carForward = new Vector2(transform.right.x, transform.right.y);//车身朝向变量（向左、向右，或二维中任意朝向）
        rb.MovePosition(rb.position + carForward * Time.fixedDeltaTime*speed);//让车沿车身朝向、以speed速度移动
    }




}
