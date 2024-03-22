using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int threeStarsValue = 1;
    public int twoStarsValue = 2;
    public Text scoreDisplay;
    public Animator scoreAnimator;
    public int nextLevel = 0;

    public void EndLevel()
    {
        //scoreAnimator = FindObjectOfType<Animator>(); //How does it know to find the stars animator and not the CannonBase animator?
        Cannon cannon = FindObjectOfType<Cannon>();
        if (cannon)
        {
            int numProjectiles = cannon.numProjectiles;
            //use this to determine how well the player did to determine score at end of level
            //Star rating depends on number of projectiles fired
            if (numProjectiles == threeStarsValue)
            { 
                print("3 stars");
                scoreDisplay.text = "Three Stars!";
                scoreAnimator.SetInteger("Stars", 3);
            }
            else if (numProjectiles == twoStarsValue) 
            { 
                print("2 stars");
                scoreDisplay.text = "Two Stars.";
                scoreAnimator.SetInteger("Stars", 2);
            }
            else 
            { 
                print("1 star");
                scoreDisplay.text = "One Star :(";
                scoreAnimator.SetInteger("Stars", 1);
            }
            Invoke("NextLevel", 2);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
