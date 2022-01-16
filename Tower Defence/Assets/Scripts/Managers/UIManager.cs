using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject turretShopPanel;
    [SerializeField] private GameObject nodeUIPanel;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI sellText;
    [SerializeField] private TextMeshProUGUI turretLevelText;

    private Node _currentNodeSelected;

    public void CloseTurretShopPanel()
    {
        turretShopPanel.SetActive(false);
    }

    public void UpgradeTurret()
    {
        _currentNodeSelected.Turret.TurretUpgrade.UpgradeTurret();
        UPdateUpgradeText();
        UpdateTurretLevel();
    }

    private void ShowNodeUI()
    {
        nodeUIPanel.SetActive(true);
        UPdateUpgradeText();
        UpdateTurretLevel();
        
    }

    private void UPdateUpgradeText()
    {
        upgradeText.text = _currentNodeSelected.Turret.TurretUpgrade.UpgradeCost.ToString();
    }

    private void UpdateTurretLevel()
    {
        turretLevelText.text = $"Level {_currentNodeSelected.Turret.TurretUpgrade.Level}";
    }

    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
        if(_currentNodeSelected.IsEmpty())
        {
            turretShopPanel.SetActive(true);
        }
        else
        {
            ShowNodeUI();
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
