using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSortAlgo : MonoBehaviour
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
        StartCoroutine(QuickSort(Cubes , 0 , Cubes.Length - 1));
        
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

    



    
IEnumerator QuickSort(GameObject[] unsortedList, int left, int right)
    {
        if (left < right)
        {
            // Partiction Begin !!!!!
            int pivot = (int)unsortedList[right].transform.localScale.y;
            LeanTween.color(unsortedList[right], Color.red, 0.01f);

            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                yield return new WaitForSeconds(speed);
                LeanTween.color(unsortedList[j], Color.blue, 0.01f);

                if (unsortedList[j].transform.localScale.y < pivot)
                {
                    yield return new WaitForSeconds(speed);
                    i++;
                    LeanTween.color(unsortedList[i], Color.yellow, 0.01f);

                    yield return new WaitForSeconds(speed);
                    // Swap
                    temp = unsortedList[i];
                    Vector3 tempPosition = unsortedList[i].transform.localPosition;

                    LeanTween.moveLocalX(unsortedList[i], unsortedList[j].transform.localPosition.x, speed);
                    LeanTween.moveZ(unsortedList[i], -1.5f, speed).setLoopPingPong(1);
                    unsortedList[i] = unsortedList[j];

                    LeanTween.moveLocalX(unsortedList[j], tempPosition.x, speed);
                    LeanTween.moveZ(unsortedList[j], 1.5f, speed).setLoopPingPong(1);
                    unsortedList[j] = temp;

                    yield return new WaitForSeconds(speed * 1.5f);
                    LeanTween.color(unsortedList[i], Color.white, 0.01f);
                }
                yield return new WaitForSeconds(speed);
                LeanTween.color(unsortedList[j], Color.white, 0.01f);
            }

            yield return new WaitForSeconds(speed * 1.5f);
            // Swap Again
            temp = unsortedList[i + 1];
            Vector3 tP = unsortedList[i + 1].transform.localPosition;

            LeanTween.moveLocalX(unsortedList[i + 1], unsortedList[right].transform.localPosition.x, speed);
            LeanTween.moveZ(unsortedList[i + 1], -1.5f, speed).setLoopPingPong(1);
            unsortedList[i + 1] = unsortedList[right];

            LeanTween.moveLocalX(unsortedList[right], tP.x, speed);
            LeanTween.moveZ(unsortedList[right], 1.5f, speed).setLoopPingPong(1);
            unsortedList[right] = temp;

            LeanTween.color(unsortedList[i+1], Color.white, 0.01f);
            yield return new WaitForSeconds(speed  * 1.5f);

            // Partiction End !!!

            int p = i + 1;
            yield return new WaitForSeconds(speed * 1.5f);
            StartCoroutine(QuickSort(unsortedList, p + 1, right));
            yield return new WaitForSeconds(speed * 1.5f);
            StartCoroutine(QuickSort(unsortedList, left, p - 1));
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