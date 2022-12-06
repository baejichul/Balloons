using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RockPaperScissors
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager I;

		public GameObject endPanel;
		public GameObject square;
		public Text timeTxt;
		public Text thisScoreTxt;
		float alive = 0f;
		bool isRunning = true;

        void Awake()
        {
			I = this;    
        }

		//TODO:
		// 2-5까지 완료

        // Start is called before the first frame update
        void Start()
	    {
			Time.timeScale = 1.0f;
			InvokeRepeating("MakeSquare", 0f, 0.5f);
	    }

	    // Update is called once per frame
	    void Update()
	    {
			if (isRunning)
            {
				alive += Time.deltaTime;
				timeTxt.text = alive.ToString("N2");
			}
		}

		void MakeSquare()
        {
			Instantiate(square);
        }

		public void GameOver()
        {
			isRunning = false;
			Time.timeScale = 0.0f;
			endPanel.SetActive(true);
			thisScoreTxt.text = alive.ToString("N2");
		}

		public void GameRetry()
        {
			SceneManager.LoadScene("MainScene");
        }
    }
}