using CharacterInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPosition;
    [SerializeField] private SpriteRenderer characterRenderer;

    private Vector2 _aimDirection = Vector2.right;
    public GameObject Bullet;
    private Characters characters;
    private TopDownController _controller;
    void Awake()
    {
        _controller = GetComponent<TopDownController>();
        //TODO : 나중에 지워야함
        Managers.User.Init();
    }
    void Start()
    {
        _controller.OnLookEvent += OnAim;
        characters = Managers.User.characterInfo;
        this.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/InGame/" + Managers.User.characterInfo.Img);
        StartCoroutine(COInstantiateBullet());
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RotateAim(newAimDirection);
    }

    private void RotateAim(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        projectileSpawnPosition.rotation = Quaternion.Euler(0, 0, rotZ - 90);

    }
    IEnumerator COInstantiateBullet()
    {
        while(true)
        {
            GameObject bullet = Instantiate(Bullet, projectileSpawnPosition.position, projectileSpawnPosition.rotation);
            bullet.transform.localScale = new Vector3(characters.ProjectileSize, characters.ProjectileSize, 1);
            yield return new WaitForSeconds(characters.AttackSpeed);
        }
    }
}
