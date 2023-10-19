using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitAction : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlayAudio()
    {
        audioSource.Play();
        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("GameScene");
    }
}
