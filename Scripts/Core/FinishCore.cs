using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // Mevcut sahnenin index'ini al
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Bir sonraki sahneye geç
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
