/// <summary>
/// 플레이어 자동차의 충돌감지, 게임오버
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public Transform g_gameOverManager;
    private GameOverManager gameOverManager;
    private void Awake()
    {
        gameOverManager = g_gameOverManager.GetComponent<GameOverManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) //game over = obstacle
        {
            GetComponent<Rigidbody>().isKinematic = true; //이러면 멈춤

            gameOverManager.GameOver(collision);
        }
    }
    
}
