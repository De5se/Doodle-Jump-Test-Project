using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    private TextMeshProUGUI _levelText;
    private void Start()
    {
        _levelText = GetComponent<TextMeshProUGUI>();
        _levelText.SetText("LEVEL " + PlayerPrefs.GetInt("Level").ToString());
    }
}
