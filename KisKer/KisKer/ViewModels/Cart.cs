using KisKer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KisKer.ViewModels
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(AruKeszlet product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.AruID == product.AruID)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(
                    new CartLine { Product = product, AruMennyiseg = quantity });
            }
            else
            {
                line.AruMennyiseg += quantity;
            }
        }

        public void RemoveLine(AruKeszlet product)
        {
            lineCollection.RemoveAll(p => p.Product.AruID == product.AruID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(p => p.Product.EgysegAr * p.AruMennyiseg);
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }    
        public void SaveData()
        {
               
        }    
    }
}