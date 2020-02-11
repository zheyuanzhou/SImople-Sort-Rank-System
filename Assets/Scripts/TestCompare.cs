using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCompare : MonoBehaviour
{
    public List<int> numbers;

    private void Start()
    {
        numbers = new List<int>() { 20, 10, 30, 70, 60, 40, 50, 90, 80, 100 };

        //Debug.Log("Answer: " + CompareInt(99, 100));//-1 left is smaller
        //Debug.Log("Answer: " + CompareInt(299, 100));//1 left is greater
        //Debug.Log("Answer: " + CompareInt(9, 1));//1 left is greater
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SortByCompare();
        }
    }

    private void SortByCompare()
    {
        //numbers.Sort(CompareInt);
        numbers.Sort((a, b) => a.CompareTo(b));//MARKER LAMBDA Express/statement
        //If we want to compare two objects
        //numbers.Sort((obj1, obj2) => obj1.var.CompareTo(obj2.var));//Compare two objects' properties
        Debug.Log("CompareInt LAMBDA");
    }

    //OPTIONAL 
    private int CompareInt(int _a, int _b)
    {
        //RETURN Greater one between A and B
        return _a.CompareTo(_b);//Return -1, 1, 0 MARKER (1: _a is greater, -1: _a is smaller)
    }



}
