using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStartAction : MonoBehaviour
{
    [SerializeField] private Button buttonStart;

    private void Start()
    {
        buttonStart.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene() 
    {
        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameScene");
    }
}
