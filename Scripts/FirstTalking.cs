using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FirstTalking : MonoBehaviour
{
    public static GameObject panel;

    public GameObject momBaloon;
    public GameObject girlBaloon;
    public Text mom;
    public Text girl;

    string text1 = "Good morning, mom!";
    string text2 = "Good morning honey. Can you visit you grandmother today?";
    string text3 = "She would be happy to see you.";
    string text4 = "Of course mom. Should I bring anything?";
    string text5 = "Here, take this basket.";
    string text6 = "Pick up 9 flowers on the way, ok?";
    string text7 = "And don't wander around too much,";
    string text8 = "go there before the sunset!";


    void Start()
    {
        girlBaloon.transform.DORotate(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.OutBack);
        girlBaloon.transform.DOScale(new Vector3(1, 1, 0), 1.5f).SetEase(Ease.OutBack);

        momBaloon.transform.DORotate(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.OutBack);
        momBaloon.transform.DOScale(new Vector3(1, 1, 0), 1.5f).SetEase(Ease.OutBack);
        StartCoroutine(Starting());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Starting(){
        yield return new WaitForSeconds(2f);
        foreach (var item in text1)
        {
            girl.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.3f);
        foreach (var item in text2)
        {
            mom.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.9f);
        mom.text = "";
        foreach (var item in text3)
        {
            mom.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.2f);
        girl.text = "";
        foreach (var item in text4)
        {
            girl.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.3f);
        mom.text = "";
        foreach (var item in text5)
        {
            mom.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.4f);
        mom.text = "";
        foreach (var item in text6)
        {
            mom.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.4f);
        mom.text = "";
        girl.text = "";
        foreach (var item in text7)
        {
            mom.text += item;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.6f);
        mom.text = "";
        foreach (var item in text8)
        {
            mom.text += item;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);
        girlBaloon.transform.DORotate(new Vector3(0, 0, -90), 1.5f).SetEase(Ease.InBack);
        girlBaloon.transform.DOScale(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.InBack);

        momBaloon.transform.DORotate(new Vector3(0, 0, 90), 1.5f).SetEase(Ease.InBack);
        momBaloon.transform.DOScale(new Vector3(0, 0, 0), 1.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(2f);

        // panel.SetActive(false);
    }
}
