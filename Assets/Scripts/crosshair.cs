using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class crosshair : MonoBehaviour{
    public float sensitivity = 180f;
    public Transform player1;
    float xRotation = 0f; 
    //Esta variable lee constantemente la ubicación de el eje y, deberia llamarse yRotations but who cares
    
// Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Fija el cursor al centro de la ventana del juego, obvio necesario para un shooter
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //en cada cuadro actualizamos la ubicacion en X, esto moviendolo por
        //sensibilidad y tiempo desde el ultimo cuadro

        if(Mathf.Abs(mouseX) > 20 || Mathf.Abs(mouseY) > 20)
            //al parecer verifica si los movimientos fueron mayores a "20"-> sacado proyecto Minecraft Sam Hogan
            return;
        
        xRotation -= mouseY; //Actualizamos donde estamos en "y" actualmente
        xRotation = Mathf.Clamp(xRotation, -90f, 75f); //Clamp limita los valores de una variable dada "xRotation"

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //RITACION EN Y
        player1.Rotate(Vector3.up * mouseX);
        //ROTACIÓN EN X
    }
}
