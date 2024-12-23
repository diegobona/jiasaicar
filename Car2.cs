
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


    //����������޹ص��ƶ�ʱ����÷ŵ�fixupdate�У�
    private void FixedUpdate()
    {
        Vector2 carForward = new Vector2(transform.right.x, transform.right.y);//������������������ң����ά�����⳯��
        rb.MovePosition(rb.position + carForward * Time.fixedDeltaTime*speed);//�ó��س�������speed�ٶ��ƶ�
    }




}
