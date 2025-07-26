/// <summary>
/// mission marker에 직접 부착
/// 해당 체크포인트 도달해야 장애물 삭제하고 열리게 하기 기능
/// </summary>
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionMarker : MonoBehaviour
{
    private Renderer renderer;
    private float limitSec = 1;
    private float timer = 0;

    public float playerRespawnRot = 0f;
    public GameObject[] delete_Obstacles; //삭제될 obstacles

    private void Awake()
    {
        renderer = GetComponentInChildren<Renderer>();    
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CountSec();
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timer = 0;
        }
    }
    void CountSec()
    {
        timer += Time.deltaTime;

        if(timer >= limitSec)
        {
            CheckMarker();
            DeleteObstables();
        }
    }
    void CheckMarker()
    {
        PlayerRespawner.Instance.SetTransform(transform.position, playerRespawnRot); // 로테이션값 각각 따로니까 manager에서 말고 직접 호출

        transform.parent.GetComponent<MissionMarkerManager>().Clear();
        GetComponent<BoxCollider>().enabled = false;
        timer = 0;
    }
    void DeleteObstables()
    {
        if(delete_Obstacles != null && delete_Obstacles.Length != 0)
        {
            foreach(GameObject obstacle in delete_Obstacles)
            {
                Destroy(obstacle);
            }
        }
    }
}
