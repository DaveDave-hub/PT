using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dataa;

namespace Services
{
    public class ClothesCRUD
    {
        public ClothesCRUD()
        {

        }
       
        static public bool addClothes(int clothes_id, decimal clothes_price, string clothes_type)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {

                if (GetClothes(clothes_id) == null)
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
            return false;
        }


        static public bool deleteClothes(int clothes_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Clothes myClothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id);
                context.Clothes.DeleteOnSubmit(myClothes);
                context.SubmitChanges();
                return true;
            }
        }


        static public bool updatePrice(int clothes_id, decimal clothes_price)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Clothes myclothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id); ;
                myclothes.price = clothes_price;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool updateType(int clothes_id, string clothes_type)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                Clothes myclothes = context.Clothes.SingleOrDefault(clothes => clothes.id == clothes_id);
                myclothes.type = clothes_type;
                context.SubmitChanges();
                return true;
            }
        }

        static public Clothes GetClothes(int clothes_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (Clothes clothes in context.Clothes.ToList())
                {
                    if (clothes.id == clothes_id)
                    {
                        return clothes;
                    }
                }
                return null;
            }
        }


        static public List<Dictionary<string, string>> GetAllClothesInfo()

        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();
            List<Clothes> tempC = GetAllClothes().ToList();
            foreach (Clothes clothes in tempC)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add("id", clothes.id.ToString());
                temp.Add("price", clothes.price.ToString());
                temp.Add("type", clothes.type);

                returnList.Add(temp);
            }
            return returnList;
        }

        static public Dictionary<string, string> GetOneClotheInfo(int clothes_id)

        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            Clothes c = GetClothes(clothes_id);

            temp.Add("id", c.id.ToString());
            temp.Add("price", c.price.ToString());
            temp.Add("type", c.type);

            return temp;
        }

        static public IEnumerable<Clothes> GetAllClothes()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.Clothes.ToList();
                return result;
            }
        }

        static public IEnumerable<Clothes> GetClothesByType(string clothes_type)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<Clothes> result = new List<Clothes>();
                foreach (Clothes clothes in context.Clothes)
                {
                    if (clothes.type.Equals(clothes_type))
                    {
                        result.Add(clothes);
                    }
                }
                return result;
            }
        }




    }
}


