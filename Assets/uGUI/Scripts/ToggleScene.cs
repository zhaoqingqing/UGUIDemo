using UnityEngine;
using UnityEngine.UI;

public class ToggleScene : MonoBehaviour
{
	[SerializeField]
	private GameObject bluePanel, redPanel;
	[SerializeField]
	private Toggle toggleRed, toggleBlue;

	void Start()
	{
		toggleRed.onValueChanged.AddListener(OnValChangedRed);
		toggleBlue.onValueChanged.AddListener(OnValChangedBlue);
	}

	void OnValChangedRed(bool check)
	{
		bluePanel.SetActive(!check);
		redPanel.SetActive(check);
	}
	void OnValChangedBlue(bool check)
	{
		bluePanel.SetActive(check);
		redPanel.SetActive(!check);
	}
}