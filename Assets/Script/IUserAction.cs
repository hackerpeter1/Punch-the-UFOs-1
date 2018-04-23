/** 
 * UI界面与场景管理器通信的接口 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { ROUND_START, ROUND_FINISH, RUNNING, PAUSE, START }

public interface IUserAction
{
    void GameOver();
    void StartGame();
    void ReStart();
    //GameState getGameState();
    //void setGameState(GameState gs);
    //int GetScore();
    void ShowDetail();
    void hit();
}