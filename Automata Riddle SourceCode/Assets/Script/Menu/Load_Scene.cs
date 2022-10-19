using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene : MonoBehaviour
{
    public Animator animator;
    public string Scene_name;
    float transitiontime = 1f;
    public void loadNewScene()
    {
        SceneManager.LoadScene(Scene_name);
    }

    public void LoadNewSceneTransition1()
    {
        StartCoroutine(LoadSceneTransition1Coroutine(Scene_name));
           
    }
    IEnumerator LoadSceneTransition1Coroutine(string sceneName)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);

        SceneManager.LoadScene(Scene_name);

    }
}
