using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShopManager : MonoBehaviour
{
    [SerializeField] private GameObject turretCardPrefab;
    [SerializeField] private Transform turretPanelContainer;

    [Header("Turret Setting")]
    [SerializeField] private TurretSettings[] turrets;

    private Node _currentNodeSelected;

    void Start()
    {
        for(int i = 0 ; i < turrets.Length; i++)
        {
            CreateTurretCard(turrets[i]);
        }
    }

    private void CreateTurretCard(TurretSettings turretSettings)
    {
        GameObject newInstance = Instantiate(turretCardPrefab, turretPanelContainer.position, Quaternion.identity);
        newInstance.transform.SetParent(turretPanelContainer);
        newInstance.transform.localScale = Vector3.one;

        TurretCard cardButton = newInstance.GetComponent<TurretCard>();
        cardButton.SetupTurretButton(turretSettings);
    }

    private void NodeSelected(Node nodeSelectrd)
    {
        _currentNodeSelected = nodeSelectrd;
    }

    private void PlaceTurret(TurretSettings turretLoaded)
    {
        if(_currentNodeSelected != null)
        {
            GameObject turretInstance = Instantiate(turretLoaded.TurretPrefab);
            turretInstance.transform.localPosition = _currentNodeSelected.transform.position;
            turretInstance.transform.parent = _currentNodeSelected.transform;

            Turret turretPlaced = turretInstance.GetComponent<Turret>();
            _currentNodeSelected.SetTurret(turretPlaced);
        }
    }

    void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
        TurretCard.OnPlaceTurret += PlaceTurret;
    }

    
    void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
        TurretCard.OnPlaceTurret -= PlaceTurret;
    }

}
