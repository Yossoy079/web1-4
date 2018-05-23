using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulatteController : MonoBehaviour {

    enum BOADSTATE
    {
        STOP,
        MOVE,
        BRAKE,
    }

    //外部変数
    float rotSpeed = 0;
    BOADSTATE roulatte_state = BOADSTATE.STOP;

    // Use this for initialization
    void Start () {
        
    }

    BOADSTATE UpdateStop(bool left_click) {
         if (left_click)
         {
             return BOADSTATE.MOVE;
         }
        
         return roulatte_state;
    }
    BOADSTATE UpdateMove(bool left_click) {
        if (left_click)
        {
            return BOADSTATE.BRAKE;
        }
        
        this.rotSpeed = 10;
        transform.Rotate(0, 0, this.rotSpeed);
        
        return roulatte_state;
    }
    BOADSTATE UpdateBreak(bool left_click) {
        this.rotSpeed *= 0.96f;
        if (rotSpeed < 0.01){
            this.rotSpeed = 0;
            return BOADSTATE.STOP;
        }
        transform.Rotate(0, 0, this.rotSpeed);
        return roulatte_state;
    }
    
    // Update is called once per frame
    void Update() {
        // 強制停止
        if (Input.GetMouseButtonDown(1))
        {
            roulatte_state = BOADSTATE.STOP;
        }
        
        BOADSTATE s;
        bool left_click = Input.GetMouseButtonDown(0);
UPDATE_STATE:
        switch (roulatte_state)
        {
            case BOADSTATE.STOP:
                s = UpdateStop(left_click);
                break;
            case BOADSTATE.MOVE:
                s = UpdateMove(left_click);
                break;
            case BOADSTATE.BRAKE:
                s = UpdateBreak(left_click);
                break;
            default:
                Debug.Log("ERROR:ルーレットの状態にエラーが出ました。");
                break;
        }
        
        // 状態が変わったら、次の状態の処理を一度回す
        if(s != roulatte_state){
            roulatte_state = s;
            left_click = false;
            goto UPDATE_STATE;
        }
    }
}
