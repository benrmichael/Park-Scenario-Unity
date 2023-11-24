using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR 
using UnityEditor;
#endif 

namespace CharacterPack
{
    public class CharacterVisuals : MonoBehaviour
    {
        public Material mainMaterial;
        
        public List<GameObject> hairs;
        public List<GameObject> eyebrows;
        public List<GameObject> beards;
        public List<GameObject> coats;

        [SerializeField, HideInInspector]
        int _currentHair = 0;
        [SerializeField, HideInInspector]
        int _currentEyebrow = 0;
        [SerializeField, HideInInspector]
        int _currentBeard = 0;
        [SerializeField, HideInInspector]
        int _currentCoat = 0;

        public int CurrentHair
        {
            get { return _currentHair; }
            set
            {
                _currentHair = value;
                if (_currentHair < 0) _currentHair = hairs.Count - 1;
                else if (_currentHair >= hairs.Count) _currentHair = 0;

                Refresh();
            }
        }

        public int CurrentEyebrow
        {
            get { return _currentEyebrow; }
            set
            {
                _currentEyebrow = value;
                if (_currentEyebrow < 0) _currentEyebrow = eyebrows.Count - 1;
                else if (_currentEyebrow >= eyebrows.Count) _currentEyebrow = 0;

                Refresh();
            }
        }

        public int CurrentBeard
        {
            get { return _currentBeard; }
            set
            {
                _currentBeard = value;
                if (_currentBeard < 0) _currentBeard = beards.Count - 1;
                else if (_currentBeard >= beards.Count) _currentBeard = 0;

                Refresh();
            }
        }

        public int CurrentCoat
        {
            get { return _currentCoat; }
            set
            {
                _currentCoat = value;
                if (_currentCoat < 0) _currentCoat = coats.Count - 1;
                else if (_currentCoat >= coats.Count) _currentCoat = 0;

                Refresh();
            }
        }

        void Refresh()
        {
            foreach (var hair in hairs) hair.SetActive(false);
            foreach (var eyebrow in eyebrows) eyebrow.SetActive(false);
            foreach (var beard in beards) beard.SetActive(false);
            foreach (var coat in coats) coat.SetActive(false);

            hairs[CurrentHair].SetActive(true);
            eyebrows[CurrentEyebrow].SetActive(true);
            beards[CurrentBeard].SetActive(true);
            coats[CurrentCoat].SetActive(true);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            var allRenderers = GetComponentsInChildren<Renderer>(true);
            foreach (var rend in allRenderers)
            {
                rend.sharedMaterial = mainMaterial;
            }
        }
#endif

    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CharacterVisuals))]
    public class CharacterVisualsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var cv = target as CharacterVisuals;

            EditorGUILayout.Separator();

            EditorGUILayout.BeginVertical(GUI.skin.box);

            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                if (GUILayout.Button("<"))
                    cv.CurrentHair--;

                EditorGUILayout.LabelField("Hair");

                if (GUILayout.Button(">"))
                    cv.CurrentHair++;
                EditorGUILayout.EndHorizontal();
            }

            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                if (GUILayout.Button("<"))
                    cv.CurrentEyebrow--;

                EditorGUILayout.LabelField("Eyebrow");

                if (GUILayout.Button(">"))
                    cv.CurrentEyebrow++;
                EditorGUILayout.EndHorizontal();
            }

            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                if (GUILayout.Button("<"))
                    cv.CurrentBeard--;

                EditorGUILayout.LabelField("Beard");

                if (GUILayout.Button(">"))
                    cv.CurrentBeard++;
                EditorGUILayout.EndHorizontal();
            }


            {
                EditorGUILayout.BeginHorizontal(GUI.skin.box);
                if (GUILayout.Button("<"))
                    cv.CurrentCoat--;

                EditorGUILayout.LabelField("Coat");

                if (GUILayout.Button(">"))
                    cv.CurrentCoat++;
                EditorGUILayout.EndHorizontal();
            }


            EditorGUILayout.EndVertical();
        }
    }

#endif
}
