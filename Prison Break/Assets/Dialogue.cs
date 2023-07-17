using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    private int index = 0;
    private bool[] conditions = new bool[3];
    bool finishedDialogue = false;

    private void Awake()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            //conditions[i] = false;
            print(i);
            conditions.Append(false);
        }
    }

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        conditions[1] = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        conditions[2] = Input.GetMouseButtonDown(0);
        finishedDialogue = Input.GetKeyDown(KeyCode.E) && index == lines.Length - 1;
        if (conditions[index]) StartDialogue();
        if (finishedDialogue)
        {
            gameObject.SetActive(false);
        }
    }

    void StartDialogue()
    {
        textComponent.text = lines[index];
        if (index < lines.Length - 1) index++;
    }
}
