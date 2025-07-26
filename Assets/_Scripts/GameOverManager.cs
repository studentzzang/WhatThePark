/// <summary>
/// 게임 오버 관련 함수호출 중간자
/// 게임오버 이후 처리
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    private CameraGameOver cam_GameOver;

    void Awake()
    {

        cam_GameOver = Camera.main.GetComponent<CameraGameOver>();
    }
    
    private void SetHitPoint(ContactPoint contact) //카메라 무빙 할 때 쓰일 벡터값 세팅
    {
        Vector3 hitpoint = contact.point;

        cam_GameOver.GetHitPoint(hitpoint);

    }

    public void GameOver(Collision collision)
    {
       

        SetHitPoint(collision.GetContact(0));
        StartCoroutine(cam_GameOver.MoveEaseIn());
        cam_GameOver.TurnOffDefaultMoving();
    }
    IEnumerator WaitForSec()
    {
        yield return null;

        //이후 리스폰
    }
}
