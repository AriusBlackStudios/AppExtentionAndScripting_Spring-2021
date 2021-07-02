using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//jade ainsworth
//AppExtensionsAndScripting
//spring2021

public class Player : MonoBehaviour
{
    public bool isControllerConnected;
    public string ControllerProfile="";
    //public KeyCode Xbox_horizontal, Xbox_vert, Xbox_shoot;
    //public KeyCode Keys_left, Keys_right, Keys_forward, Keys_backward,Keys_rotateLeft,Keys_rotateRight,Keys_shoot;
    public float speed = 5;
    public GameObject Shot,Shot2,panel;
    public Transform gun;
    public float health = 100;
    public Slider HealthBar;
    public Text message,message2;
    public int zombies;
    public float healthTimer;
    float closeProgram=3;
    float shotTimer=0;
    void Start()
    {
        isControllerConnected = false;
        ControllerProfile = "WASD";
        zombies = FindObjectsOfType<Enemy>().Length;
        Debug.Log(zombies);
        
    }

    void Update()
    {
        if (health > 0)
        {
            CheckController();
            shotTimer += Time.deltaTime;
            Controls();
            HealthBar.value = health;
            healthTimer += Time.deltaTime;
            if (healthTimer >= 10 && health < 100)
            {
                health += 2 * Time.deltaTime;
            }
            if (zombies <= 0)
            {
                message.text = "you win!";
                closeProgram -= Time.deltaTime;
                if (closeProgram < 0)
                {
                    Application.Quit();
                }
            }
        }
        else if (health <= 0)
        {
            message.text = "you died";
            closeProgram -= Time.deltaTime;
            if (closeProgram < 0)
            {
                Application.Quit();
            }
        }
        
    }

    void CheckController()
    {
        try
        {
            if (Input.GetJoystickNames()[0] != null)
            {
                isControllerConnected = true;

            }
        }
        catch
        {
            isControllerConnected = false;
        }
    }


    void Controls()
    {
        if (ControllerProfile == "WASD")
        {
            message2.text = "press tab to open control options menu";
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                panel.SetActive(true);
            }
            //Rotate with mouse. x and z rotations are locked in the editor becuase player was toppling
            float MouseRotate = speed * Input.GetAxis("Mouse X");
            transform.Rotate(0, MouseRotate, 0);

            //movement
            if (Input.GetAxis("MoveLeft") > 0)
            {
                //not sure why space.self wasnt working. so i had to change it to world and now it moves correctly.
                this.transform.Translate(-transform.right * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetAxis("MoveRight") > 0)
            {
                this.transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
            }

            if (Input.GetAxis("MoveForward") > 0)
            {
                this.transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetAxis("MoveBackward") > 0)
            {
                this.transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Shoot();
            }

        }
        else if (ControllerProfile == "IJKL")
        {
            message2.text = "press tab to open control options menu";
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                panel.SetActive(true);
            }
            if (Input.GetAxis("RotateLeft") > 0)
            {
                transform.Rotate(0, -1, 0);
            }
            if (Input.GetAxis("RotateRight") > 0)
            {
                transform.Rotate(0, 1, 0);
            }
            if (Input.GetAxis("MoveXaxis_JL") > 0)
            {
                this.transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetAxis("MoveXaxis_JL") < 0)
            {
                this.transform.Translate(-transform.right * Time.deltaTime * speed, Space.World);
            }

            if (Input.GetAxis("MoveYaxis_IK") > 0)
            {
                this.transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetAxis("MoveYaxis_IK") < 0)
            {
                this.transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }

        }
        else if (ControllerProfile == "XBOX")
        {
            message2.text = "press Y to open control options menu";
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                panel.SetActive(true);
            }
            if (Input.GetAxis("XBOX_Rotate") < -.9 || Input.GetAxis("XBOX_Rotate") > .9)
            {
                float xboxRotate = Input.GetAxis("XBOX_Rotate");
                transform.Rotate(0, xboxRotate, 0);
            }

            if (Input.GetAxis("XBOX_Verticle") < -.9)
            {
                this.transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetAxis("XBOX_Verticle") > 0.9)
            {
                this.transform.Translate(-transform.forward * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetAxis("XBOX_Horizontal") < -0.9)
            {
                //not sure why space.self wasnt working. so i had to change it to world and now it moves correctly.
                this.transform.Translate(-transform.right * Time.deltaTime * speed, Space.World);
            }
            if (Input.GetAxis("XBOX_Horizontal") > 0.9)
            {
                //not sure why space.self wasnt working. so i had to change it to world and now it moves correctly.
                this.transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
            }
            //using the project settings i originally made gave a sort of waterhose affect, so i opted
            //for getkey down so it only shoots when you press the button
            //rather than per frame, even in fixed update it was still pretty bad
            //and using time.deltatime gave it a really grose lag and it felt like the controller wasnt processing
            //inputs but it was just the time
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                Shoot();
            }
        }

        //not implemented
        if (ControllerProfile == "CustomKeyboard")
        {
        }
        if (ControllerProfile == "CustomXbox")
        {

        }
    }
    void Shoot()
    {
        //  Debug.Log("pew pew");
        int x = Random.Range(0, 2);
      //  if (shotTimer >= 0.001f)
       // {
            if (x == 0)
            {
                Instantiate(Shot, gun.position, gun.rotation);
               // shotTimer = 0;
            }
            else
            {
                Instantiate(Shot2, gun.position, gun.rotation);
               // shotTimer = 0;
            }
       // }
    }

    public void LoseHealth(float change)
    {
        health -= change;
        //timer resets so the player has to wait ten more seconds to heal if they get hit
        healthTimer = 0;
      //  Debug.Log("Health Changed:"+ health);
    }
}
