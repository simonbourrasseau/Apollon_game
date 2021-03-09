using System.Collections;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public NPC npc;

    private bool isInRange;

    private int numberOfInteractions = 0;

    private bool isDialogOpen = false;

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E) && !isDialogOpen)
        {
            TriggerDialog();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            if (numberOfInteractions == 0)
            {
                TriggerDialog();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void TriggerDialog()
    {
        DialogManager.instance.StartDialog(npc, numberOfInteractions, this);
        isDialogOpen = true;
        if (numberOfInteractions < npc.dialogs.Length-1)
        {
            numberOfInteractions++;
        }
        
    }

    public void SetIsDialogOpen(bool value)
    {
        StartCoroutine(WaitJustABit(value));
    }

    public bool GetIsDialogOpen()
    {
        return this.isDialogOpen;
    }

    IEnumerator WaitJustABit(bool value)
    {
        yield return new WaitForSeconds(0.3f);
        this.isDialogOpen = value;
    }
}
