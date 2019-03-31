using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    void OnClick()
    {
        SceneManager.loadScene(0);
    }
}
