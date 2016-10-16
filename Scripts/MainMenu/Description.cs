using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Description : MonoBehaviour {

    public Text nameStat;
    public Text descriptionStat;

    public void NameStat(string descript) {
        nameStat.text = descript;
    }

    public void DescriptStat(string descriptStat) {
        descriptionStat.text = descriptStat;
    }
}
