
using System.Runtime.CompilerServices;
using UnityEngine;

public class CarSpawn1 : MonoBehaviour
{
    private float countTime=2f;
    public GameObject carPrefab;
    public Transform[] spawnPoints;


    void Update()
    {

        if (countTime <= 0)
        {
            SpawnCar();
            countTime = 2f;
        }
        else
        {
            countTime -= Time.deltaTime; //����ʱ��ÿ���1
        }

    }

    private void SpawnCar()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject spawnedCar=Instantiate(carPrefab, spawnPoint.position,spawnPoint.rotation);//��ת������Quatenion.identity����Ϊ�Ҳ������spawnPoint������ת��
        Destroy(spawnedCar, 180);
    }



   





}
