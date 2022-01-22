using UnityEngine;

public class ChangeUnitSprite : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite bulletShotSprite;
    [SerializeField] private Sprite bulletTravellingSprite;
    [SerializeField] private Sprite bulletImpactSprite;

    //[SerializeField] private GameObject unit;

    public void BulletShot()
    {

        GameObject bullet = gameObject;

        GameObject unit = bullet.transform.parent.gameObject;
        
        SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
        
        spriteRenderer.sprite = bulletShotSprite;

    }

    public void BulletTravelling()
    {
        
        GameObject bullet = gameObject;
        
        GameObject unit = bullet.transform.parent.gameObject;
        
        SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = bulletTravellingSprite;

    }

    public void BulletImpact()
    {
        
        GameObject bullet = gameObject;
        
        GameObject unit = bullet.transform.parent.gameObject;
        
        SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = bulletImpactSprite;

    }

}