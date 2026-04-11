using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    private int[] correctOrder = { 1, 2, 3, 4 };
    private int currentStep = 0;

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
        ResetAll();
    }
}