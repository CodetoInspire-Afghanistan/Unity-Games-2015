using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharecterLevels : MonoBehaviour {
    public Text[] text;
	public Text[] text2;
    public Text GuessText;
      public  InputField findNumber2;
	public static int fullNumber=0;
	public static int fullNumber2=0;
	public AudioClip magic;





    // Update is called once per frame


	public virtual void Update() {
		if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==2){
			if (Input.GetKeyDown (KeyCode.Return)) {
				for (int i = 0; i < 40; i++) {

					if (text [i].text.ToString () == findNumber2.text.ToString () && text [i].color != Color.white && RandomNumber.isFill) {
						GetComponent<AudioSource> ().Play ();
						text [i].color = Color.white;
						fullNumber++;
						if (fullNumber == 40) {
							fullNumber2 = 0;
							fullNumber = 0;
							foreach (Text b  in text) {
								b.color = Color.black;

							}

							foreach (Text b  in text2) {
								b.color = Color.black;

							}
							SceneManager.LoadScene ("WinScreenFirstPlayer");

 
						}  

					}
				}
			}
			if (Input.GetKeyUp (KeyCode.Return)) {
				findNumber2.text = "";
				findNumber2.ActivateInputField ();
				findNumber2.Select ();
			}
		}
		else if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==3){
			if(Input.GetKeyDown(KeyCode.Return)  ){
				for(int i=0;i<40;i++) {

					if (text2[i].text.ToString()==findNumber2.text.ToString()&&text2[i].color!=Color.white && RandomNumber.isFill) {
						GetComponent<AudioSource>().Play();
						text2[i].color=Color.white;
						fullNumber2++;

						if (fullNumber2 == 40) {
							fullNumber = 0;
							fullNumber2 = 0;
							foreach (Text b  in text2) {
								b.color = Color.black;

							}
							foreach (Text b  in text) {
								b.color = Color.black;

							}
							SceneManager.LoadScene ("WinScreenSecondPlayer");


						}  

					}
				}
			}
			if(Input.GetKeyUp(KeyCode.Return)){
				findNumber2.text="";

				findNumber2.ActivateInputField();

				findNumber2.Select();
				}
		}
		
    }


	 

}
