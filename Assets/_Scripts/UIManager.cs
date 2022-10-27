using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _ui;
    public static GameObject FailScreenGameObject;
    public TextMeshProUGUI failScreenUI;
    public static GameObject FinishScreenGameObject;
    public TextMeshProUGUI finishScreenUI;
    public GameObject inputSliderGameObject;
    public static Slider InputSliderUI;

    private void Start()
    {
        _ui = GameObject.FindGameObjectWithTag("MainUI");
        FailScreenGameObject = _ui.transform.Find("FailScreen").gameObject;
        FinishScreenGameObject = _ui.transform.Find("FinishScreen").gameObject;
        FailScreenGameObject.SetActive(false);
        FinishScreenGameObject.SetActive(false);
        failScreenUI = FailScreenGameObject.GetComponent<TextMeshProUGUI>();
        finishScreenUI = FinishScreenGameObject.GetComponent<TextMeshProUGUI>();
        InputSliderUI = inputSliderGameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.IsPlayerFailed)
        {
            FailScreenGameObject.SetActive(true);
            GameManager.IsPlayerFailed = false;
        }

        if (GameManager.IsLevelDone)
        {
            FinishScreenGameObject.SetActive(true);
            GameManager.IsLevelDone = false;
        }
    }
}