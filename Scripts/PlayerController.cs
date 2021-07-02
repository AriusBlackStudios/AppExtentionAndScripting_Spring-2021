using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{


    //player stats
    public int healthPotions, manaPotions, EnemiesKilled, crystalsFound;
    public CharacterController controller;
    public float speed = 10f;
    float TurnSmoothVelocity;
    public float TurnSmoothTime = 0.1f;
    public Transform Cam;


    public bool isPlayerAlive;
    public float PlayerHealth, PlayerMana;
    public float pHeath { get { return PlayerHealth; } }
   
    //three different weapons
    public float blackmagic, firemagic, bloodmagic;


    //UI elements
    public Text playerMemo;
    public Slider playerHealth,playerMana;
    public GameObject instructions;
    public Text heals, manas, kills, collectables;

    //magic system stuff
    public Transform MagicOrigin;
    public string[] magicSystem;
    public string magic;
    public int magicIndex;
    public float cTime, mTime;


    void Start()
    {
        //filling magic system
        magicSystem = new string[3];
        magicSystem[0] = "BlackMagic";
        magicSystem[1] = "FireMagic";
        magicSystem[2] = "BloodMagic";
        magicIndex = 0;
        magic = magicSystem[magicIndex];
        isPlayerAlive = true;

        healthPotions = 0;
        manaPotions = 0;
        EnemiesKilled = 0;
        crystalsFound=0;


        mTime = 1;
        PlayerHealth = playerHealth.maxValue;
        PlayerMana = playerMana.maxValue;
        instructions.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

        playerHealth.value = PlayerHealth;
        playerMana.value = PlayerMana;
        if (isPlayerAlive)
        {
            //controls
           Move();
          
            if (Input.GetAxis("Dpad Magic") > 0)
            {
                magicIndex++;
                if (magicIndex > 2)
                {
                    magicIndex = 0;
                }
                magic = magicSystem[magicIndex];
                playerMemo.text ="" + magic + " equipted";
            }
            if (Input.GetAxis("Dpad Magic") < 0)
            {
                magicIndex--;
                if (magicIndex < 0)
                {
                    magicIndex = 2;
                }
                magic = magicSystem[magicIndex];
                playerMemo.text = "" + magic + " equipted";
            }
            if (Input.GetAxis("CastSpell") > 0 && PlayerMana>0)
            {
                MagicAttack();
            }

            if (Input.GetAxis("Instructions") > 0 )
            {
                if(instructions.activeSelf == true)
                {
                    instructions.SetActive(false);
                }
                else
                {
                    instructions.SetActive(true);
                }
            }

        }
        else
        {
            instructions.SetActive(true);
            heals.text = "Health Potions Used: " + healthPotions;
            manas.text = "Mana Potions Used: " + manaPotions;
            kills.text = "Enemies Killed: " + EnemiesKilled;
            collectables.text = "Crystals found: " + crystalsFound;
        }
    }
    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) *Mathf.Rad2Deg + Cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, Angle, 0f)* Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    public void MagicAttack()
    {
        if (magic == "BloodMagic")
        {
            Instantiate(Resources.Load("BloodMagic"), MagicOrigin.position, MagicOrigin.rotation);
            UseMana(10);
        }

        else if (magic == "FireMagic")
        {
            Instantiate(Resources.Load("FireMagic"), MagicOrigin.position, MagicOrigin.rotation);
            UseMana(1);
        }

        else if (magic == "BlackMagic")
        {
            Instantiate(Resources.Load("BlackMagic"), MagicOrigin.position, MagicOrigin.rotation);
            UseMana(5);
        }
    }


   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
           // inventory.AddItem();
        }
    }

    public void DamagePlayer(float change)
    {


            PlayerHealth = PlayerHealth -change;
            playerMemo.text = "Physical damage taken " + change;
            if (PlayerHealth <= 0)
            {
                isPlayerAlive = false;
            }


    }
    public void HealPlayer(float healing)
    {
        PlayerHealth = PlayerHealth + healing;
        if (PlayerHealth > playerHealth.maxValue)
        {
            PlayerHealth = playerHealth.maxValue;
            //go ahead waste you potions. i dare ya
        }
    }

    public void UseMana(float manaCost)
    {
        PlayerMana -= manaCost;
    }
    public void RecoverMana(float mana)
    {
        PlayerMana += mana;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
