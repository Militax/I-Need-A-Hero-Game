using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class Score : MonoBehaviour
{
    public GameObject[] Number;
    public Transform[] field;
    GameObject[] activeObj;
    public int scores;
    // Start is called before the first frame update
    void Start()
    {
        activeObj = new GameObject[field.Length];
        SetValue(scores);
    }
    public void SetValue(int scores)
    {
        int Convert = 1;
        for (int i = 0; i < field.Length; i++)
        {
            int scoreConvert = (scores / Convert) % 10;
            Print(i, scoreConvert, i);
            Convert *= 10;
        }
    }
    public void clear()
    {
        for (int i = 0; i < field.Length; i++)
        {
            if (activeObj[i])
                Destroy(activeObj[i]);


        }
    }
    void Print( int activeObj, int scores, int field)
    {
        this.activeObj[activeObj] = Instantiate(this.Number[scores], this.field[field].position, this.field[field].rotation);
        this.activeObj[activeObj].name = this.field[field].name;
        this.activeObj[activeObj].transform.SetParent(this.field[field]);
    }
    // Update is called once per frame
    
}
