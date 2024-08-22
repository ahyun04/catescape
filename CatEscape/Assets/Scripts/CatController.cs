using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    public Button LButton;
    public Button RButton;

    void Start()
    {
        RButton.onClick.AddListener(RightButtonClick);
        LButton.onClick.AddListener(LeftButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeftButtonClick()
    {

    }
    public void RightButtonClick()
    {

    }
}
