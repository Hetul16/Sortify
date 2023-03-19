using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class QuickSortMenu : MonoBehaviour
{

    public QuickSortAlgo QuickSort;
    public QuickSortAlgo ActiveSorter;
    public InputField InputNumberOfCubes;

    public void StartSort()
    {
        ActiveSorter = Instantiate(QuickSort);
        //InputNumberOfCubes = GameObject.Find("InputNumberOfCubes").GetComponent<InputField>();
        ActiveSorter.NumberOfCubes = Convert.ToInt32(InputNumberOfCubes.text);
        Debug.Log(Convert.ToInt32(InputNumberOfCubes.text));
        ActiveSorter.StartSort();
    }

    public void Reset()
    {
        Destroy(ActiveSorter.gameObject);
    }
    // Start is called before the first frame update
}
