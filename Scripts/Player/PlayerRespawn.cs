using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private Health health;
    private UIManager UIManager;

    private void Awake()
    {
        health = GetComponent<Health>();
        UIManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        //Checking if checkpoint available
        if(currentCheckpoint == null)
        {
            //Showing game over
            UIManager.GameOver();

            return;
        }

        transform.position = currentCheckpoint.position;
        health.Respawn();

        //Camera.main.GetComponent<CameraController>().MoveNewRoom(currentCheckpoint.parent);
    }

    //Activating checkpoint

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}
