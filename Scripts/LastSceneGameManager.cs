using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSceneGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveTheGirl(){
        SceneManager.LoadScene(3);
    }

    public void SaveTheWolf(){
        SceneManager.LoadScene(4);
    }
}
