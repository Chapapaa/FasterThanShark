using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSupressValidation : MonoBehaviour {

    public CrewPanelDisplayManager displayMng;
    public Text titleText;
    public Text contentText;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetTitle(string title)
    {
        titleText.text = title;
    }
    public void SetContent(string content)
    {
        contentText.text = content;
    }

    public void CancelAction()
    {
        Destroy(gameObject);
    }

    public void ConfirmSupress()
    {
        displayMng.ConfirmDismiss();
        Destroy(gameObject);
    }


}
