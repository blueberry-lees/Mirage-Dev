using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public string sceneName;


    public void SceneChange()
    {
        //load a scene

       StartCoroutine(LoadNextScene(sceneName));

    }


    public IEnumerator LoadNextScene(string sceneName)
    {
        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
