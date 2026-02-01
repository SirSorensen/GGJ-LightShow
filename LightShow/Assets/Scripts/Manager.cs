using UnityEngine;

public class GameManager : MonoSingleton<GameManager> {
	public bool paused = false;

	void Start()
	{
		Application.targetFrameRate = 60;
	}
}