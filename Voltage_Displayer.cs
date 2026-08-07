using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
//using Mono.Cecil.Cil; // If using TextMeshPro
using System;
using CreativeSpore;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Voltage_Displayer : MonoBehaviour
{
    public Transform circle1;
    public Transform circle2;
    public Transform circle3;
    public Transform circle4;

    public TextMeshProUGUI sumText;
    public TextMeshProUGUI goalText;

    public SceneSelector SceneChanger;

    public SavePlaceValueState whatMachine; //This saves the overall state of what machine a player was on so that when they leave
                                            //to go to the instructions, they come back to the same spot.

    /* Note: Variables to save Progress in SavePlaceValueState.cs
    int whatKind;      "whatKind" of power the machine needs changes as you progress. Thus "whatKind" measures what machine you are on (up to machine #8).
    int targetVal = 1; "targetVal" of power the current machine needs.
    */

    int Power;


    public void addWhatKind()
    {
        Debug.Log("Result Text Value is: " + sumText.text.Split(' ')[1]);
        Debug.Log("Expected Text Value is: " + goalText.text.Split(' ')[4]);

        if (Convert.ToInt32(sumText.text.Split(' ')[1]) == Convert.ToInt32(goalText.text.Split(' ')[4]))
        {
            whatMachine.whatKind++;
            generateTarget();
        }
    }

    void generateTarget()
    {
        System.Random randomGen = new System.Random();
        // For machines 1 and 2, pick machine power between 1 and 10.
        // For machines 3-5, increase the difficulty by picking machine power between 100 and 1001.
        // For machines 6-8, increase the difficulty by picking machine power between 1000 and 1201.
        switch(whatMachine.whatKind)
        {
            case <= 2:
                whatMachine.targetVal = randomGen.Next(1, 10);
                break;
            case <= 5:
                whatMachine.targetVal = randomGen.Next(100, 1001);
                break;
            case <= 8:
                whatMachine.targetVal = randomGen.Next(1000, 1201);
                break;
        }
    }

    public void gameDone()
    {
        if (whatMachine.whatKind > 8)
        {
            whatMachine.whatKind = 1; //Reset whatKind for Number Generator
            whatMachine.targetVal = 1; //Reset targetVal for Game
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            Debug.LogWarning("Nubmber of scenes in build settings is: " + sceneCount);
            SceneManager.LoadScene(16); //Go to Home/World Screen! Game is Complete!
        }
    }

    //The difference between this function and the one above will be that this one will not add to an overall successful "completion" score.
    public void Reset()
    {
        whatMachine.whatKind = 1; //Reset whatKind for Number Generator
        whatMachine.targetVal = 1; //Reset targetVal for Game
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        Debug.LogWarning("Nubmber of scenes in build settings is: " + sceneCount);
        SceneManager.LoadScene(12); //Go to Home/World Screen! Game is Complete!
    }


    void Update()
    {
        if (circle1 != null && circle2 != null && circle3 != null && circle4 != null && sumText != null)
        {
            
            int Thousands;
            int Hundreds;
            int Tens;
            int Ones;

            // Adding to Watts Based on Circle-Knob for Position of Thousands Place
            switch(circle1.position.y)
            {
                case < 2.4f:
                    Thousands = 0;
                    break;
                case > 2.4f:
                    Thousands = 1000;
                    break;
                default:
                    Thousands = 0;
                    break;
            }

            // Adding to Watts Based on Circle-Knob for Position of Hundreds Place
            switch(circle2.position.y)
            {
                case < -0.3f:
                    Hundreds = 0;
                    break;
                case < 0f:
                    Hundreds = 100;
                    break;
                case < .5f:
                    Hundreds = 200;
                    break;
                case < 1.0f:
                    Hundreds = 300;
                    break;
                case < 1.5f:
                    Hundreds = 400;
                    break;
                case < 2.4f:
                    Hundreds = 500;
                    break;
                case < 2.9f:
                    Hundreds = 600;
                    break;
                case < 3.5f:
                    Hundreds = 700;
                    break;
                case < 3.92f:
                    Hundreds = 800;
                    break;
                case <= 4.45f:
                    Hundreds = 900;
                    break;
                default:
                    Hundreds = 0;
                    break;
            }

            // Adding to Watts Based on Circle-Knob for Position of Tens Place
            switch(circle3.position.y)
            {
                case < -0.3f:
                    Tens = 0;
                    break;
                case < 0f:
                    Tens = 10;
                    break;
                case < .25f:
                    Tens = 20;
                    break;
                case < 1.0f:
                    Tens = 30;
                    break;
                case < 1.5f:
                    Tens = 40;
                    break;
                case < 2.4f:
                    Tens = 50;
                    break;
                case < 2.9f:
                    Tens = 60;
                    break;
                case < 3.5f:
                    Tens = 70;
                    break;
                case < 3.92f:
                    Tens = 80;
                    break;
                case <= 4.45f:
                    Tens = 90;
                    break;
                default:
                    Tens = 0;
                    break;
            }

            // Adding to Watts Based on Circle-Knob for Position of Ones Place
            switch(circle4.position.y)
            {
                case < -0.3f:
                    Ones = 0;
                    break;
                case < 0f:
                    Ones = 1;
                    break;
                case < .25f:
                    Ones = 2;
                    break;
                case < 1.0f:
                    Ones = 3;
                    break;
                case < 1.5f:
                    Ones = 4;
                    break;
                case < 2.4f:
                    Ones = 5;
                    break;
                case < 2.9f:
                    Ones = 6;
                    break;
                case < 3.5f:
                    Ones = 7;
                    break;
                case < 3.92f:
                    Ones = 8;
                    break;
                case <= 4.45f:
                    Ones = 9;
                    break;
                default:
                    Ones = 0;
                    break;
            }
            
            Power = Thousands + Hundreds + Tens + Ones;
            sumText.text = $"Power: {Power} Watts";
            goalText.text = $"Machine #{whatMachine.whatKind} Needs Power: {whatMachine.targetVal} Watts";

        }
    }

}
