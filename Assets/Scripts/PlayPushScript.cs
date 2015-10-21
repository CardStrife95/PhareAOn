using UnityEngine;
using System.Collections;

public class PlayPushScript : MonoBehaviour {

    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        // Determine the button's place on screen
        // Center in X, 2/3 of the height in Y
        Rect buttonRect = new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            );
        Rect quitRect = new Rect(
            Screen.width/2+2*(buttonWidth/2),
            (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            );

        // Draw a button to start the game
        if (GUI.Button(buttonRect, "Entrez!"))
        {
            // On Click, load the first level.
            // "Stage1" is the name of the first scene we created.
            Application.LoadLevel("level1");
        }
        if (GUI.Button(quitRect, "Quittez!"))
        {
            Application.Quit();
        }
    }
}
