using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //player position
    public Vector2 playerPos;

    //player health
    public float playerHealth;

    //player stamima
    public float playerStamina;

    //player code fragments
    public int CodeFrags;

    public int PlayerDeaths;
    public int virusesKilled;

    public int PMasV, pMusV, PSEV;
    public int RES_i;
    public bool win;
    public int LH, MH, SH;
    public Slider healthBar;
    
    

    void Start()
    {
        if(LoadingGame.isLoadGame == true)
        {
            GameData data = SaveSystem.LoadSettings();
            playerHealth = data.playerHealth;
            transform.position = new Vector2(data.playerPos[0], data.playerPos[1]);



            playerStamina = data.playerStamina;
            CodeFrags = data.CodeFrags;
            PlayerDeaths = data.PlayerDeaths;
            virusesKilled = data.virusesKilled;
            PMasV = data.MasterVolume;
            pMusV = data.MasterVolume;
            PSEV = data.SoundEffectsVolume;
            RES_i = data.resolutionIndex;
            win = data.IsWindowed;
        }
        else 
        {
            //new game set defaults
            playerHealth = 100;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth;
    }
    public void TakeDamage(float Damage)
    {
        playerHealth -= Damage;
        if (playerHealth < 0)
        {
            SceneManager.LoadScene("start Menu", LoadSceneMode.Single);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
        if (collision.gameObject.CompareTag("SceneLoad"))
        {
            SceneManager.LoadScene("StageTwo", LoadSceneMode.Single);
        }
        if (collision.gameObject.CompareTag("Error"))
        {
            SceneManager.LoadScene("start Menu", LoadSceneMode.Single);
        }
        if (collision.gameObject.CompareTag("LH"))
        {
            LH++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("MH"))
        {
            MH++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("SH"))
        {
            SH++;
            Destroy(collision.gameObject);
        }
    }

    public void  Use_LH()
    {
        if (LH > 0)
        {
            playerHealth += 20;
        }

    }
    public void Use_MH()
    {
        if (MH > 0)
        {
            playerHealth += 10;
        }

    }
    public void Use_SH()
    {
        if (SH > 0)
        {
            playerHealth += 5;
        }

    }
}
