using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Light flashLight;
    private float lightTimer = 1;
    public int charges = 3;
    private Vector3 position;
    private Vector2 playerInput;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.y > 0)
        {
            position.y += speed * Time.deltaTime;
        }
        else
        {
            position.y -= speed * Time.deltaTime;
        }

        if(playerInput.x > 0)
        {
            position.x += speed * Time.deltaTime;
        }
        else
        {
            position.x -= speed * Time.deltaTime;
        }


        if (flashLight.enabled == true)
        {
            lightTimer -= Time.deltaTime;

            if (lightTimer <= 0)
            {
                flashLight.enabled = false;
                lightTimer = 1;
            }
        }

        gameObject.Transform.positon += position;
    }

    private void OnFlashLight(InputValue value)
    {
        if (charges > 0 && flashLight.enabled == false)
        {
            flashLight.enabled = true;
            charges -= 1;
        }
    }

    public void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
}
