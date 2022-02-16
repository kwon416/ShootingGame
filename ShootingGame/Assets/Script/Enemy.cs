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
            GameObject target = GameObject.Find("Player"); //타겟은 플레이어
            dir = target.transform.position - transform.position; // 플레이어 방향을 구함.
            dir.Normalize(); //dir의 크기를 1로 정규화
        }
        else
        {
            dir = Vector3.down; //아닌경우 그냥 아래로
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

        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1); // 잡을때마다 현재 점수 출력을 한줄로 변경, Instance를 static으로 선언해 주었기 때문에 접근이 가능하다.

        ScoreManager.Instance.Score++; // 에너미를 잡을때마다 현재점수 표시
        GameObject explosion = Instantiate(explosionFactory); // 폭발효과 생성
        explosion.transform.position = transform.position; // 폭발효과 발생

        if (other.gameObject.name.Contains("Bullet")) //  bullet이랑 충돌할 때
        {
            other.gameObject.SetActive(false); //부딪힌 물체를 비활성화

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>(); // playerfire 클래스 얻어오기
            player.bulletObjectPool.Add(other.gameObject); // 리스트에 총알 삽입 
        }
        else
        {
            Destroy(other.gameObject); //그렇지 않으면 제거
        }

        //Destroy(gameObject); 대신에 비활성화해 자원을 반납.
        gameObject.SetActive(false);

        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>(); // enemymanager 클래스 얻어오기

        manager.enemyObjectPool.Add(gameObject); //리스트에 총알 삽입
    }

}

