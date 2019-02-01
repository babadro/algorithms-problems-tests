using System;
using System.Linq;
using System.Collections.Generic;

namespace _02_JoinSample
{
    
    class Program
    {

        #region Data

        class Product
        {
            public string Name { get; set; }
            public int CategoryID { get; set; }
        }

        class Category
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        // Specify the first data source.
        List<Category> categories = new List<Category>()
       {
           new Category(){Name="Beverages", ID=001},
           new Category(){ Name="Condiments", ID=002},
           new Category(){ Name="Vegetables", ID=003},
           new Category() {  Name="Grains", ID=004},
           new Category() {  Name="Fruit", ID=005}
       };

        // Specify the second data source.
        List<Product> products = new List<Product>()
      {
         new Product{Name="Cola",  CategoryID=001},
         new Product{Name="Tea",  CategoryID=001},
         new Product{Name="Mustard", CategoryID=002},
         new Product{Name="Pickles", CategoryID=002},
         new Product{Name="Carrots", CategoryID=003},
         new Product{Name="Bok Choy", CategoryID=003},
         new Product{Name="Peaches", CategoryID=005},
         new Product{Name="Melons", CategoryID=005},
       };
        #endregion
        static void Main(string[] args)
        {
            var app = new Program();


            Console.WriteLine("Hello World!");
        }

        void InnerJoin()
        {
            var innerJoinQuery =
                from category in categories
                join prod in products on category.ID equals prod.CategoryID
                select new { Category = category.ID, Product = prod.Name };
        }

        void GroupInnerJoin()
        {
            var groupJoinQuery2 =
                from category in categories
                orderby category.ID
                join prod in products on category.ID equals prod.CategoryID into prodGroup
                select prodGroup;


        }
    }
}
