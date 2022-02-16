using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;

    public GameObject explosionFactory;
    // Start is called before the first frame update
    void Start()
    {
        
        int randValue = UnityEngine.Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player"); //Ÿ���� �÷��̾�
            dir = target.transform.position - transform.position; // �÷��̾� ������ ����.
            dir.Normalize(); //dir�� ũ�⸦ 1�� ����ȭ
        }
        else
        {
            dir = Vector3.down; //�ƴѰ�� �׳� �Ʒ���
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;

        
    }
    void OnCollisionEnter(Collision other)
    {

        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1); // ���������� ���� ���� ����� ���ٷ� ����, Instance�� static���� ������ �־��� ������ ������ �����ϴ�.

        ScoreManager.Instance.Score++; // ���ʹ̸� ���������� �������� ǥ��
        GameObject explosion = Instantiate(explosionFactory); // ����ȿ�� ����
        explosion.transform.position = transform.position; // ����ȿ�� �߻�

        if (other.gameObject.name.Contains("Bullet")) //  bullet�̶� �浹�� ��
        {
            other.gameObject.SetActive(false); //�ε��� ��ü�� ��Ȱ��ȭ

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>(); // playerfire Ŭ���� ������
            player.bulletObjectPool.Add(other.gameObject); // ����Ʈ�� �Ѿ� ���� 
        }
        else
        {
            Destroy(other.gameObject); //�׷��� ������ ����
        }

        //Destroy(gameObject); ��ſ� ��Ȱ��ȭ�� �ڿ��� �ݳ�.
        gameObject.SetActive(false);

        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>(); // enemymanager Ŭ���� ������

        manager.enemyObjectPool.Add(gameObject); //����Ʈ�� �Ѿ� ����
    }

}

