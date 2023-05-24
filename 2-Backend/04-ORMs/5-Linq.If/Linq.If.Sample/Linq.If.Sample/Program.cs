using Linq.If.Sample.Enums;
using Linq.If.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Linq.If;

namespace Linq.If.Sample
{
    class Program
    {
       

        static void Main(string[] args)
        {
            SearchAndSort_Old();
            SearchAndSort_New();
        }

        public static void SearchAndSort_Old()
        {
            DatabaseContext DatabaseContext = new DatabaseContext();

            ProductSearchAndSortModel SearchModel = new ProductSearchAndSortModel();
            SearchModel.ProductName = "Pandol";
            SearchModel.SortBy = 1;

            IQueryable<Product> Query = DatabaseContext.Products;

            if (!string.IsNullOrEmpty(SearchModel.ProductName))
            {
                Query = Query.Where(p => p.Name.Contains(SearchModel.ProductName));
            }

            if (SearchModel.ProductTypeId > 0)
            {
                Query = Query.Where(p => p.ProductTypeId == SearchModel.ProductTypeId);
            }

            if (SearchModel.CategoryId > 0)
            {
                Query = Query.Where(p => p.CategoryId == SearchModel.CategoryId);
            }

            if (SearchModel.SortBy == (long)ProductSortColumnsEnum.Quantity)
            {
                Query = Query.OrderByDescending(p => p.Quantity).ThenBy( p => p.ExpiryDate);
            }

            if (SearchModel.SortBy == (long)ProductSortColumnsEnum.Price)
            {
                Query = Query.OrderBy(p => p.Price);
            }

            List<Product> Result = Query.ToList();
            
            //1- Pandol 500 Tabs --> 10$
            //1- Pandol Extra Tabs --> 15$
        }

        public static void SearchAndSort_New()
        {
            DatabaseContext DatabaseContext = new DatabaseContext();

            ProductSearchAndSortModel SearchModel = new ProductSearchAndSortModel();
            SearchModel.ProductName = "Pandol";
            SearchModel.SortBy = 1;

            List<Product> Result = DatabaseContext.Products
                                       .WhereIf(
                                              !string.IsNullOrEmpty(SearchModel.ProductName),
                                              p => p.Name.Contains(SearchModel.ProductName)
                                       )
                                       .WhereIf(
                                              SearchModel.ProductTypeId > 0,
                                              p => p.ProductTypeId == SearchModel.ProductTypeId
                                       )
                                       .WhereIf(
                                              SearchModel.CategoryId > 0,
                                              p => p.CategoryId == SearchModel.CategoryId
                                       ).OrderByDescendingIf(
                                              SearchModel.SortBy == (long)ProductSortColumnsEnum.Quantity,
                                              p => p.Quantity
                                       )
                                       .ThenByIf(
                                              SearchModel.SortBy == (long)ProductSortColumnsEnum.Quantity,
                                              p => p.ExpiryDate
                                       )
                                       .OrderByIf(
                                             SearchModel.SortBy == (long)ProductSortColumnsEnum.Price,
                                             p => p.Price
                                       ).ToList();


            //1- Pandol 500 Tabs --> 10$
            //1- Pandol Extra Tabs --> 15$
        }
    }
}
