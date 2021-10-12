using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoMove : MonoBehaviour
{

    [SerializeField] GameObject initObject;

    InitScript initScript;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        initObject = GameObject.Find("InitScript");
        initScript = initObject.GetComponent<InitScript>();
        speed =initScript.naveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = initScript.naveSpeed;
        transform.Translate(Vector3.back * speed);

        //Destruyo el objeto al salir de cámara
        float posZ = transform.position.z;
        if(posZ < -20)
        {
            Destroy(gameObject);
        }
    }
}
