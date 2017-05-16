using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CorrectOption : MonoBehaviour {



	//public AudioClip CorrectSound;
	public AudioClip Wrong;
	void OnMouseDown(){

		if (gameObject.CompareTag ("Correct")) {
			//AudioSource.PlayClipAtPoint (CorrectSound,transform.position);


			if (SceneManager.GetActiveScene ().name == "1(1x1)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("2(2x2)");
			} else if (SceneManager.GetActiveScene ().name == "2(2x2)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("3(2x2)");
			} else if (SceneManager.GetActiveScene ().name == "3(2x2)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("4(3x3)");
			} else if (SceneManager.GetActiveScene ().name == "4(3x3)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("5(3x3)");
			} else if (SceneManager.GetActiveScene ().name == "5(3x3)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("6(4x4)");
			} else if (SceneManager.GetActiveScene ().name == "6(4x4)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("7(4x4)");
			} else if (SceneManager.GetActiveScene ().name == "7(4x4)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("8(4x5)");
			} else if (SceneManager.GetActiveScene ().name == "8(4x5)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("9(4x5)");
			} else if (SceneManager.GetActiveScene ().name == "9(4x5)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("10(5x5)");
			} else if (SceneManager.GetActiveScene ().name == "10(5x5)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("11(5x5)");
			} else if (SceneManager.GetActiveScene ().name == "11(5x5)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("12(5x6)");
			} else if (SceneManager.GetActiveScene ().name == "12(5x6)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("13(5x6)");
			} else if (SceneManager.GetActiveScene ().name == "13(5x6)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("14(6x6)");
			} else if (SceneManager.GetActiveScene ().name == "14(6x6)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("15(6x6)");
			} else if (SceneManager.GetActiveScene ().name == "15(6x6)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("16(7x7)");
			} else if (SceneManager.GetActiveScene ().name == "16(7x7)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("17(7x7)");
			} else if (SceneManager.GetActiveScene ().name == "17(7x7)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("18(8x8)");
			} else if (SceneManager.GetActiveScene ().name == "18(8x8)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("19(8x8)");
			} else if (SceneManager.GetActiveScene ().name == "19(8x8)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("20(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "20(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("21(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "21(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("22(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "22(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("23(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "23(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("24(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "24(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("25(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "25(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("26(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "26(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("27(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "27(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("28(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "28(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("29(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "29(10x10)") {
				ScoreKeeper.UpdateScore (1);
				SceneManager.LoadScene ("30(10x10)");
			} else if (SceneManager.GetActiveScene ().name == "30(10x10)") {
				ScoreKeeper.UpdateScore (1);

				if (ScoreKeeper.scoreCalculator >= 0 && ScoreKeeper.scoreCalculator <= 9) {
					SceneManager.LoadScene ("Low");

				}
				if (ScoreKeeper.scoreCalculator > 9 && ScoreKeeper.scoreCalculator <= 15) {

					SceneManager.LoadScene ("Normal");
				}
				if (ScoreKeeper.scoreCalculator > 15 && ScoreKeeper.scoreCalculator <= 29) {

					SceneManager.LoadScene ("Good");

				}
				if (ScoreKeeper.scoreCalculator >= 30) {

					SceneManager.LoadScene ("Prefect");
				}
			}




		}else {

			if (ScoreKeeper.scoreCalculator > 0) {
				ScoreKeeper.DecreaseScore ();
			}
			AudioSource.PlayClipAtPoint (Wrong,transform.position,1f);
		}
	}
}


		