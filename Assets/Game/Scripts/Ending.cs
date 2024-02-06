using System.Collections;
using UnityEngine;
using TMPro;

public class Ending : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] float _waitingTime;
    [SerializeField] GameObject _buttonsPanel;
    private string _lastNote;
    void Start()
    {
        _lastNote = text.text;
        text.text = null;
        _buttonsPanel.SetActive(false);
        StartCoroutine(StartText());
    }
    IEnumerator StartText()
    {
        for (int i = 0; i < _lastNote.Length; i++)
        {
            text.text += _lastNote[i];
            yield return new WaitForSeconds(_waitingTime);
        }
        _buttonsPanel.SetActive(true);
    }
}
