using UnityEngine;

public class FollowObjectWithoutRotation : MonoBehaviour
{
    [SerializeField] private Transform target; // Объект, за которым будет следить камера

    private Vector3 offset; // Расстояние между камерой и объектом

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Не задан объект для слежения!");
            return;
        }

        offset = transform.position - target.position; // Сохраняем начальное расстояние между камерой и объектом
    }

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        transform.position = target.position + offset; // Устанавливаем позицию камеры равной позиции объекта
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); // Сохраняем углы поворота камеры
    }
}