using UnityEngine;

public static class InitMaker
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        Object.Instantiate(Resources.Load("kosmiojj90df"));
    }
}