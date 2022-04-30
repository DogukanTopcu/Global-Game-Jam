using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveWolfText : MonoBehaviour
{
    public Text script;
    public GameObject RestartButton;
    public GameObject ExitButton;
    string text = "Little Girl's mom got worried when she didn't come back home, so she and some villagers got to searching the grandma's house. It was empty, other than blood stains. The girl, her grandma and others who lived in the forest could not be found. The wolf survived a little longer, fuller.";
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
