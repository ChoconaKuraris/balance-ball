using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    Rigidbody _rigidbody;
    int dir = 1;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody =this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector3.right * speed * Time.fixedDeltaTime * dir;
    }

    private void OnCollisionEnter(Collision collision) //碰到除了player的物体就反向移动
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            dir = -dir;
        }
    }
    // Update is called once per frame
  
}
