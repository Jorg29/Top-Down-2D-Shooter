using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour {

    private Animator transitionAnim;

    private void Start()
    {
        transitionAnim = GetComponent<Animator>();
        // Start the transition automatically when the script is initialized.
        StartCoroutine(Transition("Menu"));
    }

    IEnumerator Transition(string sceneName) 
    {
        yield return new WaitForSeconds(5); // Wait for 5 seconds
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}