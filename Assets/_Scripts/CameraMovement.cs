/// <summary>
/// 게임씬 메인캠에 부착
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float distance = 10f; // 플레이어에서 카메라까지 거리
    public float height = 10f; // 위쪽 높이

    

    void LateUpdate()
    {
        DefaultMoving();
    }
    public void DefaultMoving()
    {
        // 대각선 위 방향: X와 Z 축 방향을 같게 (예: 45도)
        Vector3 diagonalOffset = new Vector3(1, 0, -1).normalized * distance;
        diagonalOffset.y = height;

        // 카메라 위치는 플레이어 위치 + 대각선 위 오프셋
        transform.position = player.position + diagonalOffset;

        // 카메라는 플레이어를 바라보도록
        transform.LookAt(player.position);
    }

}
