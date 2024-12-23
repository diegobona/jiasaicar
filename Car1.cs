
using UnityEditor.Rendering;
using UnityEngine;

public class Car1 : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed;
    private float minSpeed=0.2f;
    private float maxSpeed=0.3f;
    private float detectionDistance = 1f;
    private float frontOffset = 0.64f;

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

        // 计算车头位置
        Vector2 carFrontPosition = transform.position + transform.right * frontOffset;

        // 射线检测前方是否有car1或car2标签的对象
        RaycastHit2D hit = Physics2D.Raycast(carFrontPosition, transform.right, detectionDistance);

        if (hit.collider != null && (hit.collider.CompareTag("car1") || hit.collider.CompareTag("car2")) && hit.collider.gameObject != gameObject)
        {
            // 如果检测到前方有car1或car2标签的对象，则停止移动
            rb.velocity = Vector2.zero;
            Debug.Log($"Stopped because of obstacle: {hit.collider.gameObject.name}");

        }
        else
        {
            // 否则继续移动
            Vector2 carForward = new Vector2(transform.right.x, transform.right.y); // 车身朝向变量（向左、向右，或二维中任意朝向）
            rb.MovePosition(rb.position + carForward * Time.fixedDeltaTime * speed); // 让车沿车身朝向、以speed速度移动
            Debug.Log("Moving forward");
        }

    }



    // 绘制射线用于调试
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 carFrontPosition = transform.position + transform.right * frontOffset;
        Gizmos.DrawLine(carFrontPosition, carFrontPosition + (Vector2)transform.right * detectionDistance);
    }



}
