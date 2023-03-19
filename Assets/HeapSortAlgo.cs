using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeapSortAlgo : MonoBehaviour
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
        StartCoroutine(HeapSort(Cubes));
        
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

    IEnumerator HeapSort(GameObject[] unsortedList)
    {
        int n = unsortedList.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
        {
            yield return BuildHeap(unsortedList, n, i);
        }

        for(int i=n-1; i>=0; i--)
        {
            yield return new WaitForSeconds(speed);
            temp = unsortedList[0];
            int tempX = (int)unsortedList[0].transform.localPosition.x;

            LeanTween.color(unsortedList[0], Color.cyan, 0.01f);
            LeanTween.moveLocalX(unsortedList[0], unsortedList[i].transform.localPosition.x, speed);
            LeanTween.moveLocalZ(unsortedList[0], -1.5f, speed).setLoopPingPong(1);
            unsortedList[0] = unsortedList[i];

            LeanTween.color(unsortedList[i], Color.white, 0.01f);
            LeanTween.moveLocalX(unsortedList[i], tempX, speed);
            LeanTween.moveLocalZ(unsortedList[i], 1.5f, speed).setLoopPingPong(1);
            unsortedList[i] = temp;

            yield return BuildHeap(unsortedList, i, 0);
        }

    }   

    IEnumerator BuildHeap(GameObject[] unsortedList, int n, int i)
    {
        int largest = i;
        int l = i * 2 + 1;
        int r = i * 2 + 2;

        LeanTween.color(unsortedList[largest], Color.red, 0.01f);

        yield return new WaitForSeconds(speed);
        if(l < n && unsortedList[l].transform.localScale.y > unsortedList[largest].transform.localScale.y)
        {
            largest = l;
            LeanTween.color(unsortedList[largest], Color.yellow, 0.01f);
        }

        if (r < n && unsortedList[r].transform.localScale.y > unsortedList[largest].transform.localScale.y)
        {
            largest = r;
            LeanTween.color(unsortedList[largest], Color.yellow, 0.01f);
        }

        if(largest != i)
        {
            yield return new WaitForSeconds(speed);
            // Swap
            temp = unsortedList[i];
            int tempX = (int)unsortedList[i].transform.localPosition.x;

            LeanTween.moveLocalX(unsortedList[i], unsortedList[largest].transform.localPosition.x, speed);
            LeanTween.moveLocalZ(unsortedList[i], -1.5f, speed).setLoopPingPong(1);
            unsortedList[i] = unsortedList[largest];

            LeanTween.moveLocalX(unsortedList[largest], tempX, speed);
            LeanTween.moveLocalZ(unsortedList[largest], 1.5f, speed).setLoopPingPong(1);
            unsortedList[largest] = temp;

            LeanTween.color(unsortedList[i], Color.white, 0.01f);
            LeanTween.color(unsortedList[largest], Color.white, 0.01f);
            yield return BuildHeap(unsortedList, n, largest);
        }

        LeanTween.color(unsortedList[largest], Color.white, 0.01f);
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