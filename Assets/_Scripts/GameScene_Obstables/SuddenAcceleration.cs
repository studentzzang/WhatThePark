/// <summary>
///  SUA, 갑자기 급발진하여 앞으로 돌진하는 obj에 넣기
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenAccelration : MonoBehaviour
{
    private Vector3 _startPos;

    public bool isMoveXAxis = true; //z이동이면 끄기
    public float _interval = 2f;
    public float _speed = 7f;
    float _timer = 0;

    private void Start()
    {
        _startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Acceleration();
    }

    void Acceleration()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        _timer += Time.deltaTime;

        if(_timer > _interval)
        {
            _timer = 0;
            transform.position = _startPos;
        }
    }
}
