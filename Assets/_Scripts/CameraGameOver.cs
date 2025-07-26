/// <summary>
/// 게임씬 메인캠에 부착
/// 게임 오버 되었을 때 카메라 무빙 멈추고 회전
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGameOver : MonoBehaviour
{
    private Vector3 hitpoint = new Vector3(0, 0, 0);
    public void GetHitPoint(Vector3 point)
    {
        hitpoint = point;

        Debug.Log(hitpoint);
    }
    public void TurnOffDefaultMoving()
    {
        gameObject.GetComponent<CameraMovement>().enabled = false;
    }
    public void CameraMoving()
    {

    }
}
