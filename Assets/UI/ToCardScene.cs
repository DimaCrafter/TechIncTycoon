using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCardScene : MonoBehaviour
{
    public int sceneNumber;
    public void SceneChange()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
