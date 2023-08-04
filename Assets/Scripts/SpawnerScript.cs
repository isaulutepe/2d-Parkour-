using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; //Yarat�lacak obje.
    [SerializeField] private float spawnRate; //Spawn olacak nesneler aras�ndaki s�re.
    private float timeSinceLastSpawn; //spawn olan nesnenin 1 saniyede �retilmesini kontrol etmek i�in kullan�l�r, bu de�er update i�inde Time.deltatime ile artt�r�l�r ve spawnRate de�erine e�it oldu�unda yeni nesne �retilir.
    public float objectLifetime = 5f; //Olu�turulan objenin silinece�i zaman.
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0f; //Her  saniyede �retim yapaca��ndan sacay� tekrar s�f�rlad�k.
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        GameObject obj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Destroy(obj, objectLifetime);
        //Bu kod, "objectToSpawn" adl� GameObject'i al�r, "transform.position" ile belirtilen konumda bir kopyas�n� olu�turur ve rotasyonu varsay�lan olarak ayarlar. Sonu� olarak, spawner, "objectToSpawn" adl� GameObject'in kopyalar�n� belirli aral�klarla sahneye ekleyerek nesne �retir.
        //daha sonra bellekte yer kaplamamak i�in 5 saniye sonra objeyi siler.
    }
}
