using AutoMapper;
using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiEcommerce.Application.Entity;
using WebApiEcommerce.Application.Interface;
using WebApiEcommerce.Application.Model;
using WebApiEcommerce.Domain.Common;
using WebApiEcommerce.Domain.Entity;
using WebApiEcommerce.Domain.Interface;
using WebApiEcommerce.Domain.Model;

namespace WebApiEcommerce.Application.App
{
    public class CartApplication : ICartApplication
    {
        private readonly ICartItemsRepository _CartItemsRepository;
        private IMapper _mapper;

        public CartApplication(ICartItemsRepository cartItemsRepository, IMapper mapper)
        {
            _CartItemsRepository = cartItemsRepository;
            _mapper = mapper;
        }
        public async Task<ResponseServiceDTO> ActiveProductCart(ActiveProdCartDTO ActiveProdCartDto)
        {
            try
            {
                bool active = await _CartItemsRepository.ActiveProductCart(ActiveProdCartDto.userId, ActiveProdCartDto.ProductId, ActiveProdCartDto.Active);
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "Se activo/desactivo el item del carrito",
                    Tipo = "Success"
                };

            }
            catch (CartItemNotFoundException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = ex.Message,
                    Tipo = "NotFound"
                };
            }
            catch (Exception)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }

        public async Task<ResponseServiceDTO> AddAsync(CartItemsDTO entity)
        {
            try
            {
                CartItems cartItemsMap = _mapper.Map<CartItemsDTO, CartItems>(entity);
                CartItems cartItems = await _CartItemsRepository.AddAsync(cartItemsMap);

                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "Se ha agregado el producto al carrito",
                    Tipo = "Success"
                };
            }   
            catch (InvalidQuantityException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = ex.Message,
                    Tipo = "BusinessError"
                };
            }
            catch (ProductNotFoundException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = "No se encuentran productos a ingresar",
                    Tipo = "NotFound"
                };
            }
            catch (InsufficientStockException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = ex.Message,
                    Tipo = "BusinessError"
                };
            }
            catch (ProductNotActiveException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = true,
                    Message = ex.Message,
                    Tipo = "BusinessError"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }

        public async Task<ResponseServiceDTO> GetByUserIdAsync(int userId)
        {
          
            try
            {
                IEnumerable<CartItems> cartItems = await _CartItemsRepository.GetByUserIdAsync(userId);

                ResponseServiceDTO response = new ResponseServiceDTO()
                {
                    Message = "Hay información en el carrito de compras",
                    Success = true,
                    Tipo = "Success",
                    Response = _mapper.Map<IEnumerable<CartItems>, IEnumerable<CartItemsDTO>>(cartItems)
                };
                return response;
            }
            catch (EmptyCartException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "NotFound"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }

        public async Task<ResponseServiceDTO> GetCartProductAsync(int userId)
        {
            try
            {
                IEnumerable<CartProducts> cartProducts = await _CartItemsRepository.GetCartProductAsync(userId);
                ResponseServiceDTO response = new ResponseServiceDTO()
                {
                    Message = "Información en el carrito de compras",
                    Success = true,
                    Tipo = "Success",
                    Response = _mapper.Map<IEnumerable<CartProducts>, IEnumerable<CartProductsDTO>>(cartProducts)
                };
                return response;
            }
            catch (EmptyCartException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "NotFound"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }

        public async Task<ResponseServiceDTO> RemoveItemAsync(RemoveItemsDTO entity)
        {
            try
            {
                CartItems cartItem = await _CartItemsRepository.RemoveItemAsync(entity.idUser, entity.iditem);
                ResponseServiceDTO response = new ResponseServiceDTO()
                {
                    Message = "Se removio el producto",
                    Success = true,
                    Tipo = "Success",
                    Response = _mapper.Map<CartItems, CartItemsDTO>(cartItem)
                };
                return response;
            }
            catch (EmptyCartException ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = ex.Message,
                    Tipo = "NotFound"
                };
            }
            catch (Exception ex)
            {
                return new ResponseServiceDTO
                {
                    Success = false,
                    Message = "Error interno del servidor.",
                    Tipo = "InternalError"
                };
            }
        }
    }
}
