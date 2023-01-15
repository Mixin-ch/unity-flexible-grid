/*using UnityEditor;
using UnityEngine;

namespace Mixin.FlexibleGrid.Editor
{
    [CustomEditor(typeof(FlexibleGrid))]
    [ExecuteInEditMode]
    public class FlexibleGridEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            FlexibleGrid grid = (FlexibleGrid)target;

            // Show the Columns Field
            if (grid._fitType == FlexibleGrid.LayoutFitType.FixedColumns)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Columns", GUILayout.MaxWidth(60));
                grid._columns = EditorGUILayout.IntField(grid._columns, GUILayout.MaxWidth(30));

                if (MixinGUI.PlusButton())
                    grid._columns++;

                if (MixinGUI.MinusButton())
                    grid._columns--;

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
            }

            // Show the Rows Field
            if (grid._fitType == FlexibleGrid.LayoutFitType.FixesRows)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Rows", GUILayout.MaxWidth(60));
                grid._rows = EditorGUILayout.IntField(grid._rows, GUILayout.MaxWidth(30));

                if (MixinGUI.PlusButton())
                    grid._rows++;

                if (MixinGUI.MinusButton())
                    grid._rows--;

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
            }

            EditorGUILayout.BeginHorizontal();
            if (!grid._stretchX)
                grid._boxAutoSizeX = EditorGUILayout.Toggle("Box Auto Size X", grid._boxAutoSizeX);
            else
                grid._boxAutoSizeX = EditorGUILayout.Toggle("Box Auto Size X", false);

            if (!grid._stretchY)
                grid._boxAutoSizeY = EditorGUILayout.ToggleLeft("Box Auto Size Y", grid._boxAutoSizeY);
            else
                grid._boxAutoSizeY = false;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (!grid._boxAutoSizeX)
                grid._stretchX = EditorGUILayout.Toggle("Stretch X", grid._stretchX);
            else
                grid._stretchX = EditorGUILayout.Toggle("Stretch X", false);

            if (!grid._boxAutoSizeY)
                grid._stretchY = EditorGUILayout.ToggleLeft("Stretch Y", grid._stretchY);
            else
                grid._stretchY = false;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (!grid._lockYToX)
                grid._lockXToY = EditorGUILayout.Toggle("Lock X to Y", grid._lockXToY);
            else
                grid._lockXToY = EditorGUILayout.Toggle("Lock X to Y", false);

            if (!grid._lockXToY)
                grid._lockYToX = EditorGUILayout.ToggleLeft("Lock Y to X", grid._lockYToX);
            else
                grid._lockYToX = false;
            EditorGUILayout.EndHorizontal();


            // Handle Realtime Changes
            if (EditorGUI.EndChangeCheck())
                grid.CalculateLayoutInputVertical();

        }



    }


}

*/