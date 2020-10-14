using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController controller;
    //Crea colisiones de una vez
    public float speed = 10f;
    public float gravity = -7.0f;
        
    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    //Recordemos que las variables que sean publicas Unity te las agrega al inspector de elementos

    // Start no es necesario para esto del movimiento
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Verifica si estamos realmente en el suelo parados

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        //transform convierte nuestros inutiles numeros en manejadores que Unity puede entender/utilizar
        controller.Move(movement * speed * Time.deltaTime);
        //qué movimiento, a qué velocidad y Time.deltaTime -> tiempo desde ultimo frame

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //Se encarga de moverse hacia abajo (por la gravedad)
    }
}
