using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button btn;
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener((ChangeScene));
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
