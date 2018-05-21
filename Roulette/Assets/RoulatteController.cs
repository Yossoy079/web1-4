using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulatteController : MonoBehaviour {

    float rotSpeed = 0;
    BOADSTATE roulatte_state = BOADSTATE.STOP;
    enum BOADSTATE
    {
        STOP,
        MOVE,
        BRAKE,
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {
        bool click = false;
        if (Input.GetMouseButtonDown(0) && click == false)
        {
            if (roulatte_state == BOADSTATE.BRAKE)
            {
                roulatte_state = BOADSTATE.STOP;
            }
            else
            {
                roulatte_state++;
            }
            click = true;
        }
        else
        {
            click = false;
        }


        switch (roulatte_state)
        {
            case BOADSTATE.STOP:
                this.rotSpeed = 0;
                break;
            case BOADSTATE.MOVE:
                this.rotSpeed = 10;
                break;
            case BOADSTATE.BRAKE:
                this.rotSpeed *= 0.98f;
                break;
            default:
                this.rotSpeed = 0;
                Debug.Log("ERROR:ルーレットの状態にエラーが出ました。");
                break;
        }

        transform.Rotate(0, 0, this.rotSpeed);
    }
}
