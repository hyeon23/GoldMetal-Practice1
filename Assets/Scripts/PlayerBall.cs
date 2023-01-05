using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//씬을 다루기 위한 필수 라이브러리

public class PlayerBall : MonoBehaviour
{
    public int score = 0;
    public float jumpPower = 30f;
    public bool isJump;
    Rigidbody rigid;
    AudioSource audio;
    public GameManagerLogic manager;//find 대신 사용

    // Start is called before the first frame update
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        
    }

    void FixedUpdate()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }

        //Left & Right Move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Capsule")
        {
            score++;
            audio.Play();//충돌시 Sound 구현
            //but Play를 하자마자 비활성화 시켜서 사운드가 출력되지 않는다.
            other.gameObject.SetActive(false);//gameObject는 자기 자신의 오브젝트를 가르키고, SetActive(false)는 비 활성화 상태
            manager.GetItem(score);
        }
        else if(other.tag == "Finish"){
            if(score == manager.totalScore)
            {
                //Game Clear
                if(manager.stage == 2)
                {
                    //==>새 레벨로 넘어가는 연출
                    SceneManager.LoadScene(0);
                }
                else
                {
                    //==>새 레벨로 넘어가는 연출
                    SceneManager.LoadScene(manager.stage + 1);
                }
            }
            else
            {
                //Restart
                //==> 해당 씬 재시작
                SceneManager.LoadScene(manager.stage);//LoadScene: 주어진 씬을 다시 불러와주는 함수
                //문자열에 숫자를 그냥 더하면 숫자가 문자열이 되는 것을 활용 or ToString 활용  
            }
        }
    }
}
