using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSortAlgo : MonoBehaviour
{

    public int NumberOfCubes;
    public int CubeHeightMax=10;
    public GameObject[] Cubes;

    public GameObject[] text;
    
    // [SerializeField] private float speed;

    public Slider mySlider;
    public float SliderValue;
    public float speed=0.5f;

    // public TextMeshProUGUI;
    // Start is called before the first frame update
    public void StartSort()
    {
        IntializeRandom();
        StartCoroutine(BubbleSort(Cubes));
        
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

    // IEnumerator BubbleSort(GameObject[] unsortedList)
    // {     
    //     // int min;
    //     GameObject temp;
    //     Vector3 tempPosition;
    //         //min = i;
    //         yield return new WaitForSeconds(speed);
    //         // for(int j=0; j < (unsortedList.Length - 1-i) ; j++)
    //         // {
    //         //     if(unsortedList[j].transform.localScale.y > unsortedList[j+1].transform.localScale.y)
    //         //     {
    //         //         min = j; 
    //         //     }
    //         //     Debug.Log(speed);
    //         // }
    //         int i=0 , j =0; 
    //         for(i = 0 ; i< unsortedList.Length;i++)
    //         {
    //             for(j=0; j<(unsortedList.Length-1); j++)
    //             {
    //                 if(unsortedList[j].transform.localScale.y > unsortedList[j+1].transform.localScale.y)
    //                 {
    //                     yield return new WaitForSeconds(speed);
    //                     temp = unsortedList[j];
    //                     unsortedList[j] = unsortedList[j+1];
    //                     unsortedList[j+1] = temp;
    //                     tempPosition = unsortedList[i].transform.localPosition;

    //                     LeanTween.moveLocalX(unsortedList[j],unsortedList[j+1].transform.localPosition.x,speed);
    //                     LeanTween.moveLocalZ(unsortedList[j],-3,speed).setLoopPingPong(1);
    //                     LeanTween.moveLocalX(unsortedList[j+1],tempPosition.x,speed);
    //                     LeanTween.moveLocalZ(unsortedList[j+1],9,speed).setLoopPingPong(1);
    //                 }
    //                 LeanTween.color(unsortedList[i], Color.green, speed);
    //             }
    //         }
    //         // if(min != i)
    //         // {
    //         //     yield return new WaitForSeconds(speed);
    //         //     temp= unsortedList[i];
    //         //     unsortedList[i] = unsortedList[min];
    //         //     unsortedList[min] = temp ; 
                
    //         //     tempPosition = unsortedList[i].transform.localPosition;
    //         //     // movement=1.0f*SliderValue;
    //         //     Debug.Log(speed);
                
    //         //     LeanTween.moveLocalX(unsortedList[i],unsortedList[min].transform.localPosition.x,speed);
    //         //     LeanTween.moveLocalZ(unsortedList[i],-3,speed).setLoopPingPong(1);
    //         //     LeanTween.moveLocalX(unsortedList[min],tempPosition.x,speed);
    //         //     LeanTween.moveLocalZ(unsortedList[min],9,speed).setLoopPingPong(1);
    //         // }
    //         // LeanTween.color(unsortedList[i], Color.green, speed);

    // }



    IEnumerator BubbleSort(GameObject[] unsortedList)
    {
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length - 1; i++)
        {
            yield return new WaitForSeconds(speed);
            // Last i elements are already in the correct place.
            for (int j = 0; j < unsortedList.Length - i - 1; j++)
            {
                bool last = j == unsortedList.Length - i - 2;
                // Highlight current cubes being compared as blue.
                LeanTween.color(unsortedList[j], Color.blue, 0);
                LeanTween.color(unsortedList[j + 1], Color.blue, 0);
                yield return new WaitForSeconds(speed);
                if (unsortedList[j].transform.localScale.y > unsortedList[j + 1].transform.localScale.y)
                {
                    //Colour change to red when swapping.
                    LeanTween.color(unsortedList[j], Color.red, 0);
                    LeanTween.color(unsortedList[j + 1], Color.red, 0);

                    // Swap array elements.
                    temp = unsortedList[j];
                    unsortedList[j] = unsortedList[j + 1];
                    unsortedList[j + 1] = temp;

                    tempPosition = unsortedList[j].transform.localPosition;

                    // Using LeanTween for animations, swaps the cubes
                    LeanTween.moveLocalX(unsortedList[j],
                                         unsortedList[j + 1].transform.localPosition.x,
                                         speed);

                    LeanTween.moveLocalZ(unsortedList[j],
                                         -3,
                                         speed).setLoopPingPong(1);

                    LeanTween.moveLocalX(unsortedList[j + 1],
                                         tempPosition.x,
                                         speed);

                    LeanTween.moveLocalZ(unsortedList[j + 1],
                                         3,
                                         speed).setLoopPingPong(1);
                    if (last)
                    {
                        // If last element being sorted, then change colour to green as it's in its correct position.
                        LeanTween.color(unsortedList[j + 1], Color.green, speed);
                    }
                    else
                    {
                        LeanTween.color(unsortedList[j + 1], Color.white, speed);
                    }
                    LeanTween.color(unsortedList[j], Color.white, speed);
                    yield return new WaitForSeconds(speed);
                    continue;
                }
                LeanTween.color(unsortedList[j], Color.white, 0);
                // Deals with case of when the last element is being compared.
                if (last && i == unsortedList.Length - 2)
                {
                    LeanTween.color(unsortedList[j], Color.green, 1f);
                    LeanTween.color(unsortedList[j + 1], Color.green, 1f);
                }

                // If the last element is being sorted then change its colour to green as it's in its correct position.
                else if (last)
                {
                    LeanTween.color(unsortedList[j + 1], Color.green, 1f);
                }
                else
                {
                    LeanTween.color(unsortedList[j + 1], Color.white, 0);
                }
            }
        }
    }

    // void IntializeRandom(){
    //     Cubes = new GameObject[NumberOfCubes];

    //     for(int i=0; i<NumberOfCubes; i++){
    //         int randomNumbers = Random.Range(1 , CubeHeightMax + 1);
    //         Debug.Log(randomNumbers);
    //         // public GameObject
    //         GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //         cube.transform.localScale = new Vector3(0.9f, randomNumbers, 1);
    //         cube.transform.position = new Vector3(i , randomNumbers / 2.0f, 4);
    //         cube.transform.parent = this.transform;
    //         Cubes[i]=cube;
    //     }
    //     transform.position=new Vector3(-NumberOfCubes/2f , -CubeHeightMax/2.0f ,0);
    //     //Camera.main.transform.position = new Vector3(-NumberOfCubes / 2.0f, numberOfCubes / 2.0f + 1.5f, -numberOfCubes - 3);
    // }

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
