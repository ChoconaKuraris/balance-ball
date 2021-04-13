using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public Transform _transform;
    Transform player;

    public Transform gun; //炮管的位置

    public float speed = 20;

    public Transform shoot; //发射点的位置
    public float force = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null)
        {
            return;
        }
        //控制旋转
        Quaternion a = _transform.rotation;
        Quaternion c = Quaternion.Euler(Vector3.up); //c是世界正上方向，判断夹角是否超过90度
        if (changeAngle(Quaternion.Angle(a,c)) >= 90 && Input.GetAxis("Vertical") >= 0)
            return;
        if (changeAngle(a.eulerAngles.x) <= 0 && Input.GetAxis("Vertical") <= 0)
            return;

        Quaternion b = Quaternion.Euler(Vector3.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
        _transform.rotation=a*b;

        //发射
        if(Input.GetKeyDown(KeyCode.G))
        {
            player.position = shoot.position;

            player.gameObject.SetActive(true);

            player.GetComponent<Rigidbody>().AddForce(force * _transform.up, ForceMode.Impulse);
        }
    }

    float changeAngle(float angle)
    {
        if (angle > 180)
            return angle - 360;
        return angle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.transform;
            player.gameObject.SetActive(false);

            player.position = gun.position;
        }
    }
}
