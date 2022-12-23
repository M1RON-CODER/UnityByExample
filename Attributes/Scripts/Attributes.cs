using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), SelectionBase] // The RequireComponent attribute automatically adds required components as dependencies.
                                                     // SelectionBase Add this attribute to a script class to mark its GameObject as a selection base object for Scene View picking.
public class Attributes : MonoBehaviour
{
    [HideInInspector] public string value01; // Makes a variable not show up in the inspector but be serialized.
    [Min(0)] public int value02; // Attribute used to make a float or int variable in a script be restricted to a specific minimum value.
    [Header("Title")] public string value03; // Use this PropertyAttribute to add a header above some fields in the Inspector.
    [Space(20)] public string value04; // Use this PropertyAttribute to add some spacing in the Inspector.
    [Multiline] public string value05; // Attribute to make a string be edited with a multi-line textfield.
    [Range(0f, 1f)] public float value06; // Attribute used to make a float or int variable in a script be restricted to a specific range.
    [TextArea(5, 7)] public string value07; // Attribute to make a string be edited with a height-flexible and scrollable text area.
                                            // Where 5 is the minimum amount of lines the text area will use.
                                            // 7 is the maximum amount of lines the text area can show before it starts using a scrollbar.
    [Tooltip("This is value")] public string value08; // Specify a tooltip for a field in the Inspector window.
    [SerializeField] private string _value09; // Force Unity to serialize a private field.
    [ContextMenuItem("Reset Value", "ResetValue10")] public int value10; // Use this attribute to add a context menu to a field that calls a named method.

    [ContextMenu("Add To Value 02 (+1)")] // The ContextMenu attribute allows you to add commands to the context menu.

    private void AddToValue02()
    {
        value02++;
    }
    
    private void ResetValue10()
    {
        value10 = 0;
    }
}