using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false); // �ε��� ��ü�� �Ѿ��̳� ���ʹ̸� �ε��� ��ü�� ��Ȱ��ȭ�Ѵ�.

            if (other.gameObject.name.Contains("Bullet")) //�ε��� ��ü�� �Ѿ��� ���
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>(); //playerfire Ŭ���� ������
                player.bulletObjectPool.Add(other.gameObject); // ����Ʈ�� �Ѿ� ����
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager"); // enemymanager Ŭ���� ������
                EnemyManager manager = emObject.GetComponent<EnemyManager>();

                manager.enemyObjectPool.Add(other.gameObject); //����Ʈ�� �Ѿ� ����
            }
        }
    }
}
