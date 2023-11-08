using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LearnedMoveEditor : Editor
{

    [CustomEditor(typeof(LearnedMove))]
    public class YourScriptEditor : Editor
    {
        public string[] positon { get; private set; } = {"Custom","Park", "Fire", "Vehicle"};
        public int selectedPositonIndex { get; private set; } = 0;
        
        
        public override void OnInspectorGUI()
        {

            LearnedMove targetMove = (LearnedMove)target;
            DrawDefaultInspector();

            selectedPositonIndex = EditorGUILayout.Popup("Position", selectedPositonIndex, positon);

            string selectedOption = positon[selectedPositonIndex];
            targetMove.selectedIndex = selectedPositonIndex;
        }
    }
}
