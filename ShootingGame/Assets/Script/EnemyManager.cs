using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int poolsize = 10;
    public List<GameObject> enemyObjectPool; //������Ʈ Ǯ ����Ʈ
    public Transform[] spawnPoints;

    float currentTime;
    float createTime;
    public GameObject enemyFactory;
    public float minTime = 0.5f;
    public float maxTime = 1.5f;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>(); // ������Ʈ Ǯ ����
        for (int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy); //���ʹ̸� ������Ʈ Ǯ�� �ִ´�.
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; //�ð��� �帥��. 1�� �Ǹ� 1��
        //���� �ð��� ���� �ð��� �ȴٸ�
        if (currentTime > createTime)
        {
            GameObject enemy = enemyObjectPool[0]; //������Ʈ Ǯ�� ���ʹ̰� ������
            if (enemyObjectPool.Count > 0)
            {
                enemy.SetActive(true); //���ʹ� Ȱ��ȭ
                enemyObjectPool.Remove(enemy); //������Ʈ Ǯ���� ���ʹ� ����
                int index = Random.Range(0, spawnPoints.Length); //���� �ε��� ����

                enemy.transform.position = spawnPoints[index].position; //��ġ��Ű��
            }
            
            createTime = Random.Range(minTime, maxTime); //����ð� �ʱ�ȭ
            
            currentTime = 0;
        }
    }
}
