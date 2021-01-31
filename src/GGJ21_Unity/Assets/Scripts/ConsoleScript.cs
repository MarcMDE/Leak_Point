using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    [SerializeField] float letterTime, endTime;
    [SerializeField] Text text;
    float counter;
    int line, letter;
    bool end;

    string[] sentences = { "Aborting induced letargy…",
                           "Enter security password",
                           "Loading data from external device D74X",
                           "ERROR – Wrong password",
                           "ERROR – Wrong password",
                           "ERROR – Wrong password",
                           "ERROR – Wrong password",
                           "ERROR – Wrong password",
                           "ERROR – Wrong password",
                           " ",
                           "D74X log < Could not crack password >",
                           "D74X log < Loading hash list… >",
                           "D74X log < Generating human-friendly enviroment… >",
                           "D74X log < Generating hash maps… >",
                           "D74X log < Critical task: Find 4 password tokens! >",
                           "_"
    };


    void Start()
    {
        counter = 0f;
        line = 0;
        letter = 0;
        text.text += ">>> ";
        end = false;

        text.fontSize = Screen.height / 20;
    }

    
    void Update()
    {
        if (!end)
        {
            if (counter < letterTime)
            {
                counter += Time.deltaTime;
            }
            else if (letter < sentences[line].Length)
            {
                NewLetter();
            }
            else if (line < sentences.Length)
            {
                NewLine();
            }
        }
        else
        {
            if (counter < endTime)
            {
                counter += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("JaviScene");
            }
        }
    }

    void NewLine()
    {
        text.text += "\n>>> ";
        line++;
        letter = 0;
        counter = 0f;
        if (line >= sentences.Length)
            end = true;
    }

    void NewLetter()
    {
        text.text += sentences[line][letter];
        letter++;
        counter = 0f;
    }
}
