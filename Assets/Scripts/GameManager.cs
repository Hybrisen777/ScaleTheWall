using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action PlayClicked;
    public event Action SettingsClicked;
    public event Action MenuButtonClicked;
    public event Action QuitButtonClicked;
    [SerializeField]
    private CanvasRenderer _panelCanvasRenderer;
    [SerializeField]
    private GameObject _playButton;
    [SerializeField]
    private GameObject _settingsButton;
    [SerializeField]
    private GameObject _menuButton;
    [SerializeField]
    private GameObject _quitButton;
    [SerializeField]
    private float menuAlpha = 100f;

    public void PlayButtonClick()
    {
        _panelCanvasRenderer.SetAlpha(0f);
        _playButton.SetActive(false);
        _settingsButton.SetActive(false);
        _quitButton.SetActive(false);
        _menuButton.SetActive(true);
        PlayClicked?.Invoke();
    }
    public void SettingsButtonClick()
    {
        SettingsClicked?.Invoke();
    }
    public void MenuButtonClick()
    {
        MenuButtonClicked?.Invoke();
        _panelCanvasRenderer.SetAlpha(menuAlpha);
        _playButton.SetActive(true);
        _settingsButton.SetActive(true);
        _quitButton.SetActive(true);
        _menuButton.SetActive(false);
        
    }
    public void QuitButtonClick()
    {
        QuitButtonClicked?.Invoke();
        Application.Quit();
    }
}
