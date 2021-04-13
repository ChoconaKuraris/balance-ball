using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBoard : MonoBehaviour
{
    Rigidbody _rigidbody;
    bool canup = false;

    public int dir = 1;

    public float speed = 1;

    public float max = 4; //最大上升高度
    float startY; //初始高度
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        startY = _rigidbody.position.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!canup) return;

        _rigidbody.position+= Vector3.up * speed * dir * Time.fixedDeltaTime;

        if(_rigidbody.position.y-startY>=max)
        {
            canup = false;
        }
    }

    public void MoveUp() //与开关通信
    {
        canup = true;
    }
}
