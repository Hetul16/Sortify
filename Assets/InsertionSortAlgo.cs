using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertionSortAlgo : MonoBehaviour
{

    public int NumberOfCubes;
    public int CubeHeightMax=10;
    public GameObject[] Cubes;

    public GameObject[] text;

    GameObject temp;
    GameObject[] tempList;
    
    // [SerializeField] private float speed;

    public Slider mySlider;
    public float SliderValue;
    public float speed=0.05f;

    // public TextMeshProUGUI;
    // Start is called before the first frame update
    public void StartSort()
    {
        IntializeRandom();
        StartCoroutine(InsertionSort(Cubes));
        
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

    IEnumerator InsertionSort(GameObject[] unsortedList)
    {
        for(int i=1; i<unsortedList.Length; i++)
        {
            yield return new WaitForSeconds(speed);

            this.temp = unsortedList[i];
            LeanTween.color(this.temp, Color.red, 0.01f);
            LeanTween.moveLocalY(this.temp, NumberOfCubes + (unsortedList[i].transform.localScale.y / 2), speed);

            int j = i - 1;

            float temp = -100; // for animation

            while (j >= 0 && unsortedList[j].transform.localScale.y > this.temp.transform.localScale.y)
            {
                yield return new WaitForSeconds(speed);

                LeanTween.moveLocalX(unsortedList[j], unsortedList[j].transform.localPosition.x + 1f, speed);
                unsortedList[j + 1] = unsortedList[j];

                temp = unsortedList[j].transform.localPosition.x;
                j--;
            }

            // for animation
            if(temp >= 0)
            {
                yield return new WaitForSeconds(speed);
                LeanTween.moveLocalX(this.temp, temp, speed);
            }
            yield return new WaitForSeconds(speed);
            LeanTween.moveLocalY(this.temp, this.temp.transform.localScale.y / 2.0f, speed);
            
            LeanTween.color(this.temp, Color.white, 0.01f);
            //

            unsortedList[j + 1] = this.temp;
        }

        yield return new WaitForSeconds(0.1f);

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