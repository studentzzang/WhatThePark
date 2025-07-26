using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour
{

    private Transform m_Marker;

    private void Update()
    {
        LookAtMarker();
    }
    public void SetMarker(Transform obj)
    {
        m_Marker = obj;
    }
    private void LookAtMarker()
    {
        if (m_Marker != null)
        {
            Vector3 dir = m_Marker.position - transform.position;

            // 오브젝트 기준 Z축이 dir을 바라보게 하고, X축은 90도 유지
            Quaternion lookRotation = Quaternion.LookRotation(dir, Vector3.up);

            // Z축 방향은 그대로 두고, X축만 90도로 고정
            Vector3 euler = lookRotation.eulerAngles;
            euler.x = 90f;
            transform.rotation = Quaternion.Euler(euler);
        }
    }
}
