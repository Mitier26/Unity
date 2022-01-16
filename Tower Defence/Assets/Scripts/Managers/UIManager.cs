using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject turretShopPanel;

    private Node _currentNodeSelected;

    public void CloseTurretShopPanel()
    {
        turretShopPanel.SetActive(false);
    }

    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
        if(_currentNodeSelected.IsEmpty())
        {
            turretShopPanel.SetActive(true);
        }
    }

    void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
    }

    void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
    }
    
}
