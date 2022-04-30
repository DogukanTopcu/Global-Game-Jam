using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CountDownScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_text;
    public float timerTime = 10;
    float degree;
    void Start()
    {
        degree = 180 / timerTime;
        StartCoroutine(timeTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator timeTimer()
    {
        while (true)
        {
            RotateObject((float) degree);
            yield return new WaitForSeconds(1);
            timerTime--;
            if (timerTime <= 1)
            {
                break;
            }
        }
        GameOver();
    }

    void GameOver()
    {
        StartCoroutine(Over());
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        IEnumerator Over(){
            m_text.SetActive(true);
            yield return new WaitForSeconds(3f);
        }

    }

    void RotateObject(float degree)
    {
        this.gameObject.transform.Rotate(new Vector3(0, 0, degree));
    }
    
}
