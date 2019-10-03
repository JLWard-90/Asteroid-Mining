using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;
    Editor shapeEditor;
    Editor colourEditor;

    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                planet.GeneratePlanet();
            }
        }

        if (GUILayout.Button("Generate Planet"))
        {
            planet.GeneratePlanet();
        }
        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout, ref shapeEditor);
        DrawSettingsEditor(planet.colourSettings, planet.OnColourSettingsUpdated, ref planet.colourSettingsFoldout, ref colourEditor);
    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor) //Passing in a System.Action allows method to be called. ref keyword allows the reference to the specific value from planet to be parsed and updated
    {
        if (settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings); //Adds a title to the GUI element in the inspector. Everything to do with foldout allows the foldout arrow on the top-left of the gui to work
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if(foldout)
                {
                    CreateCachedEditor(settings, null, ref editor); //Only creates a new editor when it has to
                    editor.OnInspectorGUI(); 

                    if (check.changed)
                    {
                        if(onSettingsUpdated != null)
                        {
                            onSettingsUpdated();
                        }
                    }
                }
                
            }
        }
        
    }

    private void OnEnable() 
    {
        planet = (Planet)target;
    }
}
