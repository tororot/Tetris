using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetroManager : MonoBehaviour {

    public GameObject blockManager_;
    private blockManager blockManagerScript_;
    public GameObject blockFactory;

    public List<GameObject> allBlocks_ = new List<GameObject> ();

    void Awake () {
    }

    void Start () {
        blockManagerScript_ = blockManager_.GetComponent<blockManager> ();

        // GameObject[] blocks_ = GameObject.FindGameObjectsWithTag ("mino");
        // GameObject[] floors_ = GameObject.FindGameObjectsWithTag ("floor");

        //新しい配列を作る
        // allBlocks_ = new GameObject[blocks_.Length + floors_.Length];
        allBlocks_.Clear ();
        allBlocks_.AddRange (GameObject.FindGameObjectsWithTag ("mino"));
        allBlocks_.AddRange (GameObject.FindGameObjectsWithTag ("floor"));
        //マージする配列のデータをコピーする
        // blocks_.CopyTo (allBlocks_, 0);
        // floors_.CopyTo (allBlocks_, blocks_.Length);

        // { // Debug
        //     string log = "tetromino ";
        //     foreach (Transform block in transform) {
        //         // blockx[i] = Mathf.RoundToInt (block.transform.position.x);
        //         // blocky[i] = Mathf.RoundToInt (block.transform.position.y);
        //         float blockx = block.transform.position.x;
        //         float blocky = block.transform.position.y;
        //         log += "[" + blockx + ", " + blocky + "] ";
        //     }
        //     Debug.Log (log);
        // }
    }

    void Update () {
        allBlocks_.Clear ();
        allBlocks_.AddRange (GameObject.FindGameObjectsWithTag ("mino"));
        allBlocks_.AddRange (GameObject.FindGameObjectsWithTag ("floor"));
        if (isOnBlock ()) { //落下終了判定条件（nowx、nowyは前回定義済）
            foreach (Transform child in transform) {
                child.gameObject.tag = "mino";
            }
            gameObject.transform.DetachChildren (); //親子関係の解除
            Destroy (gameObject); //セットオブジェクト（親）を削除
            blockManagerScript_.completeDown ();
        blockFactory.GetComponent<tetroFactory> ().createBlock ();
            return;
        }
    }

    private bool isOnBlock () {
        // GameObject[] blocks_ = GameObject.FindGameObjectsWithTag ("mino");
        // GameObject[] floors_ = GameObject.FindGameObjectsWithTag ("floor");

        // //新しい配列を作る
        // allBlocks_ = new GameObject[blocks_.Length + floors_.Length];
        if (allBlocks_.Count != 0) {
            foreach (GameObject block in allBlocks_) {
                foreach (Transform child in transform) {
                    Vector3 blockPos = block.transform.position + new Vector3 (0, 1, 0);
                    Vector3 childPos = child.position;
                    if (blockPos == childPos) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void OnDestroy() {
    }

}