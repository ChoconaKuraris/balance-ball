using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float force = 5;

   
    public delegate void GameOver(bool temp);
    public event GameOver IsGameOver;//用于发出死亡的消息
    
    //控制刹车
    public float reduce = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * force);

        if(Input.GetKey(KeyCode.Space)) //按下按键持续生效
        {
            _rigidbody.velocity = new Vector3(Mathf.Lerp(_rigidbody.velocity.x, 0, reduce), _rigidbody.velocity.y, Mathf.Lerp(_rigidbody.velocity.z, 0, reduce));
        }

        if (transform.position.y < -3f) //掉落重新载入场景
        {
            if (IsGameOver != null)//检查事件是否为空，即有没有接收器订阅它
            {
                IsGameOver(true);//发送死亡事件消息

            }

            // SceneManager.LoadScene("SampleScene");
        }
    }
}
