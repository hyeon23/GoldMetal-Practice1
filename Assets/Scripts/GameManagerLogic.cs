using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//UI�� ����ϱ� ���� �ʼ� ���̺귯��

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
            //�� �̸��� �־��൵ ������ ���� ������ ���൵ ������ ����!! �̰� �߿��� ��
        }
    }
}
