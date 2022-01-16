using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class turretCard : MonoBehaviour
{
    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI turretCost;

    public void SetupTurretButton(TurretSettings turretSettings)
    {
        turretImage.sprite = turretSettings.TurretShopSprite;
        turretCost.text = turretSettings.TurretShopCost.ToString();
    }

}
