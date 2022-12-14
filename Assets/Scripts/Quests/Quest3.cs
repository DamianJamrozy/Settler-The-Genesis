using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest3 : MonoBehaviour
{
    public static Quest3 Instance;

    public int inQuestCounter = 0;
    private int questNumber = 3;

    public GameObject toKill;

    public GameObject player;
    public TextMeshProUGUI questText;
    public TextMeshProUGUI questInfo;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (inQuestCounter == 4) return;
        else if ( Controller.Instance.questCounter == questNumber )
        {
            if(inQuestCounter == 0)
            {
                questInfo.text = "Może podejdę popatrzeć na zwierzęta, koło upraw widziałem zagrodę.";
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if (distance <= 1)
                {
                    questText.text = "Press Q to talk";
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        inQuestCounter = 1;
                        TextWriter.Instance.AddWriter("O NIE Dzikie zwierzę atakuje moje krowy, pomógłbyś mi go zwalczyć? Wydaje mi się, że słyszałem ryk nieopodal magicznych kryształów.", 0.1f);
                    }
                }else questText.text = "";
            }
            else if (inQuestCounter == 1)
            {
                questInfo.text = "Farmer poprisł mnie o pomoc, muszę pozbyć się dzikiego zwierza nieopodal kryształów.";
                if(toKill == null)
                {
                    inQuestCounter = 2;
                }else questText.text = "";
            }
            else if (inQuestCounter == 2)
            {
                questInfo.text = "Udało się pokonać dzikie zwierzę, wrócę przekazać farmerowi dobrą wiadomość.";
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if (distance <= 1)
                {
                    questText.text = "Press Q to talk";
                    if(Input.GetKeyDown(KeyCode.Q))
                    {
                        inQuestCounter = 3;
                        TextWriter.Instance.AddWriter("Coooo?!!?!?!?!?1 Zabiłeś mojego Kozła?!?!??!?!?!", 0.1f);
                    }
                }else questText.text = "";
            }
            if (inQuestCounter == 3)
            {
                questText.text = "";
                Controller.Instance.questCounter = 3;
                inQuestCounter = 4;
            } 
        }
    }
}
