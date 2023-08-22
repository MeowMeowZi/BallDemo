using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMono : MonoBehaviour
{
    [SerializeField] private Button reloadBtn;
    
    private void Awake()
    {
        reloadBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        });
    }
}
