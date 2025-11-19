
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float projectileSpeed = 8;
    void Update()
    { 
       transform.Translate(Vector3.up* projectileSpeed * Time.deltaTime);
    }

    public void SetSpeed(float _speed) //metodo de apoio para puxar a variavel para outro script de arma e diferenciar a velocidade de disparo
    {
        projectileSpeed = _speed;
    }
}
