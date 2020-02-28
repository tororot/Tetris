using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockManager : MonoBehaviour {

    static List<GameObject> blocks = new List<GameObject> (); //フィールド中のblockオブジェクト抽出
    static int[] rowy; //各列のy座標（全20列）
    static int[] checkrow = new int[20]; //各列に含まれるblockの個数（全20列）
    static List<float> deleteyset = new List<float> (); //block削除列のy座標リスト

    private void Start () {
        rowy = new int[20];
        //以下、Startメソッド内に記述
        for (int i = 0; i < checkrow.Length; i++) {
            rowy[i] = 1 + i * 1; //各列のブロックy座標定義
        }

        // { // Debug
        //     string log = "rowy " + rowy.Length + " [";
        //     for (int i = 0; i < rowy.Length; i++) {
        //         log += rowy[i] + ", ";
        //     }
        //     log += "]";
        //     Debug.Log (log);
        // }
    }

    public void completeDown () {
        checkLine ();
        //   deleteLine ();
    }

    public static void checkLine () {
        deleteyset.Clear (); //block削除列のy座標リストを調査前に初期化
        for (int i = 0; i < checkrow.Length; i++) {
            checkrow[i] = 0; //各列のblock個数を調査前に初期化
        }

        // { // Debug
        //     string log = "rowy " + rowy.Length + " [";
        //     for (int i = 0; i < rowy.Length; i++) {
        //         log += rowy[i] + ", ";
        //     }
        //     log += "]";
        //     Debug.Log (log);
        // }

        // 現状のフィールド中の全blockオブジェクトの位置調査
        blocks.Clear ();
        blocks.AddRange (GameObject.FindGameObjectsWithTag ("mino"));

        // { // Debug
        //     string log = "blocks " + blocks.Count + " ";
        //     foreach (GameObject block in blocks) {
        //         // blockx[i] = Mathf.RoundToInt (block.transform.position.x);
        //         // blocky[i] = Mathf.RoundToInt (block.transform.position.y);
        //         float blockx = block.transform.position.x;
        //         float blocky = block.transform.position.y;
        //         log += "[" + blockx + ", " + blocky + "] ";
        //     }
        //     Debug.Log (log);
        // }

        //各列のblock個数をカウント
        for (int i = 0; i < checkrow.Length; i++) {
            foreach (GameObject block in blocks) {
                //全blockをy座標ごとに分類し、各列に何個blockがあるかを調査
                int posy = Mathf.RoundToInt (block.transform.position.y);
                // Debug.Log ("rowy[" + i + "]=" + rowy[i] + " posy=" + posy);
                if (rowy[i] == posy) {
                    checkrow[i] = checkrow[i] + 1;
                }
            }
        }

        // { // Debug
        //     string log = "checkrow " + checkrow.Length + " [";
        //     for (int i = 0; i < checkrow.Length; i++) {
        //         log += checkrow[i] + ", ";
        //     }
        //     log += "]";
        //     Debug.Log (log);
        // }

        for (int i = 0; i < checkrow.Length; i++) {
            if (checkrow[i] == 10) {
                //列のブロック数が10個に到達していたら、以下のリストにその列のy座標を追加
                deleteyset.Add (rowy[i]);
            }
        }

        // { // Debug
        //     string log = "deleteyset " + deleteyset.Count + " [";
        //     for (int i = 0; i < deleteyset.Count; i++) {
        //         log += deleteyset[i] + ", ";
        //     }
        //     log += "]";
        //     Debug.Log (log);
        // }

        // block削除
        List<GameObject> removeBlocks = new List<GameObject> ();
        for (int i = 0; i < deleteyset.Count; i++) {
            foreach (GameObject block in blocks) {
                //削除リスト中のy座標とblockのy座標が一致したら削除
                int posy = Mathf.RoundToInt (block.transform.position.y);
                if (deleteyset[i] == posy) {
                    removeBlocks.Add (block);
                }
            }
        }
        foreach (GameObject block in removeBlocks) {
            blocks.Remove (block);
            Destroy (block);
        }

        // 
        int deleteNum = 0; // 削除した行数
        for (int i = 0; i < deleteyset.Count; i++) {
            float deletey = deleteyset[i];
            deletey -= deleteNum;
            foreach (GameObject block in blocks) {
                if (deletey < block.transform.position.y) {
                    block.transform.position -= new Vector3 (0, 1, 0);
                }
            }
            deleteNum++;
        }

    }
}