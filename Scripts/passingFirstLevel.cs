using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passingFirstLevel : MonoBehaviour
{
    public GameObject warningPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            if (CollectFlower.flowerCounter == 9)
            {
                SceneManager.LoadScene(1);
            }
            else if (CollectFlower.flowerCounter < 9)
            {
                StartCoroutine(Warning());
            }
        }

        IEnumerator Warning(){
            warningPanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            warningPanel.SetActive(false);
        }
    }
}
