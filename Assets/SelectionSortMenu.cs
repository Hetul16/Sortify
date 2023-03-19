using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelectionSortMenu : MonoBehaviour
{
    public SelectionSortAlgo SelectionSort;
    public SelectionSortAlgo ActiveSorter;
    public InputField InputNumberOfCubes;
    public void StartSort()
    {
        ActiveSorter = Instantiate(SelectionSort);
        //InputNumberOfCubes = GameObject.Find("InputNumberOfCubes").GetComponent<InputField>();
        ActiveSorter.NumberOfCubes = Convert.ToInt32(InputNumberOfCubes.text);
        Debug.Log(Convert.ToInt32(InputNumberOfCubes.text));
        ActiveSorter.StartSort();
    }

    public void Reset()
    {
        Destroy(ActiveSorter.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}