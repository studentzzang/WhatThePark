/// <summary>
/// 플레이어 자동차의 충돌감지, 게임오버
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject GameOverDetecter;
    private GameOver gameOver;
    private CameraGameOver cam_GameOver;

    private void Awake()
    {
        gameOver = GameOverDetecter.GetComponent<GameOver>();    

        cam_GameOver = Camera.main.GetComponent<CameraGameOver>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) //game over = obstacle
        {
            GetComponent<Rigidbody>().isKinematic = true; //이러면 멈춤
            gameOver.PopUpUI();

            SetHitPoint(collision.GetContact(0));
        }
    }
    private void SetHitPoint(ContactPoint contact) //카메라 무빙 할 때 쓰일 벡터값 세팅
    {
        Vector3 hitpoint = contact.point;

        cam_GameOver.GetHitPoint(hitpoint);
    }
}
