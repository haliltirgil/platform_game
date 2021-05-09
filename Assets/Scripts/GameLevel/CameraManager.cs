using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform target;

    public float cameraSpeed=0.05f;
    
    void Update()
    {
        //İlk yöntem budur. Çalışır ama kamera daha keskin hareket eder.
        //transform.position = new Vector3(target.position.x, target.position.y, target.position.z);

        //ikinci yöntem ise özel bir fonksiyondur ve aşağıdaki şekildedir. 
        //Başlangıç noktası hareket noktası ve verilen kamera hızı parametreline göre kamerayı hareket ettirir.
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z), cameraSpeed);
    }
}
