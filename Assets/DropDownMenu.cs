using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown Algo;
    public BubbleSortMenu A;
    public SelectionSortMenu B;
    public InsertionSortMenu C;
    public MergeSortMenu D;
    public QuickSortMenu E;
    public HeapSortMenu F;
    
    // public void Start(){
    //     opt = GetComponent<Dropdown>();
    //     opt.onValueChanged.AddListener(delegate{
    //         SelectAlgo(opt);
    //     });
    // }

    public void SelectAlgo()
    {
        // opt = GetComponent<Dropdown>().Value;
        Debug.Log(Algo.value);
        if(Algo.value==0){
            // this.GetComponent<DropDownMenu>().Value
            A.StartSort();
        }
        if(Algo.value==1){
            B.StartSort();
        }
        if(Algo.value==2){
            C.StartSort();
        }
        if(Algo.value==3){
            D.StartSort();
        }
        if(Algo.value==4){
            E.StartSort();
        }
        if(Algo.value==5){
            F.StartSort();
        }

    }

    // Update is called once per frame
   
}
