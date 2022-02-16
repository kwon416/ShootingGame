using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int poolsize = 10;
    public List<GameObject> enemyObjectPool; //오브젝트 풀 리스트
    public Transform[] spawnPoints;

    float currentTime;
    float createTime;
    public GameObject enemyFactory;
    public float minTime = 0.5f;
    public float maxTime = 1.5f;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>(); // 오브젝트 풀 생성
        for (int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy); //에너미를 오브젝트 풀에 넣는다.
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; //시간이 흐른다. 1이 되면 1초
        //현재 시간이 일정 시간이 된다면
        if (currentTime > createTime)
        {
            GameObject enemy = enemyObjectPool[0]; //오브젝트 풀에 에너미가 있으면
            if (enemyObjectPool.Count > 0)
            {
                enemy.SetActive(true); //에너미 활성화
                enemyObjectPool.Remove(enemy); //오브젝트 풀에서 에너미 제거
                int index = Random.Range(0, spawnPoints.Length); //랜덤 인덱스 선택

                enemy.transform.position = spawnPoints[index].position; //위치시키기
            }
            
            createTime = Random.Range(minTime, maxTime); //현재시간 초기화
            
            currentTime = 0;
        }
    }
}
