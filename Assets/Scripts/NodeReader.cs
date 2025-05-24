using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XNode;

public class NodeReader : MonoBehaviour
{
    public TMP_Text dialog;
    public Sprite backgroundImage;
    public GameObject ImageGO;
    public NodeGraph graph;
    public BaseNode currentNode;
    public GameObject characterSheet;
    public TMP_Text buttonAText;
    public TMP_Text buttonBText;
    public GameObject buttonA;
    public GameObject buttonB;

    public GameObject nextButtonGO;

    void Start()
    {
        currentNode = GetStartNode();
        AdvanceDialog();
    }

    public BaseNode GetStartNode()
    {
        return graph.nodes.Find(node => node is BaseNode && node.name == "Start") as BaseNode;
    }

    public void DisplayNode(BaseNode node)
    {
        dialog.text = node.getDialogText();
        backgroundImage = node.getSprite();
        ImageGO.gameObject.GetComponent<Image>().sprite = backgroundImage;

        if (node is MultipleChoiceDialog)
        {
            buttonAText.text = "" + ((MultipleChoiceDialog)node).a;
            buttonBText.text = "" + ((MultipleChoiceDialog)node).b;

            buttonA.SetActive(true);
            buttonB.SetActive(true);

            nextButtonGO.SetActive(false);
        }
        else
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);

            nextButtonGO.SetActive(true);
        }
    }

    public void AdvanceDialog()
    {
        var nextNode = GetNextNode(currentNode);
        if (nextNode != null)
        {
            currentNode = nextNode;
            DisplayNode(currentNode);
        }
        else
        {
            Debug.Log("No next node found.");
        }
    }

    private BaseNode GetNextNode(BaseNode node)
    {
        if (node is MultipleChoiceDialog)
        {
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

            TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();

            if (buttonText.text == ("" + ((MultipleChoiceDialog)node).a))
            {
                return node.GetOutputPort("a").Connection.node as BaseNode;
            }
            if (buttonText.text == ("" + ((MultipleChoiceDialog)node).b))
            {
                return node.GetOutputPort("b").Connection.node as BaseNode;
            }
            return node.GetOutputPort("exit").Connection.node as BaseNode;
        }
        else if (node is AbilityCheckNode)
        {
            int d20 = Random.Range(1, 21);
            if (d20 + characterSheet.gameObject.GetComponent<CharacterStats>().survival >= ((AbilityCheckNode)node).getDC())
            {
                return node.GetOutputPort("success").Connection.node as BaseNode;
            }
            else
            {
                return node.GetOutputPort("failed").Connection.node as BaseNode;
            }
        }
        else
        {
            return currentNode.GetOutputPort("exit").Connection.node as BaseNode;

        }
    }
}
