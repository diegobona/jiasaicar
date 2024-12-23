
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
            countTime -= Time.deltaTime; //倒计时器每秒减1
        }

    }

    private void SpawnCar()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject spawnedCar=Instantiate(carPrefab, spawnPoint.position,spawnPoint.rotation);//旋转不能是Quatenion.identity，因为右侧的两个spawnPoint做了旋转。
        Destroy(spawnedCar, 30);
    }



   





}
