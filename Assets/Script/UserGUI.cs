using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    GUIStyle style;
    FirstSceneControl sceneControl;
    // Use this for initialization  
    void Start()
    {
        action = Director.getInstance().currentSceneControl as IUserAction;
        style = new GUIStyle();
        style.fontSize = 25;
        sceneControl = (FirstSceneControl) Director.getInstance().currentSceneControl;
    }

    private void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width/2, 100, 400, 400), "Round:" +  (FirstSceneControl.r+1).ToString(),style);
        /*if (Input.GetButtonDown("Fire1"))
        {

            Vector3 pos = Input.mousePosition;
            action.hit(pos);

        }*/

        GUIStyle fontstyle1 = new GUIStyle();
        fontstyle1.fontSize = 50;
        fontstyle1.normal.textColor = new Color(255, 255, 255);
        if (GUI.RepeatButton(new Rect(0, 0, 120, 40), "Shooting Disk"))
        {
            action.ShowDetail();
        }
        if (GUI.Button(new Rect(0, 60, 120, 40), "STARTGAME"))
        {
            action.StartGame();
        }
        if (GUI.Button(new Rect(0, 120, 120, 40), "RESTART"))
        {
            action.ReStart();
        }
        GUI.Label(new Rect(Screen.width - 200 , 50 , 200, 200), "Score:" + sceneControl.scoreRecorder.score.ToString(), fontstyle1);
        if (Input.GetMouseButtonDown(0))
        {
            action.hit();
        }
    }
}