using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Concretes
{
    public class ShoppingService:IShoppingService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShoppingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<ListAllShopping>> AllActiveShopping()
        {
            var shopping = await unitOfWork.GetRepository<ShoppingList>().GetAllAsync(x => x.IsShoppingComplate == false, x => x.User);
            List<ListAllShopping> allShoppings = new List<ListAllShopping>();
            foreach (var item in shopping)
            {
                allShoppings.Add(new ListAllShopping()
                {
                    ShoppingName = item.ShoppingName,
                    ShoppingDescription = item.ShoppingDescription,
                    ShoppingDate = item.ShoppingDate,
                    ShoppingId = item.ShoppingId,
                    FullName = item.User.UserFirstName + " " + item.User.UserLastName,
                    ComplatedDate = item.ComplateDate
                });
            }
            return allShoppings;
        }
    

        public async Task<List<ListAllShopping>> AllShopping()
        {
        var shopping = await unitOfWork.GetRepository<ShoppingList>().GetAllAsync(null,x => x.User);
        List<ListAllShopping> allShoppings = new List<ListAllShopping>();
        foreach (var item in shopping)
        {
            allShoppings.Add(new ListAllShopping()
            {
                ShoppingName = item.ShoppingName,
                ShoppingDescription = item.ShoppingDescription,
                ShoppingDate = item.ShoppingDate,
                ShoppingId = item.ShoppingId,
                FullName = item.User.UserFirstName + " " + item.User.UserLastName,
                ComplatedDate = item.ComplateDate
            });
        }
        return allShoppings;
    }


        public async Task CreateShopping(AddShoppingDTO shoppingDTO)
        {
            ShoppingList shopping=new ShoppingList()
            {
              ShoppingName=shoppingDTO.ShoppingName,
              ShoppingDescription=shoppingDTO.ShoppingDescription,
              UserId=shoppingDTO.UserId,
              
            };

            await unitOfWork.GetRepository<ShoppingList>().AddAsync(shopping);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<ListAllShopping>> GetAllComplatedShopping()
        {
            var shopping = await unitOfWork.GetRepository<ShoppingList>().GetAllAsync(x => x.IsShoppingComplate == true, x => x.User);
            List<ListAllShopping> allShoppings = new List<ListAllShopping>();
            foreach (var item in shopping)
            {
                allShoppings.Add(new ListAllShopping()
                {
                    ShoppingName = item.ShoppingName,
                    ShoppingDescription = item.ShoppingDescription,
                    ShoppingDate = item.ShoppingDate,
                    ShoppingId = item.ShoppingId,
                    FullName = item.User.UserFirstName + " " + item.User.UserLastName,
                    ComplatedDate=item.ComplateDate
                });
            }
            return allShoppings;
        }
    

        public async Task<List<ListAllShopping>> GetAllShopping()
        {
            var shopping = await unitOfWork.GetRepository<ShoppingList>().GetAllAsync(null, x => x.User);
            List<ListAllShopping> allShoppings = new List<ListAllShopping>();
            foreach (var item in shopping)
            {
                allShoppings.Add(new ListAllShopping()
                {
                    ShoppingName = item.ShoppingName,
                    ShoppingDescription = item.ShoppingDescription,
                    ShoppingDate = item.ShoppingDate,
                    ShoppingId = item.ShoppingId,
                    FullName = item.User.UserFirstName + " " + item.User.UserLastName,
                    Iscomplated = item.IsShoppingComplate,
                    ComplatedDate = item.ComplateDate


                }) ;
            }
                return allShoppings;
        }

        public async Task<List<ListAllShopping>> GetComplatedShoppingByUser(Guid userId)
        {
            var shopping = await unitOfWork.GetRepository<ShoppingList>().GetAllAsync(x => x.IsShoppingComplate == true&&x.UserId==userId, x => x.User);
            List<ListAllShopping> allShoppings = new List<ListAllShopping>();
            foreach (var item in shopping)
            {
                allShoppings.Add(new ListAllShopping()
                {
                    ShoppingName = item.ShoppingName,
                    ShoppingDescription = item.ShoppingDescription,
                    ShoppingDate = item.ShoppingDate,
                    ShoppingId = item.ShoppingId,
                    FullName = item.User.UserFirstName + " " + item.User.UserLastName,
                    ComplatedDate=item.ComplateDate
                });
            }
            return allShoppings;
        }

        public async Task<List<ListShoppingDTO>> GetListByUser(Guid userId)
        {
            var shopping=await unitOfWork.GetRepository<ShoppingList>().GetAllAsync(x=>x.UserId==userId&&x.IsShoppingComplate==false);
            List<ListShoppingDTO> listShoppingDTOs = new List<ListShoppingDTO>();
            foreach(var item in shopping)
            {
                listShoppingDTOs.Add(new ListShoppingDTO()
                {
                    ShoppingName = item.ShoppingName,
                    ShoppingDescription = item.ShoppingDescription,
                    ShoppingDate = item.ShoppingDate,
                    ShoppingId= item.ShoppingId,
                });
            }
                return listShoppingDTOs;
        }

        public async Task<List<Product>> GetProductByShopping(Guid shoppingId)
        {
            var product = await unitOfWork.GetRepository<ShoppingListProduct>().GetAllAsync(x => x.ShoppingListId == shoppingId, x => x.Product);
         List<Product> products=new List<Product>();   
            foreach(var item in product)
            {
                products.Add(new Product()
                {
                    ProductId = item.ProductId,
                    ProductDescription = item.Product.ProductDescription,
                    ProductImgUrl = item.Product.ProductImgUrl,
                    ProductName = item.Product.ProductName,

                });
            }
            return products;
        }

        public async Task UpdateShopping(Guid shoppingId)
        {
           var shopping=await unitOfWork.GetRepository<ShoppingList>().GetByGuidAsync(shoppingId);
            shopping.ComplateDate = DateTime.Now;
            shopping.IsShoppingComplate= true;
            await unitOfWork.SaveAsync();
        }
    }
}
