using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
[SerializeField] AudioSource audioSource;
[SerializeField] GameObject clickSound;
[SerializeField] float FadeTime = 2f;

    public void playGame()
    {
        GameObject sfx = Instantiate(clickSound, transform.position, Quaternion.identity);
        StartCoroutine(FadeOut(audioSource, FadeTime));
        
    }
        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        audioSource.Stop();
        SceneManager.LoadScene(1);
    }
}
