using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{

    private Camera mainCam;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TMP_Text promptTxt;
    // Start is called before the first frame update
    private void Start()
    {
        mainCam = Camera.main;
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation*Vector3.up);
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText){
        promptTxt.text = promptText;
        uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close(){
        IsDisplayed = false;
        uiPanel.SetActive(false);
    }
}
