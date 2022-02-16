using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletFactory;
    public GameObject firePosition;
    public int poolsize = 10;
    public List<GameObject> bulletObjectPool;
    
    void Start()
    {
        bulletObjectPool = new List<GameObject>(); //탄창을 만들어 준다.
        for (int i =0; i < poolsize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory); //총알 공장에서 총알 생성
            bulletObjectPool.Add(bullet); // 총알을 오브젝트 풀에 넣는다.
            bullet.SetActive(false); //총알 스크립트 비활성화

        }

#if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif

    }

    // Update is called once per frame
    void Update()
    {//유니티 데이터와 pc환경일때 동작
#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif  
    }
    public void Fire()
    {
        if (bulletObjectPool.Count > 0) //탄창 안에 총알이 있다면
        {
            GameObject bullet = bulletObjectPool[0]; //비활성화된 총알을 하나 가져온다.
            bullet.SetActive(true); //총알을 활성화 시킨다.
            bulletObjectPool.Remove(bullet);

            bullet.transform.position = transform.position;
        }
    }
}
