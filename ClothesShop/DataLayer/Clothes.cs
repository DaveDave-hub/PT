using System;
using DataLayer.API;

namespace DataLayer
{
    internal class Clothes :IClothes
    {
        private int ID;
        private double PRICE;
        private ClothesType CLOTHESTYPE;


        public Clothes(int _Id, double _Price, ClothesType _ClothesType)
        {
            ID = _Id;
            PRICE = _Price;
            CLOTHESTYPE = _ClothesType;
        }

        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }

        public double Price
        { 
            get { return PRICE; }
            set { PRICE = value;} 
        }

        public ClothesType ClothesType
        { 
            get { return CLOTHESTYPE; }
            set { CLOTHESTYPE = value; } 
        }
        }
}