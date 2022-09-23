using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameLauncher : MonoBehaviour
{
    public void LaunchOnClick()
    {
        SceneManager.LoadScene("FirstScene", LoadSceneMode.Single);
    }
}
