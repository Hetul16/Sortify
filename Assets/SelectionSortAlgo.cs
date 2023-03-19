using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSortAlgo : MonoBehaviour
{
    public int NumberOfCubes;
    public int CubeHeightMax;
    public GameObject[] Cubes;

    public Slider mySlider;
    public float SliderValue;
    public float speed=0.05f;

    // Start is called before the first frame update
    public void StartSort()
    {
        InitializeRandom();
        StartCoroutine(SelectionSort(Cubes));
    }

    public void Update(){
        // Debug.Log(speed);
        // mySlider.onValueChanged.AddListener(delegate{ValueChangeCheck();});
        // ValueChangeCheck();
        Debug.Log(speed);
    }

    public void ValueChangeCheck(){
        Debug.Log(mySlider.value);
        SliderValue=mySlider.value;
        speed=SliderValue;
    }


    IEnumerator SelectionSort(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;
        for(int i=0 ; i<unsortedList.Length;i++)
        {
            min = i;
            yield return new WaitForSeconds(speed);
            for(int j=i+1; j < unsortedList.Length ; j++)
            {
                if(unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {
                    min = j; 
                }
            }
            if(min != i)
            {
                yield return new WaitForSeconds(speed);
                temp= unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp ; 
                
                tempPosition = unsortedList[i].transform.localPosition;

                LeanTween.moveLocalX(unsortedList[i],unsortedList[min].transform.localPosition.x,speed);
                LeanTween.moveLocalZ(unsortedList[i],-3,speed).setLoopPingPong(1);
                LeanTween.moveLocalX(unsortedList[min],tempPosition.x,speed);
                LeanTween.moveLocalZ(unsortedList[min],9,speed).setLoopPingPong(1);
            }
            LeanTween.color(unsortedList[i], Color.green, speed);
        }
    }

    void InitializeRandom(){
        Cubes = new GameObject[NumberOfCubes];

        for(int i=0; i<NumberOfCubes; i++){
            int randomNumbers = Random.Range(1 , CubeHeightMax + 1);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            cube.transform.localScale = new Vector3(0.9f, randomNumbers, 1);
            cube.transform.position = new Vector3(i , randomNumbers / 2.0f, 4);

            cube.transform.parent = this.transform;
            Cubes[i]=cube;
        }
        transform.position=new Vector3(-NumberOfCubes/2f , -CubeHeightMax/2.0f ,0);
        }
    
}
