using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.API;
using Data.Model;

namespace Data.DataRepository
{
    public class ClothesCRUD : IClothesDataLayerAPI
    {
        private DataClasses1DataContext context;

        public ClothesCRUD(DataClasses1DataContext context = default)
        {
            this.context = context ?? new DataClasses1DataContext();
        }

        private IClothes Transform(Clothes clothes)
        {
            return new Clothes(clothes.id, clothes.price, clothes.type);
        }

        public bool addClothes(int clothes_id, decimal clothes_price, string clothes_type)
        {
            if (GetClothes(clothes_id) != null) return false;
                {
                    Clothes newClothes = new Clothes
                    {
                        id = clothes_id,
                        price = clothes_price,
                        type = clothes_type,

                    };
                    context.Clothes.InsertOnSubmit(newClothes);
                    context.SubmitChanges();

                    return true;
                }
        }


         public bool deleteClothes(int clothes_id)
        {
            {
                Clothes myClothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id);
                if (clothes == null) return false;

                context.Clothes.DeleteOnSubmit(myClothes);
                context.SubmitChanges();
                return true;
            }
        }


        public bool updatePrice(int clothes_id, decimal clothes_price)
        {
            {
                Clothes myclothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id);
                if (clothes == null) return false;

                myclothes.price = clothes_price;
                context.SubmitChanges();
                return true;
            }
        }

        public bool updateType(int clothes_id, string clothes_type)
        {
            {
                Clothes myclothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id);
                if (clothes == null) return false;

                myclothes.type = clothes_type;
                context.SubmitChanges();
                return true;
            }
        }

        public IClothes GetClothes(int clothes_id)
        {
            {
                foreach (Clothes clothes in context.Clothes)
                {
                    if (clothes.id == clothes_id)
                    {
                        return Transform(clothes);
                    }
                }
                return null;
            }
        }


      

   
        public IEnumerable<IClothes> GetAllClothes()
        {
            List<Clothes> clothes = context.Clothes.ToList();
            List<IClothes> result = new List<IClothes>();

            foreach (Clothes clothes in clothes)
            {
                result.Add(Transform(clothes));
            }
        }

     
    }
}


