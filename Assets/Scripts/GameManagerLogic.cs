using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//UI를 사용하기 위한 필수 라이브러리

public class GameManagerLogic : MonoBehaviour
{
    public int totalScore;
    public int stage;
    public Text PlayerItemText;
    public Text StageItemText;

    private void Awake()
    {
        StageItemText.text = "/ " + totalScore;
    }

    public void GetItem(int score)
    {
        PlayerItemText.text = score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.name == "Player")
        {
            SceneManager.LoadScene(stage);
            //씬 이름을 넣어줘도 돼지만 씬의 순번을 써줘도 적용이 가능!! 이게 중요한 것
        }
    }
}
