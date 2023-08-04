using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn; //Yaratýlacak obje.
    [SerializeField] private float spawnRate; //Spawn olacak nesneler arasýndaki süre.
    private float timeSinceLastSpawn; //spawn olan nesnenin 1 saniyede üretilmesini kontrol etmek için kullanýlýr, bu deðer update içinde Time.deltatime ile arttýrýlýr ve spawnRate deðerine eþit olduðunda yeni nesne üretilir.
    public float objectLifetime = 5f; //Oluþturulan objenin silineceði zaman.
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0f; //Her  saniyede üretim yapacaðýndan sacayý tekrar sýfýrladýk.
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        GameObject obj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Destroy(obj, objectLifetime);
        //Bu kod, "objectToSpawn" adlý GameObject'i alýr, "transform.position" ile belirtilen konumda bir kopyasýný oluþturur ve rotasyonu varsayýlan olarak ayarlar. Sonuç olarak, spawner, "objectToSpawn" adlý GameObject'in kopyalarýný belirli aralýklarla sahneye ekleyerek nesne üretir.
        //daha sonra bellekte yer kaplamamak için 5 saniye sonra objeyi siler.
    }
}
