using UnityEngine;

public class Counter
{
    private float countdown;
    private bool counting;

    public void StartCountdown(int startingCount)
    {
        countdown = startingCount;
        counting = true;
    }

    public string Update()
    {
        if (counting)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                countdown = 0f;
                counting = false;
                return "Elveda";
            }
            else
            {
                return "" + Mathf.Ceil(countdown); 
            }
        }
        else
        {
            GameManager.Instance.Ending(false);
            return null;
        }
    }
}