using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public static TalkManager TM;
    void Awake()
    {
        if (TM != null)
            Destroy(this);

        TM = this;
    }

    [SerializeField] GameObject talkUI;
    [SerializeField] TextMeshProUGUI textBox;
    List<StringBuilder> textList = new List<StringBuilder>();
    int CurrentTxt;

    public void StartTalk(NpcType npcType)
    {
        InputKeyMasterManager.IMM.ChangeTalkActionMap();
        talkUI.SetActive(true);
        textList.Clear();
        CurrentTxt = 0;

        AddText(npcType);
        RenderText();

        InputKeyMasterManager.IMM.OnNextTalkEventHandller -= RenderText;
        InputKeyMasterManager.IMM.OnNextTalkEventHandller += RenderText;
    }
    public void EndTalk()
    {
        InputKeyMasterManager.IMM.OnNextTalkEventHandller -= RenderText;
        InputKeyMasterManager.IMM.ChangeUnitActionMap();
        CurrentTxt = 0;
        talkUI.SetActive(false);
    }

    void RenderText()
    {
        if (CurrentTxt >= textList.Count)
        {
            EndTalk();
            return;
        }

        textBox.text = textList[CurrentTxt].ToString();
        CurrentTxt++;
    }

    void AddText(NpcType npcType)
    {
        switch (npcType)
        {
            case NpcType.Tutor1:
                Tutur1Text();
                break;
            case NpcType.Student1:
                Student1Text();
                break;
        }
    }

    void Tutur1Text()
    {
        textList.Add(new StringBuilder($"{GameManager.GM.player.GetComponent<Player>().Name}�� �ȳ��ϼ���.\n"));
        textList[0].AppendLine($"�ñ��Ͻ� ���� �����ʴϱ�?");
        textList.Add(new StringBuilder("(��������Ʈ�� ���� ����ϴ� ���� �����!)"));
        textList.Add(new StringBuilder("Ʃ�ʹ� Ȥ��..."));
        textList.Add(new StringBuilder("���ǰ���?? ������ ���������̽��ϴ�"));
        textList.Add(new StringBuilder("(...�����ؼ� ���� �߸� �ع��ȴ� ��������)"));

    }
    void Student1Text()
    {
        textList.Add(new StringBuilder($"{GameManager.GM.player.GetComponent<Player>().Name}�� TIL�����̳���?.\n"));
        textList[0].AppendLine($"���� ���� ��õ�޾ƿ�.");
        textList.Add(new StringBuilder($"�׷� �� ���ô�."));
    }
}
