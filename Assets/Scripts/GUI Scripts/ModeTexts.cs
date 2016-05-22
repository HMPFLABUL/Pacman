using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModeTexts : MonoBehaviour {

    public static Text modeName;
    public static Text modeDescription;


    void Awake()
    {
        
        modeName = GameObject.Find("Mode:").GetComponent<Text>();
        modeDescription = GameObject.Find("description").GetComponent<Text>();
    }
   

    public static void ChangeText()
    {
        switch (ModeMenager.modeState)
        {
            case ModeMenager.ModeState.Norm:
                {
                    modeName.text = "MODE: NORMAL";
                    modeDescription.text = "Casual Day, Casual Mode";
                    break;
                }
            case ModeMenager.ModeState.Close:
                {
                    modeName.text = "MODE: Egoistic";
                    modeDescription.text = "Look at that beautiful bastard!";
                    break;
                }
            case ModeMenager.ModeState.Blind:
                {
                    modeName.text = "MODE: Late Night";
                    modeDescription.text = "I did nothing today #Regret";
                    break;
                }
            case ModeMenager.ModeState.Reverse:
                {
                    modeName.text = "MODE: Confuse";
                    modeDescription.text = "Where should I start from?";
                    break;
                }
            case ModeMenager.ModeState.Rotate:
                {
                    modeName.text = "MODE: Headache";
                    modeDescription.text = "Ouch... its to much for me to take";
                    break;
                }
            case ModeMenager.ModeState.Speedo:
                {
                    modeName.text = "MODE: Responsibilities Overload";
                    modeDescription.text = "To ... Much ... Stuff ... To Do";
                    break;
                }
            default:
                break;

        }
    
    }

}
