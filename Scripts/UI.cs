using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//jade ainsworth
//AppExtensionsAndScripting
//spring2021
public class UI : MonoBehaviour
{
    //customization screen
    public GameObject CustomizeKeys, CustomizeXBOX;
    public Player player;
    public GameObject panel;

    //refering to the text feilds for the keytboard customizatino screen
    //public Text Keys_ML, Keys_MR, Keys_MF, Keys_MB, Keys_RL, Keys_RR, Keys_S;
    //public InputField[] keys;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        //keys = new InputField[7];
    }

    //Control switching UI
    public void ChangeToWASD()
    {
        player.ControllerProfile = "WASD";
        panel.SetActive(false);
    }
    public void ChangeToIJKL()
    {
        player.ControllerProfile = "IJKL";
        panel.SetActive(false);
    }
    public void ChangeToXBOX()
    {
        player.ControllerProfile = "XBOX";
        panel.SetActive(false);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    //set inactive in the editor becuase i couldnt get the keycode things to make sense
    public void ChangeCusKey()
    {
        CustomizeKeys.SetActive(true);
        panel.SetActive(false);
        // player.ControllerProfile = "CustomKeyboard";
    }
    public void ChangeCusXBOX()
    {
        CustomizeXBOX.SetActive(true);
        panel.SetActive(false);
        //player.ControllerProfile = "CustomXbox";
    }

    //for the customizing keyboard input
    public void ConfirmNewKeys()
    {
        //Keys_ML.text = keys[0].ToString();
        //Keys_MR.text = keys[1].ToString();
        //Keys_MF.text = keys[2].ToString();
        //Keys_MB.text = keys[3].ToString();
        //Keys_RL.text = keys[4].ToString();
        //Keys_RR.text = keys[5].ToString();
        //Keys_S.text = keys[6].ToString();

        //actually assigns each to a keycode
        //Keys_ML.text=player.Keys_left.ToString();
        //Debug.Log(Keys_ML.text);
        //Debug.Log(player.Keys_left.ToString());
        //Keys_MR.text = player.Keys_right.ToString();
        //Keys_MF.text = player.Keys_forward.ToString();
        //Keys_MB.text = player.Keys_backward.ToString();
        //Keys_RL.text = player.Keys_rotateLeft.ToString();
        //Keys_RR.text = player.Keys_rotateRight.ToString();
        //Keys_S.text = player.Keys_shoot.ToString();

    }
}
