/// <summary>
/// mission marker에 직접 부착
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMarker : MonoBehaviour
{
    private Renderer renderer;
    private float limitSec = 1;
    private float timer = 0;

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
            transform.parent.GetComponent<MissionMarkerManager>().Clear();
            GetComponent<BoxCollider>().enabled = false;
            timer = 0;
        }
    }
    
}
