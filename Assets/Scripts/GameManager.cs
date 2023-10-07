using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private SpawnManager _spawnManager;
    public event Action<float> OnUpdateScore; 
    public event Action<float> OnGameFinished; 
    private float _score;
    private float Score
    {
        get => _score;
        set
        {
            _score = value;
            OnUpdateScore?.Invoke(_score);
        }
    }
    protected override void Initialize()
    {
        base.Initialize();
    }

    public void StartMazeSession()
    {
    }
    public void OnContinueNextLevel()
    {
    }

    public void OnFinishLevel(int level, float timeLeft)
    {
        // ConfigMazeLevelRecord cf= Configuration.Instance.ConfigMazeLevel.GetConfigByLevel(level);
        // OnGameFinished?.Invoke(timeLeft);
        // float bonusScore = cf.ScorePerSec * timeLeft;
        // _score += bonusScore;
        // ViewController.Instance.SwitchView(ViewIndex.GameResultView,new GameResultView.Param(level, level, bonusScore));
        // OnUpdateScore?.Invoke(_score);
    }

    public void OnLose()
    {
        
    }
}