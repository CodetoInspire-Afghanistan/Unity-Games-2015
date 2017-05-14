using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RandomNumber : MonoBehaviour {
  //  public Button[] Btn;

    List<int> number=new List<int>();
    public GameObject[] numbers;

	[SerializeField]
	private Text GuessText;
    private  Text txt;
    int []myArray = new int[66];
  	public  InputField findNumber;
    private  string x;
	public static bool isFill;
     //public GameObject RandomNum2;
     void Start () {
          findNumber.ActivateInputField();
        findNumber.Select();


        // DontDestroyOnLoad(RandomNum2.gameObject);
 		StartGame ();
	}

	// Update is called once per frame
	void Update () {
		if(findNumber.text!=""){
			isFill = true;
		}
    }

	public void StartGame(){

		for(int i=0;i<myArray.Length;i++){
			 txt = Instantiate (GuessText,numbers[i].transform.position,Quaternion.identity)as Text;
			txt.transform.SetParent (numbers[i].transform);
			int num=Random.Range(0,66);
            while (number.Contains(num)){
                num=Random.Range(0,66);

            }

            while (!number.Contains(num)){
                number.Add(num);
            }

			txt.text=number[i].ToString();

		}
    }
 public void onCLikMe(int i){
     if (numbers[i].GetComponentInChildren<Text>().text==findNumber.text.ToString()){
			isFill = false;

         if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 3) {
             SceneManager.LoadScene("ExcellentFirst");



         }else{
             SceneManager.LoadScene("ExcellentSecond");
         }
			findNumber.text =null;
			               
     }
     //Debug.Log(numbers[i].GetComponentInChildren<Text>().text);
 }

}



