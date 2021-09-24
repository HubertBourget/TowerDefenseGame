using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] GameObject clickSound;
    [SerializeField] float delay = 1.5f;
    public void ReloadLevel()
    {
        GameObject sfx = Instantiate(clickSound, transform.position, Quaternion.identity);

        StartCoroutine(DelayRestartScene());
    }

    IEnumerator DelayRestartScene()
    {
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
