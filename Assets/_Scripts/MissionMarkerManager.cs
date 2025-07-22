/// <summary>
/// 미션마커 매니저의 자식으로 마커가 있어야하며 순서대로 있어야함
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMarkerManager : MonoBehaviour
{
    List<GameObject> m_Markers = new List<GameObject>();

    private void Awake()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            var element = transform.GetChild(i).gameObject;
            element.SetActive(false);
            m_Markers.Add(element);
        }
        
        EnableFirstElement(); //최초 처음꺼 on
    }

    public void Clear() //자식인 mission marker에서 호출
    {
        Destroy(m_Markers[0]);
        m_Markers.Remove(m_Markers[0]);

        EnableFirstElement();
    }

    private void EnableFirstElement()
    {
        m_Markers[0].gameObject.SetActive(true);
    }
}
