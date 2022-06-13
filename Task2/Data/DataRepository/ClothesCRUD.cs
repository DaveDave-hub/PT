using System.Collections.Generic;
using System.Linq;
using Data.API;

namespace Data.DataRepository;

public class ClothesCRUD : IClothesDataLayerAPI
{
    private DataClasses1DataContext context;

    public ClothesCRUD(DataClasses1DataContext context = default)
    {
        this.context = context ?? new DataClasses1DataContext();
    }

    private IClothes Transform(Clothes clothes)
    {
        return new Model.Clothes(clothes.id, clothes.price, clothes.type);
    }

    public bool AddClothes(int clothes_id, int clothes_price, string clothes_type)
    {
        if (GetClothes(clothes_id) != null) return false;
        var newClothes = new Clothes
        {
            id = clothes_id,
            price = clothes_price,
            type = clothes_type
        };
        context.Clothes.InsertOnSubmit(newClothes);
        context.SubmitChanges();

        return true;
    }


    public bool DeleteClothes(int clothes_id)
    {
        Clothes myClothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id);
        if (myClothes == null) return false;

        context.Clothes.DeleteOnSubmit(myClothes);
        context.SubmitChanges();
        return true;
    }


    public bool Update(int clothes_id, int clothes_price, string clothes_type)
    {
        Clothes myclothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id);
        if (myclothes == null) return false;

        myclothes.price = clothes_price;
        myclothes.type = clothes_type;

        context.SubmitChanges();

        return true;
    }
        
    public IClothes GetClothes(int clothes_id)
    {
        var clothesDatabase = (from clothes in context.Clothes where clothes.id == clothes_id select clothes).FirstOrDefault();
        return clothesDatabase != null ? Transform(clothesDatabase) : null;
    }
        
    public IEnumerable<IClothes> GetAllClothes()
    {
        List<Clothes> clothes = context.Clothes.ToList();
        List<IClothes> result = new();

        foreach (Clothes cloth in clothes)
        {
            result.Add(Transform(cloth));
        }

        return result;
    }
}