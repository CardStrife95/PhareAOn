using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public int lifePoint = 100;
    public int mana = 100;

    void OnGUI()
    {
        // Make a background box
        GUI.Label(new Rect(5, 5, 100, 30), "Point de vie");
        GUI.Box(new Rect(0, Screen.height - 80, 100, 90), "Menu");
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Item");
      //  GUI.Box(new Rect(0, Screen.height - 50, 100, 50), "Bottom-left");
        GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-right");
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(10, Screen.height - 50, 80, 30), "Retour du menu"))
        {
            Application.LoadLevel("menu");
        }

        // Make the second button.
        if (GUI.Button(new Rect(10, Screen.height - 20, 80, 30), "About"))
        {
            Application.LoadLevel("loading");
        }


    }
}
