/**
 * 这个文件是用来控制主游戏场景的
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstSceneControl : MonoBehaviour, ISceneControl, IUserAction
{
    public IActionManager actionManager { get; set; }//动作管理器  
    public ScoreRecorder scoreRecorder { get; set; }//游戏记分员  
    public int round = 0;//轮数  
    public Text RoundText;//轮数文本  
    public Text GameText;//倒计时文本  
    public Text FinalText;//结束文本  
    public int game = 0;//记录游戏进行情况  
    public int num = 0;//每轮的飞碟数量  
    GameObject explosion;//爆炸效果  
    public int CoolTimes = 3; //准备时间  
    // Use this for initialization  
    void Awake()
    //创建导演实例并载入资源  
    {
        Director director = Director.getInstance();
        director.currentSceneControl = this;
        director.currentSceneControl.LoadResources();
        round = 1;//开始游戏设置为第一轮  
        //factory = new DiskFactory();
        this.gameObject.AddComponent<DiskFactory>();
        this.gameObject.AddComponent<ScoreRecorder>();
    }
    void Start()
    {
        scoreRecorder = this.GetComponent<ScoreRecorder>();
    }

    // Update is called once per frame  
    void Update()
    {
        //RoundText.text = "Round:" + round.ToString();//将轮数信息打印出来  
        if (game == 2)
        {
            GameOver();//判断游戏结束  
        }
    }
    public IEnumerator waitForOneSecond()  //协程技术实现倒计时3秒  
    {
        while (CoolTimes >= 0 && game == 3)
        {
            //GameText.text = CoolTimes.ToString();  //将倒计时剩余时间打印在屏幕上  
            print("还剩" + CoolTimes);
            yield return new WaitForSeconds(1);//等待一秒  
            CoolTimes--;
        }
        //GameText.text = "";
        game = 1;  //标记游戏开始  
    }
    public void GameOver()
    {
        FinalText.text = "Game Over!!!";//游戏结束显示  
    }
    public void StartGame()  //实现IUserAction接口开始游戏  
    {
        num = 0;
        if (game == 0)
        {
            game = 3;  //进入倒计时模式  
            StartCoroutine(waitForOneSecond());  //启动协程  
        }
    }
    public void ReStart()  //实现IUserAction接口重启游戏  
    {
        SceneManager.LoadScene("Scene");
        game = 0;
    }
    public void ShowDetail()  //实现IUserAction接口显示游戏介绍  
    {
        GUI.Label(new Rect(220, 50, 350, 250), "Use your mouse click disk, you will get 1 point for green Disk，2 for yellow Disk，3 for red Disk,you should get 20 points to pass round1,40 to pass round2,60 to pass round3.There are three round.Good Luck!!!");
    }
    public void hit()  //实现IUserAction接口判断击中事件  
    {
        if (game == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Disk")
                {
                    //explosion.transform.position = hit.collider.gameObject.transform.position;
                    //explosion.GetComponent<Renderer>().material = hit.collider.gameObject.GetComponent<Renderer>().material;
                    //explosion.GetComponent<ParticleSystem>().Play();
                    //print(hit.collider.gameObject.GetComponent<DiskData>().color);
                    //print(Color.blue);
                    hit.collider.gameObject.SetActive(false);
                    //print("Hit!!!");
                    hit.collider.gameObject.GetComponent<DiskData>().hit = true;
                    this.gameObject.GetComponent<ScoreRecorder>().Record(hit.collider.gameObject);
                    //scoreRecorder.Record(hit.collider.gameObject);
                }
            }
        }
    }
    public void LoadResources()  //载入资源  
    {
        //explosion = Instantiate(Resources.Load("prefabs/Explosion"), new Vector3(-40, 0, 0), Quaternion.identity) as GameObject;
        //Instantiate(Resources.Load("prefabs/Light"));
    }
}