using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class WgameManager : MonoBehaviour
{
    public GameObject stopPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Pause();

        }
    }
    // public void StartGame()
    // {
    //     move.moveSpeed = 4f;
    //     move.jumpSpeed = 350f;

    //     Time.timeScale = 1;
      

    // }
    public void ResumeGame()
    {
        move.moveSpeed = 4f;
        move.jumpSpeed = 350f;


        stopPanel.transform.DOMoveY(1625, 1f);

    }
    public void Pause()
    {
        move.moveSpeed = 0f;
        move.jumpSpeed = 0f;

        stopPanel.transform.DOMoveY(530, 1f);
    }


    public void Exit()
    {
        Application.Quit();
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
