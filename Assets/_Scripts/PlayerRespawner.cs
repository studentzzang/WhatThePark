/// <summary>
/// 미션 마커 도달 시 주로 호출 플레이어에 부착
/// </summary>
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    public static PlayerRespawner Instance = null;
    private Vector3 respawnPos;
    private float _rotY = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);  
    }

    public void SetTransform(Vector3 pos, float rotY) //미션마커 도달 시 호출
    {
        respawnPos = pos;
        _rotY = rotY;

    }
    public void Respawn()
    {
        transform.position = respawnPos;
        transform.rotation = new Quaternion(0, _rotY, 0, 0); //
    }
}
