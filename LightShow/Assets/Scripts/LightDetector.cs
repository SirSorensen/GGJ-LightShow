
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Collider2D))]

public class LightDetector : MonoBehaviour
{
	[SerializeField] public float R, G, B = 0.0f;
	[SerializeField] public float goalR, goalG, goalB = 255.0f;
	Dictionary<string, Color> lightSet = new Dictionary<string, Color>(); 
	[SerializeField] public string nextScene;
	private float _currentTime = 0.0f;
	private bool _timerActive = false;



	public void Start()
    {
        RayCaster[] lights = FindObjectsByType<RayCaster>(FindObjectsSortMode.None);
		if (lights != null)
        {
			foreach (var light in lights)
			{
				light.onGoalDetected += SetLightsOnGoal;
				light.onGoalNotDetected += RemoveLightsOnGoal;
			}
        }
    }

	void Update()
	{
		this.R = 0.0f;
		this.G = 0.0f;
		this.B = 0.0f;

		foreach(KeyValuePair<string, Color> entry in lightSet)
		{
			this.R += entry.Value.r;
			this.G += entry.Value.g;
			this.B += entry.Value.b;
		}
		R = math.min(R*255, 255);
		G = math.min(G*255, 255);
		B = math.min(B*255, 255);
		#if UNITY_EDITOR
		Debug.Log("R,G,B = " + R + "," + G + "," + B);
		#endif

		if (R == goalR && G == goalG && B == goalB)
		{
			_timerActive = true;
		}
		else
		{
			_timerActive = false;
			_currentTime = 0;
		}

		if (_timerActive)
		{
			_currentTime += Time.deltaTime;
		}

		if (_currentTime > 2.5)
		{
			SceneManager.LoadScene(nextScene);
		}
	}

	public void SetLightsOnGoal(string _name, Color color)
    {
        if (!lightSet.ContainsKey(_name))
		{
			lightSet.Add(_name, color);
		}
    }

	public void RemoveLightsOnGoal(string _name)
    {
        lightSet.Remove(_name);
    }
}
