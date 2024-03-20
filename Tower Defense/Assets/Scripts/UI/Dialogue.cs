using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Wave_Spawning;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject dialogueBox;

    private int index;

    private WaveFactory _waveIndex;
    [SerializeField] private int _desiredWaveIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = String.Empty;
        StartDialogue();
        _waveIndex.GetComponent<WaveFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
            
            Wave wave = _waveIndex.GetWave(waveIndex: 5);

            if (wave != null)
            {
                gameObject.SetActive(true);
                Debug.Log("Dialog Pop Up");
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
        foreach (char c in lines[index].ToCharArray())
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
            textComponent.text = String.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
