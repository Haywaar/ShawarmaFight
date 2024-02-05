using System;

public class ItemUsedSignal
{
    public readonly ItemModel ItemModel;

    public ItemUsedSignal(ItemModel itemModel)
    {
        ItemModel = itemModel;
    }
}