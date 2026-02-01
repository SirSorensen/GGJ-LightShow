using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private bool isPaused = false;
	public GameObject container;

	void Update() 
	{ 
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			#if UNITY_EDITOR
			Debug.Log("Esacpe it pressed!");
			#endif
			onEscapePress();
		}
	}

    void onEscapePress()
	{
		if (isPaused)
		{
			ResumeGame();
		}
		else
		{
			PauseGame();
		}
		isPaused = !isPaused;
	}

	void PauseGame()
	{
		GameManager.Instance.paused = true;
		container.SetActive(true);
	}

	public void ResumeGame()
	{
		container.SetActive(false);
		GameManager.Instance.paused = false;
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
