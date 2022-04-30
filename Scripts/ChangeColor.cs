using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    bool colorStatus = false;
    SpriteRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckF();
    }
    void CheckF()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            colorStatus = !colorStatus;
        }
    }
    void LateUpdate() {
        ColorChanger();    
    }
    void ColorChanger()
    {
        if(colorStatus ==  true)
        {

            myRenderer.color = Color.Lerp(Color.black, Color.white, Time.deltaTime);
        }
        else {
            myRenderer.color = Color.Lerp(Color.white, Color.black, Time.deltaTime);
        }
    }
}
