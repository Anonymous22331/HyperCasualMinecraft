using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridExpand : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private RectTransform _rectTransform;

    void Start()
    {
        UpdateCellSize();
    }

    void UpdateCellSize()
    {
        float width = _rectTransform.rect.width;
        float height = _rectTransform.rect.height;

        float cellSizeX = width / 3;
        float cellSizeY = height / 3;

        _gridLayoutGroup.cellSize = new Vector2(cellSizeX, cellSizeY);
        
    }
}
