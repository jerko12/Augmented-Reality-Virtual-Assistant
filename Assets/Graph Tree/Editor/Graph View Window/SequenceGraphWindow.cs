using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Callbacks;
using System;

public class SequenceGraphWindow : EditorWindow
{
    SequenceTreeView treeview;
    InspectorView inspectorView;

    [MenuItem("Sequence/Sequence Editor")]
    public static void OpenWindow()
    {
        SequenceGraphWindow wnd = GetWindow<SequenceGraphWindow>();
        wnd.titleContent = new GUIContent("SequenceGraphWindow");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceID, int line)
    {
        if(Selection.activeObject is SequenceTree)
        {
            OpenWindow();
            return true;
        }
        return false;
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Graph Tree/Editor/Graph View Window/SequenceGraphWindow.uxml");
        //VisualElement labelFromUXML = visualTree.Instantiate();
        //root.Add(labelFromUXML);
        visualTree.CloneTree(root);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Graph Tree/Editor/Graph View Window/SequenceGraphWindow.uss");
       
        root.styleSheets.Add(styleSheet);

        treeview = root.Q<SequenceTreeView>();
        inspectorView = root.Q<InspectorView>();

        treeview.onNodeSelected = OnNodeSelectionChanged;

        OnSelectionChange();
    }

    private void OnEnable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }
    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
    }

    private void OnPlayModeStateChanged(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredEditMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingEditMode:
                break;
            case PlayModeStateChange.EnteredPlayMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingPlayMode:
                break;
        }
    }



    private void OnSelectionChange()
    {
        SequenceTree tree = Selection.activeObject as SequenceTree;

        if (!tree)
        {
            if (Selection.activeGameObject)
            {
                SequenceRunner runner = Selection.activeGameObject.GetComponent<SequenceRunner>();
                if (runner)
                {
                    tree = runner.tree;
                }
            }
        }
        if (Application.isPlaying)
        {
            if (tree)
            {
                treeview.Populate(tree);
            }
        }
        else if(tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
        {
            treeview.Populate(tree);
        }
    }

    void OnNodeSelectionChanged(NodeView node)
    {
        inspectorView.UpdateSelection(node);
    }

    private void OnInspectorUpdate()
    {
        treeview?.UpdateNodeStates();
    }
}