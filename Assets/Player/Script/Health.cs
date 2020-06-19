using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite EmptyHeart;

    private void Update() {

        if(health/2 > numOfHearts) health = 2 * numOfHearts;
       
        for(int i = 0; i < hearts.Length; i++) {
            if(2 * i < health - 1) hearts[i].sprite = FullHeart;
            else if(2 * i == health - 1) hearts[i].sprite = HalfHeart;
            else hearts[i].sprite = EmptyHeart;

            if(i < numOfHearts) hearts[i].enabled = true;
            else hearts[i].enabled = false;
        }
    }
}
