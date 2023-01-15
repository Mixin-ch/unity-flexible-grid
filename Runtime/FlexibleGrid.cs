using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mixin.FlexibleGrid
{
    public class FlexibleGrid : LayoutGroup
    {
        [SerializeField] private LayoutFitType _fitType;
        private int _columns;
        private int _rows;
        [SerializeField] private Vector2 _cellSize;
        [SerializeField] private Vector2 _spacing;

        private bool _stretchX;
        private bool _stretchY;

        private bool _boxAutoSizeX;
        private bool _boxAutoSizeY;

        private bool _lockXToY;
        private bool _lockYToX;

        private int _childCount;

        public override void CalculateLayoutInputVertical()
        {
            base.CalculateLayoutInputHorizontal();

            if (_columns <= 0) return;
            if (_rows <= 0) return;

            // Count Children
            _childCount = transform.childCount;

            switch (_fitType)
            {
                case LayoutFitType.Width:
                case LayoutFitType.Height:
                case LayoutFitType.Uniform:
                    {
                        float sqrRt = Mathf.Sqrt(_childCount);
                        _rows = Mathf.CeilToInt(sqrRt);
                        _columns = Mathf.CeilToInt(sqrRt);
                        break;
                    }
            }

            if (_fitType == LayoutFitType.Width || _fitType == LayoutFitType.FixedColumns)
            {
                _rows = Mathf.CeilToInt(_childCount / (float)_columns);
            }

            if (_fitType == LayoutFitType.Height || _fitType == LayoutFitType.FixesRows)
            {
                _columns = Mathf.CeilToInt(_childCount / (float)_rows);
            }


            if (_boxAutoSizeX)
            {
                float totalWidth = CalculateTotalWidth();
                // Fit the Horizontal Size of the Grid Box based on the Cells
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, totalWidth);
            }

            if (_boxAutoSizeY)
            {
                float totalHeight = CalculateTotalHeight();
                // Fit the Vertical Size of the Grid Box based on the Cells
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, totalHeight);
            }

            // Get Grid Box Size
            float gridBoxWidth = rectTransform.rect.width;
            float gridBoxHeight = rectTransform.rect.height;

            // Set Cell Sizes
            float cellWidth = CalculateCellWidth(gridBoxWidth);
            float cellHeight = CalculateCellHeight(gridBoxHeight);

            if (_stretchX)
                SetCellSizeX(cellWidth);
            if (_stretchY)
                SetCellSizeY(cellHeight);

            //CellSize.y = StretchY ? cellHeight : GetCellSizeY();

            //if (LockXToY)
            //    cellWidth = cellHeight;
            //if (LockYToX)
            //    cellHeight = cellWidth;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                SetGridElement(i);
            }

        }

        private void SetCellSizeX(float newCellSize)
        {
            _cellSize.x = newCellSize;
        }
        private void SetCellSizeY(float newCellSize)
        {
            _cellSize.y = newCellSize;
        }

        private float CalculateTotalWidth()
        {
            return _cellSize.x * _columns + // Add each Individual Cell
                _spacing.x * (_columns - 1) + // Add the Spacing
                padding.left + padding.right; // Add the Padding
        }

        private float CalculateTotalHeight()
        {
            return _cellSize.y * _rows + // Add each Individual Cell
                _spacing.y * (_rows - 1) + // Add the Spacing
                padding.top + padding.bottom; // Add the Padding
        }

        private void SetGridElement(int i)
        {
            int rowCount = i / _columns;
            int columnCount = i % _columns;

            var xPos = (_cellSize.x * columnCount) + (_spacing.x * columnCount) + padding.left;
            var yPos = (_cellSize.y * rowCount) + (_spacing.y * rowCount) + padding.top;

            var item = rectChildren[i];
            SetChildAlongAxis(item, 0, xPos, _cellSize.x);
            SetChildAlongAxis(item, 1, yPos, _cellSize.y);
        }

        private float CalculateCellHeight(float gridBoxHeight)
        {
            if (_lockYToX)
                return _cellSize.x;
            else
                return (gridBoxHeight / _rows) - (_spacing.y / ((float)_rows / (_rows - 1))) - (padding.top / (float)_rows) - (padding.bottom / (float)_rows);
        }

        private float CalculateCellWidth(float gridBoxWidth)
        {
            if (_lockXToY)
                return _cellSize.y;
            else
                return (gridBoxWidth / _columns) - (_spacing.x / ((float)_columns / (_columns - 1))) - (padding.left / (float)_columns) - (padding.right / (float)_columns);
        }

        public void RefreshEditor()
        {
            CalculateLayoutInputVertical();
        }


        public override void SetLayoutHorizontal() { }
        public override void SetLayoutVertical() { }


        public enum LayoutFitType
        {
            Uniform,
            Width,
            Height,
            FixesRows,
            FixedColumns,
        }


    }

}