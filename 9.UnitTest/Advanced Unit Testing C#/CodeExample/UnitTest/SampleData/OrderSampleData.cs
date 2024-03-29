﻿using API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.SampleData
{
    public class OrderSampleData
    {
        //public static IEnumerable<int> EnumerableInt 
        //{ get 
        //    {
        //        return new int[] {
        //        1, 2, 3, 4
        //        };
        //    } 
        //}
        public static IEnumerable<ValidatedOrderItem> ValidOrdersData {
            get
            {
                return new ValidatedOrderItem[]
                {
                    new ValidatedOrderItem {
                        Id = 1,
                        IdBuyer = 3,
                        IdProduct = 6,
                        ProductAmount = 34,
                        TotalPrice = 1000,
                        IsPayed = false,
                        IsDelivered = false,
                        IsActive = true,
                        InsertDate = DateTime.Now.AddDays(-1),
                        UpdateDate = null,
                        IsValid = true
                    },
                    new ValidatedOrderItem {
                        Id = 2,
                        IdBuyer = 3,
                        IdProduct = 8,
                        ProductAmount = 324,
                        TotalPrice = 1300,
                        IsPayed = true,
                        IsDelivered = false,
                        IsActive = true,
                        InsertDate = DateTime.Now.AddDays(-3),
                        UpdateDate = null,
                        IsValid = true
                    },
                    new ValidatedOrderItem {
                        Id = 3,
                        IdBuyer = 10,
                        IdProduct = 8,
                        ProductAmount = 1,
                        TotalPrice = 0,
                        IsPayed = true,
                        IsDelivered = false,
                        IsActive = true,
                        InsertDate = DateTime.Now.AddDays(-3),
                        UpdateDate = null,
                        IsValid = true
                    }
                };
            }
        }
        public static IEnumerable<ValidatedOrderItem> InvalidOrdersData
        {
            get
            {
                return new ValidatedOrderItem[]
                {
                    new ValidatedOrderItem {
                        Id = 2,
                        IdBuyer = 3,
                        IdProduct = 8,
                        ProductAmount = 324,
                        TotalPrice = 1300,
                        IsPayed = true,
                        IsDelivered = false,
                        IsActive = true,
                        InsertDate = DateTime.Now.AddDays(+3),
                        UpdateDate = null,
                        IsValid = false
                    },
                    new ValidatedOrderItem {
                        Id = 2,
                        IdBuyer = 3,
                        IdProduct = 8,
                        ProductAmount = 324,
                        TotalPrice = 1300,
                        IsPayed = true,
                        IsDelivered = false,
                        IsActive = true,
                        InsertDate = DateTime.Now.AddDays(+3),
                        UpdateDate = null,
                        IsValid = false
                    },
                    new ValidatedOrderItem {
                        Id = 3,
                        IdBuyer = 10,
                        IdProduct = 0,
                        ProductAmount = 1,
                        TotalPrice = 0,
                        IsPayed = true,
                        IsDelivered = false,
                        IsActive = true,
                        InsertDate = DateTime.Now.AddDays(-3),
                        UpdateDate = null,
                        IsValid = false
                    }
                };
            }
        }
    }
    public class ValidatedOrderItem : OrderItem
    {
        //TODO ESTO VIENE YA EN LA CLASE HEREDADA
        //public int Id { get; set; }
        //public int IdBuyer { get; set; }
        //public int IdProduct { get; set; }
        //public decimal ProductAmount { get; set; }
        //public decimal TotalPrice { get; set; }
        //public bool IsPayed { get; set; }
        //public bool IsDelivered { get; set; }
        //public bool IsActive { get; set; }
        //public DateTime InsertDate { get; set; }
        //public DateTime? UpdateDate { get; set; }
        public bool IsValid { get; set; }
    }
    //public class ValidatedOrderItem
    //{
    //    ValidatedOrderItem()
    //    {
    //        OrderItemContained = new OrderItem();
    //    }
    //    public OrderItem OrderItemContained { get; set; }
    //    public bool IsValid { get; set; }
    //}
}