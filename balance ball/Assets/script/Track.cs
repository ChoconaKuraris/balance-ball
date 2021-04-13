using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode] //游戏开始前就运行脚本
public class Track : MonoBehaviour
{
    public Transform player;
    public Vector3 dis; //相机到小球的距离
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _transform.position = player.position + dis;
        
    }
}
