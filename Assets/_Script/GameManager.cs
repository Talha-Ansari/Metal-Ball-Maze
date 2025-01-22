using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<MazeLayer> layers;
    int currentLayer = 0;
    public void MoveToNextLayer()
    {
        currentLayer++;
        currentLayer = currentLayer % layers.Count;
        for (int i = 0; i < layers.Count; i++)
        {
            layers[i].gameObject.SetActive(false);
            layers[i].ResetLayer();
        }
        layers[currentLayer].gameObject.SetActive(true);

    }
}
