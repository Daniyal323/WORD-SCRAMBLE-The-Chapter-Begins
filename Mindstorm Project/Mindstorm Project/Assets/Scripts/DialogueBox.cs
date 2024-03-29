using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty; 
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 1f;
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
                //Time.timeScale = 0f;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                //Time.timeScale = 1f;
            }
        }   
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            Time.timeScale = 0f;
            StartCoroutine(TypeLine());
        }
        else
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}
