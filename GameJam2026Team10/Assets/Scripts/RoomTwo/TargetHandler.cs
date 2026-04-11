using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    private int[] correctOrder = { 1, 2, 3, 4 };
    private int currentStep = 0;

    public GameObject redRef;
    public GameObject greenRef;

    public Material greenMatPrefab;
    public Material blackMatPrefab;

    public GameObject doorRef;

    public void Enter(int number)
    {
        print("Entered " + number);
        if (number == correctOrder[currentStep])
        {
            currentStep++;

            if (currentStep >= correctOrder.Length)
            {
                CompletePuzzle();
            }
        }
        else
        {
            ResetAll();
        }
    }

    private void ResetAll()
    {
        currentStep = 0;
        print("Sequence Reset");
    }

    private void CompletePuzzle()
    {
        print("Correct Combination");
        // switch greenRef material to greenMatPrefab
        //switch redRef material to blackMatPrefab
        greenRef.GetComponent<Renderer>().material = greenMatPrefab;
        redRef.GetComponent<Renderer>().material = blackMatPrefab;
        //turn off light of redRef
        //turn on light of greenref
        greenRef.transform.Find("l").GetComponent<Light>().enabled = true;
        redRef.transform.Find("l").GetComponent<Light>().enabled = false;
        greenRef.GetComponent<AudioSource>().Play();

        doorRef.GetComponent<RoomTwoExitDoor>().OpenDoor();


        ResetAll();
    }
}