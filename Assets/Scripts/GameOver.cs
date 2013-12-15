using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public GUIText[] text;
    private bool active = false;

    public void activate()
    {
        foreach (var t in text)
        {
            t.enabled = true;
        }

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var e in enemies)
        {
            Destroy(e);
        }

        active = true;
    }

    void OnGUI()
    {
        if (!active) return;
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        // Draw a button to start the game
        if (
          GUI.Button(
            // Center in X, 2/3 of the height in Y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Replay"
          )
        )
        {
            // On Click, load the first level.
            // "Stage1" is the name of the first scene we created.
            Application.LoadLevel("Level1");
        }
    }
}
