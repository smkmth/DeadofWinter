using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ModelPanel : MonoBehaviour{


	public Text question;
	public Image iconImage;
	public Button yesButton;
	public Button noButton;
	public Button cancelButton;
	public GameObject modelPanelObject;

	private static ModelPanel modalPanel;

	//modified singleton
	public static ModelPanel Instance () {
		if (!modalPanel) {
			modalPanel = FindObjectOfType(typeof (ModelPanel)) as ModelPanel;
			if (!modalPanel)
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
		}

		return modalPanel;
	}
	//yes/no/cancel function
	public void Choice(string question, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
	{
		modelPanelObject.SetActive (true);
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener (ClosePanel);

		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);

		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener (cancelEvent);
		cancelButton.onClick.AddListener (ClosePanel);

		this.question.text = question;
		this.iconImage.gameObject.SetActive (false);
		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (true);
		cancelButton.gameObject.SetActive (true);


	}

	void ClosePanel (){
		modelPanelObject.SetActive (false);

	}

	//yes no cancel with image (a string, a Sprite, a yesEvent, a no event and a cancel event)
	public void Choice(string question, Sprite iconImage, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
	{
		modelPanelObject.SetActive (true);
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener (ClosePanel);

		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);

		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener (cancelEvent);
		cancelButton.onClick.AddListener (ClosePanel);

		this.question.text = question;
		this.iconImage.sprite = iconImage;

		this.iconImage.gameObject.SetActive (true);
		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (true);
		cancelButton.gameObject.SetActive (true);


	}


}
	

