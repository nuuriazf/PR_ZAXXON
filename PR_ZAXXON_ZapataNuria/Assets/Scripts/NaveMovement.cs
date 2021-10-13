using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMovement : MonoBehaviour
{
    //Movimiento de desplazamiento
    [SerializeField] float desplSpeed;

    //Variables para la restricci�n de movimiento
    float limiteR = 30;
    float limiteL = -30;
    float limiteU = 20;
    float limiteS = 2;

    //Variable booleana que determina si puedo moverme o no
    bool inLimitH = true;
    bool inLimitV = true;

    // Start is called before the first frame update
    void Start()
    {
        desplSpeed = 40f;
    }

    // Update is called once per frame
    
    void Update()
    {
        //Obtengo los valores de los ejes y los asigno a variables
    
        float desplH = Input.GetAxis("Horizontal");
        float desplV = Input.GetAxis("Vertical");


        //Variables de posici�n en X y en Y para la restricci�n
        float posX = transform.position.x;
        float posy = transform.position.y;

        // H and V Movement Restricted
       // (si est� en el l�mite de H true, se mover�)
        if (inLimitH)
        {
            transform.Translate(Vector3.right * Time.deltaTime * desplH * desplSpeed, Space.World);
        }

        // (si est� en el l�mite de V true, se mover�)
        if (inLimitV)
        {
            transform.Translate(Vector3.up * Time.deltaTime * desplV * desplSpeed, Space.World);
        }
        // Si la posicion de x supera el l�mite de la derecha y est� en la zona +0 (derecha) ooooo la posicion de x supera el l�mite de la izquierda y est� en la zona de la izq, no se mover�)
        if (posX > limiteR && desplH > 0 || posX < limiteL && desplH < 0)
        {
            inLimitH = false;
        }
        // si no cumple eso, s� se mover�
        else
        {
            inLimitH = true;
        }
        // igual que antes pero en vertical.
        if (posy > limiteU && desplV > 0 || posy < limiteS && desplV < 0)
        {
            inLimitV = false;
        }
        else
        {
            inLimitV = true;
        }

    }


}
