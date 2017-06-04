using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    private GameObject coinPrefab;

    [SerializeField]
    private Text coinText;

	public static int collectedCoins;


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public GameObject CoinPrefab
    {
        get
        {
            return coinPrefab;
        }
    }

	void Update(){
		coinText.text = collectedCoins.ToString ();
	}

	//public static int CollectedCoins
    //{
      //  get
       // {
         //   return collectedCoins;
        //}

        //set
        //{
		//	coinText.text = value.ToString();
          //  GameManager.collectedCoins = value;
        //}
   // }

		
	
}
