using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XNode;

public class NodeReader : MonoBehaviour
{
    public GameObject actorImageGO;
    private AudioSource bgmSource;
    public AudioClip suspenseClip;
    public AudioClip adventureClip;
    public AudioClip dramaClip;
    public AudioClip happyClip;
    public TMP_Text dialog;
    public Sprite backgroundImage;
    public GameObject ImageGO;
    public NodeGraph graph;
    public BaseNode currentNode;
    public GameObject characterSheet;
    public TMP_Text buttonAText;
    public TMP_Text buttonBText;
    public TMP_Text buttonCText;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject nextButtonGO;

    void Start()
    {
        // Get the first AudioSource in the scene
        bgmSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        if (bgmSource == null)
        {
            Debug.LogWarning("No AudioSource found in the scene!");
        }
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

        if (node is TwoChoiceDialog)
        {
            buttonAText.text = "" + ((TwoChoiceDialog)node).a;
            buttonBText.text = "" + ((TwoChoiceDialog)node).b;

            buttonA.SetActive(true);
            buttonB.SetActive(true);
            buttonC.SetActive(false);
            nextButtonGO.SetActive(false);
        }
        else if (node is ThreeChoiceDialog)
        {
            buttonAText.text = "" + ((ThreeChoiceDialog)node).a;
            buttonBText.text = "" + ((ThreeChoiceDialog)node).b;
            buttonCText.text = "" + ((ThreeChoiceDialog)node).c;
            buttonA.SetActive(true);
            buttonB.SetActive(true);
            buttonC.SetActive(true);
            nextButtonGO.SetActive(false);
        }
        else if (node is SimpleDialogV2)
        {
            var dialogNode = (SimpleDialogV2)node;

            dialog.text = dialogNode.getDialogText();
            ImageGO.GetComponent<Image>().sprite = dialogNode.getSprite();

            Image actorImage = actorImageGO.GetComponent<Image>();

            if (dialogNode.getActorSprite() != null)
            {
                actorImage.sprite = dialogNode.getActorSprite();
                actorImageGO.SetActive(true);

                if (dialogNode.shouldSlide())
                {
                    actorImageGO.transform.localPosition = new Vector3(-540, 0, 0);
                    LeanTween.moveLocalX(actorImageGO, 0f, 1f);
                }
                else
                {
                    actorImageGO.transform.localPosition = new Vector3(-540, 0, 0);
                }
            }
            else
            {
                actorImageGO.SetActive(false);
            }


            PlayBGM(dialogNode.getBGM());

            buttonA.SetActive(false);
            buttonB.SetActive(false);
            buttonC.SetActive(false);
            nextButtonGO.SetActive(true);
        }
        else
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);
            buttonC.SetActive(false);

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
        if (node is TwoChoiceDialog)
        {
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

            TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();

            if (buttonText.text == ("" + ((TwoChoiceDialog)node).a))
            {
                return node.GetOutputPort("a").Connection.node as BaseNode;
            }
            if (buttonText.text == ("" + ((TwoChoiceDialog)node).b))
            {
                return node.GetOutputPort("b").Connection.node as BaseNode;
            }
            return node.GetOutputPort("exit").Connection.node as BaseNode;
        }
        else if (node is ThreeChoiceDialog)
        {
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

            TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();

            if (buttonText.text == ("" + ((ThreeChoiceDialog)node).a))
            {
                return node.GetOutputPort("a").Connection.node as BaseNode;
            }
            if (buttonText.text == ("" + ((ThreeChoiceDialog)node).b))
            {
                return node.GetOutputPort("b").Connection.node as BaseNode;
            }
            if (buttonText.text == ("" + ((ThreeChoiceDialog)node).c))
            {
                return node.GetOutputPort("c").Connection.node as BaseNode;
            }
            return node.GetOutputPort("exit").Connection.node as BaseNode;
        }
        else if (node is AbilityCheckNode)
        {
            ABILITY currentAbility = ((AbilityCheckNode)node).getAbility();
            switch (currentAbility)
            {
                case ABILITY.ACROBATICS:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().acrobatics);
                case ABILITY.ATHLETICS:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().athletics);
                case ABILITY.DATABASE:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().database);
                case ABILITY.DOMINATION:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().domination);
                case ABILITY.ELOQUENCE:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().eloquence);
                case ABILITY.INSTINCT:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().instinct);
                case ABILITY.SENSORY:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().sensory);
                case ABILITY.STEALTH:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().stealth);
                case ABILITY.TECHNOLOGY:
                    return CheckAbility(node, characterSheet.gameObject.GetComponent<CharacterStats>().technology);
                default:
                    return null;
            }
        }
        else
        {
            return currentNode.GetOutputPort("exit").Connection.node as BaseNode;

        }
    }

    private BaseNode CheckAbility(BaseNode node, float abilityNumber)
    {
        int d20 = Random.Range(1, 21);
        if (d20 + abilityNumber >= ((AbilityCheckNode)node).getDC())
        {
            return node.GetOutputPort("success").Connection.node as BaseNode;
        }
        else
        {
            return node.GetOutputPort("failed").Connection.node as BaseNode;
        }
    }


    void PlayBGM(BGM bgm)
    {
        switch (bgm)
        {
            case BGM.SUSPENSE:
                bgmSource.clip = suspenseClip;
                break;
            case BGM.ADVENTURE:
                bgmSource.clip = adventureClip;
                break;
            case BGM.DRAMA:
                bgmSource.clip = dramaClip;
                break;
            case BGM.HAPPY:
                bgmSource.clip = happyClip;
                break;
        }

        if (bgmSource.clip != null)
            bgmSource.Play();
    }
}
