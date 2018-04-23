using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emit : SSAction {
    public FirstSceneControl sceneControl = (FirstSceneControl) Director.getInstance().currentSceneControl; //引入场记 
    bool enableEmit = true;//使力作用一次的judge，不想产生变加速运动  
    Vector3 force;//力  
    float startX;//起始位置
    
    public override void Start()
    {
        startX = 6 - Random.value * 12; //随机设置初始位置
        this.transform.position = new Vector3(startX, 0, 0); //
        force = new Vector3(6 * Random.Range(-1, 1), 6 * Random.Range(0.5f, 2), 13 + 2 * sceneControl.round);//根据轮数设置力的大小  
    }

    public override void Update()
    {
        //  
    }

    public void Destory()//销毁  
    {
        this.destroy = true;
        this.callback.SSActionEvent(this); //回调函数通知
    }

    public static Emit GetSSAction() //获取一个action实例
    {
        Emit action = ScriptableObject.CreateInstance<Emit>();
        return action;
    }

    // Update is called once per frame  
    public override void FixedUpdate()
    {
        if (!this.destroy)
        {
            if (enableEmit)
            {
                gameobject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameobject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                enableEmit = false;
            }
        }
    }
}
