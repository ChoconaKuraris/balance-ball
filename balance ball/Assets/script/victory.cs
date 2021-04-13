using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    public delegate void win(bool temp);//定义委托
    public event win _win;//定义得分事件，用于发出得分的消息
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_win != null)//检查事件是否为空，即有没有接收器订阅它
            {
                _win(true);//发送胜利事件消息

            }
        }
    }
}
