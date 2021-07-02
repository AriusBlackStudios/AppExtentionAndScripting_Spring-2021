using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    //player position
    public float[] playerPos;



    //player health
    public float playerHealth;

    //player stamima
    public float playerStamina;

    //player code fragments
     public int CodeFrags;

    public int PlayerDeaths;
    public int virusesKilled;

    //player setting (volumes and stuff)
    public int MasterVolume, MusicVolume, SoundEffectsVolume;
    public int resolutionIndex;
    public bool IsWindowed;


    public GameData(Player player)
    {
        playerPos = new float[2];
        playerPos[0] = player.transform.position.x;
        playerPos[1] = player.transform.position.y;

        playerHealth = player.playerHealth;
        playerStamina = player.playerStamina;
        CodeFrags = player.CodeFrags;
        PlayerDeaths = player.PlayerDeaths;
        virusesKilled = player.virusesKilled;
        MasterVolume = player.PMasV;
        MusicVolume = player.pMusV;
        SoundEffectsVolume=player.PSEV;
        resolutionIndex = player.RES_i;
        IsWindowed = player.win;

    }

    //public GameData()
    //{
    //    playerPos;

    //    playerHealth;
    //    playerStamina;
    //    CodeFrags;
    //    PlayerDeaths;
    //    virusesKilled;
    //    MasterVolume;
    //    MusicVolume;
    //    SoundEffectsVolume;
    //    resolutionIndex;
    //    IsWindowed;
    //}



}
