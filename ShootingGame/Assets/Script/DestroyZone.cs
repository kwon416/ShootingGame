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
            other.gameObject.SetActive(false); // 부딪힌 물체가 총알이나 에너미면 부딪힌 물체를 비활성화한다.

            if (other.gameObject.name.Contains("Bullet")) //부딪힌 물체가 총알일 경우
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>(); //playerfire 클래스 얻어오기
                player.bulletObjectPool.Add(other.gameObject); // 리스트에 총알 삽입
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager"); // enemymanager 클래스 얻어오기
                EnemyManager manager = emObject.GetComponent<EnemyManager>();

                manager.enemyObjectPool.Add(other.gameObject); //리스트에 총알 삽입
            }
        }
    }
}
