
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


    //����������޹ص��ƶ�ʱ����÷ŵ�fixupdate�У�
    private void FixedUpdate()
    {

        // ���㳵ͷλ��
        Vector2 carFrontPosition = transform.position + transform.right * frontOffset;

        // ���߼��ǰ���Ƿ���car1��car2��ǩ�Ķ���
        RaycastHit2D hit = Physics2D.Raycast(carFrontPosition, transform.right, detectionDistance);

        if (hit.collider != null && (hit.collider.CompareTag("car1") || hit.collider.CompareTag("car2")) && hit.collider.gameObject != gameObject)
        {
            // �����⵽ǰ����car1��car2��ǩ�Ķ�����ֹͣ�ƶ�
            rb.velocity = Vector2.zero;
            Debug.Log($"Stopped because of obstacle: {hit.collider.gameObject.name}");

        }
        else
        {
            // ��������ƶ�
            Vector2 carForward = new Vector2(transform.right.x, transform.right.y); // ������������������ң����ά�����⳯��
            rb.MovePosition(rb.position + carForward * Time.fixedDeltaTime * speed); // �ó��س�������speed�ٶ��ƶ�
            Debug.Log("Moving forward");
        }

    }



    // �����������ڵ���
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 carFrontPosition = transform.position + transform.right * frontOffset;
        Gizmos.DrawLine(carFrontPosition, carFrontPosition + (Vector2)transform.right * detectionDistance);
    }



}
