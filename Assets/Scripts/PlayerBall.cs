using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//���� �ٷ�� ���� �ʼ� ���̺귯��

public class PlayerBall : MonoBehaviour
{
    public int score = 0;
    public float jumpPower = 30f;
    public bool isJump;
    Rigidbody rigid;
    AudioSource audio;
    public GameManagerLogic manager;//find ��� ���

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
            audio.Play();//�浹�� Sound ����
            //but Play�� ���ڸ��� ��Ȱ��ȭ ���Ѽ� ���尡 ��µ��� �ʴ´�.
            other.gameObject.SetActive(false);//gameObject�� �ڱ� �ڽ��� ������Ʈ�� ����Ű��, SetActive(false)�� �� Ȱ��ȭ ����
            manager.GetItem(score);
        }
        else if(other.tag == "Finish"){
            if(score == manager.totalScore)
            {
                //Game Clear
                if(manager.stage == 2)
                {
                    //==>�� ������ �Ѿ�� ����
                    SceneManager.LoadScene(0);
                }
                else
                {
                    //==>�� ������ �Ѿ�� ����
                    SceneManager.LoadScene(manager.stage + 1);
                }
            }
            else
            {
                //Restart
                //==> �ش� �� �����
                SceneManager.LoadScene(manager.stage);//LoadScene: �־��� ���� �ٽ� �ҷ����ִ� �Լ�
                //���ڿ��� ���ڸ� �׳� ���ϸ� ���ڰ� ���ڿ��� �Ǵ� ���� Ȱ�� or ToString Ȱ��  
            }
        }
    }
}
