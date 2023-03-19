using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class MergeSortMenu : MonoBehaviour
{

    public MergeSortAlgo MergeSort;
    public MergeSortAlgo ActiveSorter;
    public InputField InputNumberOfCubes;

    public void StartSort()
    {
        ActiveSorter = Instantiate(MergeSort);
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
