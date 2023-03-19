using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BubbleSortMenu : MonoBehaviour
{

    public BubbleSortAlgo BubbleSort;
    public BubbleSortAlgo ActiveSorter;
    public InputField InputNumberOfCubes;

    public void StartSort()
    {
        ActiveSorter = Instantiate(BubbleSort);
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
