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
        bulletObjectPool = new List<GameObject>(); //źâ�� ����� �ش�.
        for (int i =0; i < poolsize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory); //�Ѿ� ���忡�� �Ѿ� ����
            bulletObjectPool.Add(bullet); // �Ѿ��� ������Ʈ Ǯ�� �ִ´�.
            bullet.SetActive(false); //�Ѿ� ��ũ��Ʈ ��Ȱ��ȭ

        }

#if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif

    }

    // Update is called once per frame
    void Update()
    {//����Ƽ �����Ϳ� pcȯ���϶� ����
#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif  
    }
    public void Fire()
    {
        if (bulletObjectPool.Count > 0) //źâ �ȿ� �Ѿ��� �ִٸ�
        {
            GameObject bullet = bulletObjectPool[0]; //��Ȱ��ȭ�� �Ѿ��� �ϳ� �����´�.
            bullet.SetActive(true); //�Ѿ��� Ȱ��ȭ ��Ų��.
            bulletObjectPool.Remove(bullet);

            bullet.transform.position = transform.position;
        }
    }
}
