using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorObstaculo : MonoBehaviour
{

    [SerializeField] GameObject obst1; 
    [SerializeField] GameObject obst2; 

    [SerializeField] Transform initPos;

    [SerializeField] GameObject[] arrayObst;
    InitScript initScript;
    int level;
    float intervalo;
    

    void Start()
    {
       
        initScript = GameObject.Find("initObject").GetComponent<InitScript>();
        intervalo = 1f; 
        StartCoroutine("CrearObstaculos");

    }

   

    //Corrutina 
    IEnumerator CrearObstaculos()
    {
        //GameObject obstRandom;
        while (true)
        {
 
            Vector3 instPos = new Vector3(Random.Range(-10f, 10f), 0f, initPos.position.z);
            int randomNum;
            level = initScript.levelGame;
            print(level);
            
            if (level == 0)
            {
                randomNum = 0;
            }
            else if (level > 0 && level < 4)
            {
                randomNum = Random.Range(0, 5);
            }
            else
            {
                //En este caso, el n� aleatorio es entre 0 y la longitud del Array
                randomNum = Random.Range(0, arrayObst.Length);
            }

     
            Instantiate(arrayObst[randomNum], instPos, Quaternion.identity);

            yield return new WaitForSeconds(intervalo);

        }
    }
}
