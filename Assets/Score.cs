using UnityEngine;

public class Score : MonoBehaviour
{
    public void EndLevel()
    {
        Cannon cannon = FindObjectOfType<Cannon>();
        if (cannon)
        {
            int numProjectiles = cannon.numProjectiles;
            //use this to determine how well the player did to determine score at end of level
            //Star rating depends on number of projectiles fired
        }
    }
}
