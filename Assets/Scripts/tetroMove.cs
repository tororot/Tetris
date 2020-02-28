using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetroMove : MonoBehaviour {

    public float span = 1.0f;
    public float delta = 0.0f;

    private KeyCode moveLeftKey    = KeyCode.LeftArrow;
    private KeyCode moveRightKey   = KeyCode.RightArrow;
    private KeyCode moveDownKey    = KeyCode.DownArrow;
    private KeyCode rotateRightKey = KeyCode.UpArrow;
    private KeyCode rotateLeftKey  = KeyCode.Z;

    public float downSpeed = 1.0f;

    void Update () {

        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0.0f;
            moveDownAuto ();
        }

        if (Input.GetKeyDown (moveRightKey))   moveRight ();
        if (Input.GetKeyDown (moveLeftKey))    moveLeft ();
        if (Input.GetKeyDown (moveDownKey))    moveDown ();
        if (Input.GetKeyDown (rotateRightKey)) rotateRight ();
        if (Input.GetKeyDown (rotateLeftKey))  rotateLeft ();

    }

    // 右移動
    public void moveRight () {
        transform.Translate (1.0f, 0, 0, Space.World);
    }
    // 左移動
    public void moveLeft () {
        transform.Translate (-1.0f, 0, 0, Space.World);
    }
    // 下移動
    public void moveDown () {
        transform.Translate (0, -1.0f, 0, Space.World);
    }
    // 右回転
    public void rotateRight () {
        transform.Rotate (0, 0, -90.0f);
    }
    // 左回転
    public void rotateLeft () {
        transform.Rotate (0, 0, 90.0f);
    }
    // 自動落下
    public void moveDownAuto () {
        transform.Translate (0, -downSpeed, 0, Space.World);
    }

}