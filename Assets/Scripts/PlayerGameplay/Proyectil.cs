using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float velocidad ;
    [SerializeField] private int da�o ;
    private Vector2 direccion;

    public void Inicializar(Vector2 direccionLanzamiento, int da�oEntrada)
    {
        direccion = direccionLanzamiento.normalized;
        da�o = da�oEntrada;
        Destroy(gameObject, 5f); // Se destruye si no impacta en 5s
    }

    void Update()
    {
        transform.Translate(direccion * 10f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out VidaEnemigo enemigo))
        {
            enemigo.TomarDa�o(da�o);
        }

        Destroy(gameObject);
    }
}
