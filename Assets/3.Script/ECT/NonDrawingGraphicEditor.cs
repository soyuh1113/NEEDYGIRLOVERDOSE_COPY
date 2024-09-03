using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CanEditMultipleObjects, CustomEditor(typeof(NonDrawingGraphic), false)]
public class NonDrawingGraphicEditor : GraphicEditor
{
	public override void OnInspectorGUI()
	{
		base.serializedObject.Update();
		EditorGUILayout.PropertyField(base.m_Script, new GUILayoutOption[0]);
		base.RaycastControlsGUI();
		base.serializedObject.ApplyModifiedProperties();
	}
}
