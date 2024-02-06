using UnityEngine;

public class MissionTree : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    private void Start()
    {
        PassiveUI();
    }
    public void ActiveUI() => _uiPanel.SetActive(true);
    public void PassiveUI() => _uiPanel.SetActive(false);
    public void CutTree()
    {
        GameManager.Instance.Ending(true);
        Destroy(gameObject);
    }

}
