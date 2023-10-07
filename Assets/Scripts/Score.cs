using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI level; 
    public TextMeshProUGUI time; 
    public TextMeshProUGUI diamond;
    
    private void Start()
    {
        level.text = DataPaste.Level.ToString();
        time.text = DataPaste.Time;
        diamond.text = DataPaste.Diamond.ToString();
    }
}


