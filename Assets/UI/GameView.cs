using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
   [SerializeField] private SpawnManager _spawnManager;
   [SerializeField] private CharacterControl _character;
   [FormerlySerializedAs("Time")] public TextMeshProUGUI Timetxt;
   [FormerlySerializedAs("Diamond")] public TextMeshProUGUI Diamondtxt;
   [FormerlySerializedAs("Level")] public TextMeshProUGUI Leveltxt;
   [SerializeField] private GameObject PauseMenu;
   [SerializeField] private Slider powerTime;

   private void Start()
   {
      OnSetMaxPowerTime(_character.powerUpTime);
   }

   private void Update()
   {
      Diamondtxt.text = "Diamond: " + _character.DiamondCount.ToString();
      Leveltxt.text = "Level: " + _spawnManager.level.ToString();
      Timetxt.text = "Time: " + string.Format("{0:00}:{1:00}",Mathf.FloorToInt(_spawnManager.remainingTime / 60),Mathf.FloorToInt(_spawnManager.remainingTime % 60));
      OnSetTime(_character.powerUpTime);
   }
   public void OnPause()
   {
      Time.timeScale = 0;
      PauseMenu.SetActive(true);
   }

   void OnSetMaxPowerTime(float time)
   {
      powerTime.maxValue = time;
      powerTime.value = time;
      
   }

   void OnSetTime(float time)
   {
      powerTime.value = time;
   }
}
