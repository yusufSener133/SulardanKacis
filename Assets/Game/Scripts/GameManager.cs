using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    private Counter _counter;
    public Counter Counter { get => _counter; }

    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Transform _light;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        _counter = new Counter();
    }

    private void Update()
    {
        Debug.Log(Counter.Update());
    }

    public void StartCountdown(int startingCount) => Counter.StartCountdown(startingCount);

    public void Ending(bool end)
    {
        switch (end)
        {
            case true:
                StartCoroutine(GoodEnding());
                break;
            case false:
                StartCoroutine(BadEnding());
                break;
        }
    }

    IEnumerator GoodEnding()
    {
        while (_light.rotation.x > 0)
        {
            _light.transform.Rotate(Vector3.up, -1f);
            _light.transform.Rotate(Vector3.right, -1f);
            yield return new WaitForSeconds(.01f);
        }
        _uiManager.GoodEnding();

    }
    IEnumerator BadEnding()
    {
        while (_light.rotation.x > 0)
        {
            _light.transform.Rotate(Vector3.up, -1f);
            _light.transform.Rotate(Vector3.right, -1f);
        yield return new WaitForSeconds(.01f);
        }
        _uiManager.BadEnding();


    }
}
