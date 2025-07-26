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
    public float duration = 1f;
    public float stopDistance = 4f;
    public void GetHitPoint(Vector3 point)
    {
        hitpoint = point;

        Debug.Log(hitpoint);
    }
    public void TurnOffDefaultMoving()
    {
        gameObject.GetComponent<CameraMovement>().enabled = false;
    }
    public IEnumerator MoveEaseIn()
    {
        float time = 0f;
        Vector3 startPos = transform.position;

        // 👉 방향 벡터 계산 (hitpoint 쪽을 향함)
        Vector3 dir = (hitpoint - startPos).normalized;

        // 👉 hitpoint에서 n만큼 뒤쪽으로 물러난 위치 설정
        Vector3 targetPos = hitpoint - dir * stopDistance;

        while (time < duration)
        {
            float t = time / duration;
            float easedT = t * t;

            transform.position = Vector3.Lerp(startPos, targetPos, easedT);

            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
}
