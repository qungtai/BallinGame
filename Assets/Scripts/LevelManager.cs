using System;
using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{	
	[SerializeField] private Transform _transCharacter;
	private IDisposable _timerDisposer;
	private int _level;
	private float _timeLeft;
	
	[SerializeField] private GameObject coint;


	public void Initialize()
	{
	}
	public void StartGameSession()
	{
		_level = 1;
		
	}
	void OnFinish()
	{
		_timerDisposer?.Dispose();
		
		
	}
 
	public void OnContinueNextLevel()
	{
		_level++;		
		
	}

	
	private void OnLose()
	{
		
	}

	private void SetCharacterPosition()
	{
		
	}

	private void DropCointInMaze()
	{
		
	}

}
