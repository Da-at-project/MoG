using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;
    private SmallBalahMovement smallBalah;

    private void Start()
    {
        smallBalah = FindObjectOfType<SmallBalahMovement>();
    }
}
