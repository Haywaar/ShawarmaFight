using Zenject;

public class ShawarmaPool : MemoryPool<ShawarmaProp>
{
    protected override void OnSpawned(ShawarmaProp item)
    {
        item.gameObject.SetActive(true);
    }

    protected override void OnDespawned(ShawarmaProp item)
    {
        item.gameObject.SetActive(false);
    }
}