using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulatteController : MonoBehaviour {

    enum BOADSTATE
    {
        MOVE,
        BRAKE,
        STOP,
    }

    //外部変数
    float rotSpeed = 0;
    BOADSTATE roulatte_state = BOADSTATE.STOP;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (roulatte_state == BOADSTATE.STOP)
            {
                roulatte_state = BOADSTATE.MOVE;
            }
            else
            {
                roulatte_state++;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            roulatte_state = BOADSTATE.STOP;
        }


        switch (roulatte_state)
        {
            case BOADSTATE.MOVE:
                this.rotSpeed = 10;
                break;
            case BOADSTATE.BRAKE:
                this.rotSpeed *= 0.96f;
                if (rotSpeed < 0.01) roulatte_state = BOADSTATE.STOP;
                break;
            case BOADSTATE.STOP:
                this.rotSpeed = 0;
                break;
            default:
                this.rotSpeed = 0;
                Debug.Log("ERROR:ルーレットの状態にエラーが出ました。");
                break;
        }

        transform.Rotate(0, 0, this.rotSpeed);
    }
}
