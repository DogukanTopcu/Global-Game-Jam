using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    // public Transform cameraTop;
    // public Transform cameraBottom;
    // public Transform cameraRight;
    // public Transform cameraLeft;


    public Transform target;
    public float cameraSpeed = 0.05f;

    private void Update() {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), cameraSpeed);
    }

    // private void OnTriggerExit2D(Collider2D other) {
    //     if (other.tag == "Player")
    //     {
    //         if (other.transform.position.y < cameraTop.position.y && other.transform.position.y > cameraBottom.position.y)
    //         {
    //             if (other.transform.position.x < cameraLeft.position.x)
    //             {

    //                 Vector3 tempLocalPosition = transform.localPosition;
    //                 tempLocalPosition.x -= 18;
    //                 // transform.localPosition = tempLocalPosition;
    //                 transform.DOMove(tempLocalPosition, 0.3f);
    //             }
    //             if (other.transform.position.x > cameraRight.position.x)
    //             {
    //                 Vector3 tempLocalPosition1 = transform.localPosition;
    //                 tempLocalPosition1.x += 18;
    //                 // transform.localPosition = tempLocalPosition;
    //                 transform.DOMove(tempLocalPosition1, 0.3f);
    //             }
    //         }
    //         else if (other.transform.position.x < cameraRight.position.x && other.transform.position.x > cameraLeft.position.x)
    //         {
    //             if (other.transform.position.y < cameraBottom.position.y)
    //             {
    //                 Vector3 tempLocalPosition2 = transform.localPosition;
    //                 tempLocalPosition2.y -= 10;
    //                 transform.DOMove(tempLocalPosition2, 0.3f);
    //             }
    //             if (other.transform.position.y > cameraTop.position.y)
    //             {
    //                 Vector3 tempLocalPosition3 = transform.localPosition;
    //                 tempLocalPosition3.y += 10;
    //                 transform.DOMove(tempLocalPosition3, 0.3f);
    //             }
    //         }
    //     }
        
    // }
}
