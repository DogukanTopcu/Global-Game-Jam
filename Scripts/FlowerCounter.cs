using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerCounter : MonoBehaviour
{
    int tempCount;
    GameObject past;
    GameObject now;

    // Update is called once per frame
    void Update()
    {
        if (CollectFlower.flowerCounter == 0)
        {
            past = this.gameObject.transform.GetChild(CollectFlower.flowerCounter).gameObject;
            now = this.gameObject.transform.GetChild(CollectFlower.flowerCounter).gameObject;
        }
        //else if (CollectFlower.flowerCounter > 0)
        //{
        //    past = this.gameObject.transform.GetChild(CollectFlower.flowerCounter - 1).gameObject;
        //    now = this.gameObject.transform.GetChild(CollectFlower.flowerCounter).gameObject;
        //}

        if (tempCount != CollectFlower.flowerCounter)
        {
            now.SetActive(false);
            now = this.gameObject.transform.GetChild(CollectFlower.flowerCounter).gameObject;
            now.SetActive(true);
        }
    }
}
