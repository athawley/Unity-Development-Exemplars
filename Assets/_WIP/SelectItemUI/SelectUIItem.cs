using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUIItem : MonoBehaviour
{
    [SerializeField]
    private int selecedItem = 0;

    public void PrefabSelector(int index) {
        selecedItem = index;
        PrimaryClickItemSpawnerUICheck pcis = GetComponent<PrimaryClickItemSpawnerUICheck>();
        pcis.selectedPrefab = index;
    }
}
