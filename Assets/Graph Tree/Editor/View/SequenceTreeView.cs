using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using System;
using System.Linq;

public class SequenceTreeView : GraphView
{
    public Action<NodeView> onNodeSelected;
    public new class UxmlFactory : UxmlFactory<SequenceTreeView, GraphView.UxmlTraits> { }
    SequenceTree tree;
    public SequenceTreeView()
    {
        Insert(0, new GridBackground());

        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());
        

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Graph Tree/Editor/Graph View Window/SequenceGraphWindow.uss");
        styleSheets.Add(styleSheet);

        Undo.undoRedoPerformed += OnUndoRedo;
    }

    private void OnUndoRedo()
    {
        Populate(tree);
        AssetDatabase.SaveAssets();
    }

    NodeView FindNodeView(Node node)
    {
        return GetNodeByGuid(node.guid) as NodeView;
    }

    internal void Populate(SequenceTree tree)
    {
        this.tree = tree;

        graphViewChanged -= OnGraphViewChanged;
        DeleteElements(graphElements);
        graphViewChanged += OnGraphViewChanged;

        //if there is no root node. Create one.
        if(tree.rootNode == null)
        {
            tree.rootNode = tree.CreateNode(typeof(RootNode)) as RootNode;
            EditorUtility.SetDirty(tree);
            AssetDatabase.SaveAssets();
        }

        // Creates the node views
        tree.nodes.ForEach(n => CreateNodeView(n));
        
        // Creates the edges
        tree.nodes.ForEach(n => {
            var children = tree.GetChildren(n);
            children.ForEach(c =>
            {
                NodeView parentView = FindNodeView(n);
                NodeView childView = FindNodeView(c);

                Edge edge = parentView.output.ConnectTo(childView.input);
                AddElement(edge);
            });
        });
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        return ports.ToList().Where(endPort =>
        endPort.direction != startPort.direction &&
        endPort.node != startPort.node).ToList();
        //return base.GetCompatiblePorts(startPort, nodeAdapter);
    }

    private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
    {
        if(graphViewChange.elementsToRemove != null)
        {
            graphViewChange.elementsToRemove.ForEach(elem =>
            {
                NodeView nodeView = elem as NodeView;
                if(nodeView != null)
                {
                    tree.DeleteNode(nodeView.node);
                }

                // Removing Edges of a node
                Edge edge = elem as Edge;
                if (edge != null)
                {
                    NodeView parentView = edge.output.node as NodeView;
                    NodeView childView = edge.input.node as NodeView;
                    tree.RemoveChild(parentView.node,childView.node);
                }
            });
        }

        // Adding Edges to a node
        if(graphViewChange.edgesToCreate != null)
        {
            graphViewChange.edgesToCreate.ForEach(edge =>
            {
                NodeView parentView = edge.output.node as NodeView;
                NodeView childView = edge.input.node as NodeView;
                tree.AddChild(parentView.node, childView.node);
            });
        }

        // sort the order the nodes are executed
        if(graphViewChange.movedElements != null)
        {
            nodes.ForEach((n) =>
            {
                NodeView view = n as NodeView;
                view.SortChildren();
            });
        }

        return graphViewChange;
    }

    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        //base.BuildContextualMenu(evt);
        {
            var types = TypeCache.GetTypesDerivedFrom<ActionNode>();
            foreach(var type in types)
            {
                evt.menu.AppendAction($"[{type.BaseType.Name}]/{type.Name}", (a) => CreateNode(type));
            }
        }

        {
            var types = TypeCache.GetTypesDerivedFrom<CompositeNode>();
            foreach (var type in types)
            {
                evt.menu.AppendAction($"[{type.BaseType.Name}]/{type.Name}", (a) => CreateNode(type));
            }
        }

        {
            var types = TypeCache.GetTypesDerivedFrom<DecoratorNode>();
            foreach (var type in types)
            {
                evt.menu.AppendAction($"[{type.BaseType.Name}]/{type.Name}", (a) => CreateNode(type));
            }
        }
    }

    public void CreateNode(System.Type type)
    {
        Node node = tree.CreateNode(type);
        CreateNodeView(node);
    }

    public void CreateNodeView(Node node)
    {
        NodeView nodeView = new NodeView(node);
        nodeView.onNodeSelected = onNodeSelected;
        AddElement(nodeView);
    }

    public void UpdateNodeStates()
    {
        nodes.ForEach(n => {
            NodeView view = n as NodeView;
            view.UpdateState();
        });
    }
}
