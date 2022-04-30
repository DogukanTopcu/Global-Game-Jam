using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
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
            Vector3 tempLocalPosition = other.gameObject.transform.localPosition;
            tempLocalPosition = new Vector3(0.6f, -1.6f, -5f);
            other.gameObject.transform.localPosition = tempLocalPosition;
        }
    }
}
