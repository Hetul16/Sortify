using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeSortAlgo : MonoBehaviour
{

    public int NumberOfCubes;
    public int CubeHeightMax=10;
    public GameObject[] Cubes;

    GameObject temp;
    GameObject[] tempList;

    public GameObject[] text;
    
    // [SerializeField] private float speed;

    public Slider mySlider;
    public float SliderValue;
    public float speed=0.05f;

    // public TextMeshProUGUI;
    // Start is called before the first frame update
    public void StartSort()
    {
        IntializeRandom();
        StartCoroutine(MergeSort(Cubes , 0 , Cubes.Length - 1));
        
    }

    // public void SpeedFromSlider(float speed) => this.speed = speed;
    public void Update(){
        // Debug.Log(speed);
        // mySlider.onValueChanged.AddListener(delegate{ValueChangeCheck();});
        ValueChangeCheck();
    }

    public void ValueChangeCheck(){
        // Debug.Log(mySlider.value);
        SliderValue=mySlider.value;
        speed=SliderValue;
        // Debug.Log("Slider New Value");
        // Debug.Log(speed);
       
    }

    



    
    IEnumerator MergeSort(GameObject[] unsortedList, int low, int high)
    {
        if(low < high)
        {
            yield return new WaitForSeconds(speed);
            int mid = (low + high) / 2;

            LeanTween.color(unsortedList[mid], Color.red, 0.01f);
            yield return new WaitForSeconds(speed);
            LeanTween.color(unsortedList[mid], Color.white, 0.01f);
            

            yield return MergeSort(unsortedList, low, mid);
            yield return MergeSort(unsortedList, mid+1, high);

            yield return Merge(unsortedList, low, high, mid);
        }

    }

    IEnumerator Merge(GameObject[] unsortedList, int low, int high, int mid)
    {
        yield return new WaitForSeconds(speed);

        int leftIndex = low;
        int rightIndex = mid + 1;
        int mergeIndex = low;

        // Animation Part
        for (int i = low; i<= high; i++)
        {
            LeanTween.moveLocalZ(unsortedList[i], unsortedList[i].transform.localPosition.z + 1.5f, speed);
            LeanTween.color(unsortedList[i], Color.cyan, 0.01f);
        }
        //

        tempList = new GameObject[NumberOfCubes];

        while(leftIndex <= mid && rightIndex <= high)
        {
            yield return new WaitForSeconds(speed);

            if(unsortedList[leftIndex].transform.localScale.y < unsortedList[rightIndex].transform.localScale.y)
            {
                LeanTween.color(unsortedList[leftIndex], Color.yellow, 0.01f);

                tempList[mergeIndex] = unsortedList[leftIndex];
                leftIndex++;
                yield return new WaitForSeconds(speed);
                LeanTween.color(unsortedList[leftIndex-1], Color.white, 0.01f);
            }
            else
            {
                LeanTween.color(unsortedList[rightIndex], Color.yellow, 0.01f);

                tempList[mergeIndex] = unsortedList[rightIndex];
                rightIndex++;
                yield return new WaitForSeconds(speed);
                LeanTween.color(unsortedList[rightIndex-1], Color.white, 0.01f);
            }
            mergeIndex++;
        }

        while(leftIndex <= mid)
        {
            LeanTween.color(unsortedList[leftIndex], Color.yellow, 0.01f);
            yield return new WaitForSeconds(speed);
            LeanTween.color(unsortedList[leftIndex], Color.white, 0.01f);
            
            tempList[mergeIndex] = unsortedList[leftIndex];
            mergeIndex++;
            leftIndex++;
        }

        while(rightIndex <= high)
        {
            LeanTween.color(unsortedList[rightIndex], Color.yellow, 0.01f);
            yield return new WaitForSeconds(speed);
            LeanTween.color(unsortedList[rightIndex], Color.white, 0.01f);
            tempList[mergeIndex] = unsortedList[rightIndex];
            mergeIndex++;
            rightIndex++;
        }

        for (int i=low;i<mergeIndex;i++)
        {
            yield return new WaitForSeconds(speed);
            LeanTween.moveLocalX(tempList[i], i, speed);
            
            unsortedList[i] = tempList[i];
            
            LeanTween.moveLocalZ(unsortedList[i], 0f, speed);
            LeanTween.color(unsortedList[i], Color.white, speed);
        }
    }


    void IntializeRandom(){
        Cubes = new GameObject[NumberOfCubes];

        for(int i=0; i<NumberOfCubes; i++){
            int randomNumbers = Random.Range(1, CubeHeightMax + 1);
           Debug.Log(randomNumbers);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(0.9f, randomNumbers, 1);
            cube.transform.position = new Vector3(i , randomNumbers / 2.0f, 4);

            cube.transform.parent = this.transform;
            Cubes[i]=cube;
        }
        transform.position=new Vector3(-NumberOfCubes/2f , -CubeHeightMax/2.0f ,0);
        //Camera.main.transform.position = new Vector3(-NumberOfCubes / 2.0f, numberOfCubes / 2.0f + 1.5f, -numberOfCubes - 3);
    }

}