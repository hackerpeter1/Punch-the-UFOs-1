using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : SSActionManager, ISSActionCallback, IActionManager
{
    public FirstSceneControl sceneController;//场记  
    public DiskFactory diskFactory;//游戏工厂  
    public ScoreRecorder scoreRecorder;//记分员  
    public Emit EmitDisk;
    public GameObject Disk;
    int count = 0;
    // Use this for initialization  
    protected void Start()
    {
        sceneController = (FirstSceneControl)Director.getInstance().currentSceneControl;
        diskFactory = sceneController.GetComponent<DiskFactory>();
        scoreRecorder = sceneController.scoreRecorder;
        sceneController.actionManager = this;//设置动作管理器  
    }

    // Update is called once per frame  
    protected new void Update()
    {
        if (sceneController.round <= 3 && sceneController.game == 1)//游戏总轮数为3轮  
        {
            count++;
            if (count == 60)
            {
                playDisk();
                sceneController.num++;
                //print(sceneController.num);  
                count = 0;
            }
            base.Update();
        }
    }

    public void playDisk()
    {
        EmitDisk = Emit.GetSSAction();
        Disk = sceneController.GetComponent<DiskFactory>().GetDisk(sceneController.round);
        this.RunAction(Disk, EmitDisk, this);
        Disk.GetComponent<DiskData>().action = EmitDisk;
    }

    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0, string strParam = null, Object objectParam = null)              //回调函数回收飞碟记录是否失分  
    {
        //if (!source.gameobject.GetComponent<DiskData>().hit)
            //scoreRecorder.miss();
        diskFactory.FreeDisk(source.gameobject);
        source.gameobject.GetComponent<DiskData>().hit = false;
    }
}