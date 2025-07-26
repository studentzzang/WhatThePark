/// <summary>
/// 미션마커 매니저의 자식으로 마커가 있어야하며 순서대로 있어야함
/// 해당스크립트에서 웬만한 다른 스크립트 함수 호출 
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMarkerManager : MonoBehaviour
{
    List<GameObject> m_Markers = new List<GameObject>();

    public Transform dir_Arrow;
    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        for(int i=0; i<transform.childCount; i++)
        {
            var element = transform.GetChild(i).gameObject;
            element.SetActive(false);
            m_Markers.Add(element);
        }
        
        EnableFirstElement(); //최초 처음꺼 on
        dir_Arrow.GetComponent<DirectionArrow>().SetMarker(m_Markers[0].transform);
    }

    public void Clear() //자식인 mission marker에서 호출 , !!다른 관련함수 모두 호출!!
    {
        Destroy(m_Markers[0]);
        m_Markers.Remove(m_Markers[0]);

        if(m_Markers.Count > 0 )
        {
            EnableFirstElement();
            dir_Arrow.GetComponent<DirectionArrow>().SetMarker(m_Markers[0].transform);
           
        }
        
    }

    private void EnableFirstElement()
    {
        m_Markers[0].gameObject.SetActive(true);
    }
}
