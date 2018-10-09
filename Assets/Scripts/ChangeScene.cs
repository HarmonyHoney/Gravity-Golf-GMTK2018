using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    [SerializeField] public string nextScene;

    public void LoadNextScene() {

        SceneManager.LoadScene(nextScene);
    }

    public string ActiveSceneName() {

        return SceneManager.GetActiveScene().name;
    }

}
