using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGirlText : MonoBehaviour
{
    public Text script;
    public GameObject RestartButton;
    public GameObject ExitButton;
    string text = "The girl escaped, ran to her house as fast as she can. She let her mom and the other villagers know about the wolf lurking in the forest. They took of to the forest to hunt the wolf. The wolf was found in grandmother's house, weak because of his hunger. He was easily hunted by the villagers.";
    void Start()
    {
        StartCoroutine(Text());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Text(){
        yield return new WaitForSeconds(2f);
        foreach (var item in text)
        {
            script.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.3f);
        RestartButton.SetActive(true);
        ExitButton.SetActive(true);
    }
}
