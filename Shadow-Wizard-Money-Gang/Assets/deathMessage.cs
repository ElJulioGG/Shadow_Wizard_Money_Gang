using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class deathMessage : MonoBehaviour
{
    [SerializeField] private string DeathMesage;
    [SerializeField] private Text DeathText;

    private void OnEnable()
    {
        System.Random random = new System.Random();
        int randomInt = random.Next(0, 24);
        switch (randomInt)
        {
            case 0:
                DeathMesage = "Git Gud";
                break;
            case 1:
                DeathMesage = "Pro Tip: Don't Die";
                break;
            case 2:
                DeathMesage = "Just don't get hit";
                break;
            case 3:
                DeathMesage = "Bruvh";
                break;
            case 4:
                DeathMesage = "Dayum";
                break;
            case 5:
                DeathMesage = "Saludos de Peru";
                break;
            case 6:
                DeathMesage = "This game is sponsored by The Gungeon of Touhow";
                break;
            case 7:
                DeathMesage = "An isue of skill :p";
                break;
            case 8:
                DeathMesage = "Whomp Whomp";
                break;
            case 9:
                DeathMesage = "Absolutely demolished";
                break;
            case 10:
                DeathMesage = "T_T";
                break;
            case 11:
                DeathMesage = "Am I cooked chat?";
                break;
            case 12:
                DeathMesage = "So close yet so far";
                break;
            case 13:
                DeathMesage = "Try a little harder next time";
                break;
            case 14:
                DeathMesage = "Janky synergy I know";
                break;
            case 15:
                DeathMesage = "Chill out and drink some chicha morada";
                break;
            case 16:
                DeathMesage = "2 h4rd 4 U m8?";
                break;
            case 17:
                DeathMesage = "Can we get an F in the chat";
                break;
            case 18:
                DeathMesage = "You fell off";
                break;
            case 19:
                DeathMesage = "Welp, back to the begining";
                break;
            case 20:
                DeathMesage = "I hope you didn't die to far in";
                break;
            case 21:
                DeathMesage = "404: Player.Health not found";
                break;
            case 22:
                DeathMesage = "Get dunked on";
                break;
        }
        DeathText.text = DeathMesage;
    }
}
