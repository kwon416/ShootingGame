using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text currentScoreUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    public static ScoreManager Instance = null; //싱글턴 객체

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "현재 점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "최고 점수 : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore); //최고점수를 플레이어에 저장한다.
            }
        }
    }

    private void Awake() //싱글턴 객체에 값이 없으면 생성된 자기 자신을 할당, awake()는 start()전에 실행되는 초기화 역할
    {
        if(Instance == null)
        {
            Instance = this; //ScoreManager 객체 인스턴스 자기 자신을 할당
        }
    }

    
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
