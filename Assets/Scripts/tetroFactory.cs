using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetroFactory : MonoBehaviour {
    public GameObject tetromino_I;
    public GameObject tetromino_J;
    public GameObject tetromino_L;
    public GameObject tetromino_O;
    public GameObject tetromino_S;
    public GameObject tetromino_T;
    public GameObject tetromino_Z;

    private void Start () {
        createBlock ();
    }

    public void createBlock () {
        float rand = Random.Range (0.0f, 7.0f);
        GameObject newTetro = null;
        if (rand < 1.0f) newTetro = tetromino_I;
        else if (rand < 2.0f) newTetro = tetromino_J;
        else if (rand < 3.0f) newTetro = tetromino_L;
        else if (rand < 4.0f) newTetro = tetromino_O;
        else if (rand < 5.0f) newTetro = tetromino_S;
        else if (rand < 6.0f) newTetro = tetromino_T;
        else if (rand <= 7.0f) newTetro = tetromino_Z;

        Vector3 pos = new Vector3 (0.0f, 20.0f, 0.0f);
        Instantiate (newTetro, pos, Quaternion.identity);
    }
}