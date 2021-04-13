using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    Transform _transform;
    public float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;
    }

    // Update is called once per frame
    

    private void FixedUpdate()
    {
        _transform.Rotate(Vector3.up * speed * Time.fixedDeltaTime);
    }
}
