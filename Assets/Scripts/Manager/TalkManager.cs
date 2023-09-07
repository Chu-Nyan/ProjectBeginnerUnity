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
        textList.Add(new StringBuilder($"{GameManager.GM.player.GetComponent<Player>().Name}님 안녕하세요.\n"));
        textList[0].AppendLine($"궁금하신 것이 있으십니까?");
        textList.Add(new StringBuilder("(델리게이트는 언제 사용하는 건지 물어보자!)"));
        textList.Add(new StringBuilder("튜터님 혹시..."));
        textList.Add(new StringBuilder("사용건가요?? 언제는 델리스파이스하는"));
        textList.Add(new StringBuilder("(...긴장해서 말을 잘못 해버렸다 도망가자)"));

    }
    void Student1Text()
    {
        textList.Add(new StringBuilder($"{GameManager.GM.player.GetComponent<Player>().Name}님 TIL적으셨나요?.\n"));
        textList[0].AppendLine($"오늘 주제 추천받아요.");
        textList.Add(new StringBuilder($"그럼 또 봅시다."));
    }
}
