using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private RectTransform rect;
    private int currentPos;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        //Changing the position of the arrow
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            ChangePosition(-1);
        }
        else if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }

        //Interacting with the option
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    private void ChangePosition(int _change)
    {
        currentPos += _change;

        if(_change != 0)
        {
            SoundManager.instance.PlaySound(changeSound);
        }

        if(currentPos < 0)
        {
            currentPos = options.Length - 1;
        }
        else if(currentPos > options.Length-1)
        {
            currentPos = 0;
        }

        // If the current position is less than 0, set it to the last position
        rect.position = new Vector3(rect.position.x, options[currentPos].position.y, 0);
    }

    public void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        //Acces the button component and simulate a click
        options[currentPos].GetComponent<Button>().onClick.Invoke();
    }
}
