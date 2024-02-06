using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text _counterText;
    [SerializeField] GameObject _goodEndingPanel, _badEndingPanel;
    private void Start()
    {
        GameManager.Instance.StartCountdown(60);
    }
    private void Update()
    {
        if (!_goodEndingPanel.activeInHierarchy && !_badEndingPanel.activeInHierarchy)
            _counterText.text = GameManager.Instance.Counter.Update();
    }
    public void GoodEnding() { _goodEndingPanel.SetActive(true); }
    public void BadEnding() { _badEndingPanel.SetActive(true); }

    public void ButtonAgain() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void ButtonExit() => Application.Quit();
}

