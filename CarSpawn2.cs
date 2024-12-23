
using System.Runtime.CompilerServices;
using UnityEngine;

public class CarSpawn2 : MonoBehaviour
{
    private float countTime=4f;
    public GameObject carPrefab;
    public Transform[] spawnPoints;


    void Update()
    {

        if (countTime <= 0)
        {
            SpawnCar();
            countTime = 4f;
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
        Destroy(spawnedCar, 30);
    }



   





}
