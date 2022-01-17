using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Achivement")]
public class Achivement : ScriptableObject
{
    public string ID;
    public string Title;
    public int ProgressToUnlock;
    public int GoldReward;
    public Sprite Spretie;
}
