using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ModalWindowManager : MonoBehaviour {


    public Text title;
    public GameObject awnserButtonPrefab;
    public GameObject descriptionPrefab;
    public GameObject textContainer;
       
    // Use this for initialization

    void OnEnable ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SetTitle(string titleStr)
    {
        title.text = titleStr;
    }
    public void SetDescription(string descStr)
    {
        GameObject instDesc = Instantiate(descriptionPrefab);
        instDesc.transform.SetParent(textContainer.transform);
        instDesc.transform.SetAsFirstSibling();
        instDesc.GetComponentInChildren<Text>().text = descStr;
    }

    public void AddAwnser(string awnserStr)
    {
        GameObject instAwnser = Instantiate(awnserButtonPrefab);
        instAwnser.transform.SetParent(textContainer.transform);
        instAwnser.GetComponentInChildren<Text>().text = awnserStr;
        instAwnser.GetComponent<AwnserManager>().ModalWindow = gameObject;

    }
    public void CloseModalWindow()
    {
        gameObject.SetActive(false);
        for(int i = 0; i < textContainer.transform.childCount;i++ )
        {
            Destroy(textContainer.transform.GetChild(i).gameObject);
        }
        //textContainer.transform.childCount

    }

}
