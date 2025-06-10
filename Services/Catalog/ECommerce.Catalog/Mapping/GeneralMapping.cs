using AutoMapper;
using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Dtos.FeatureDtos;
using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Dtos.OfferDiscountDtos;
using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Dtos.ProductImageDtos;
using ECommerce.Catalog.Dtos.SpecialOfferDtos;
using ECommerce.Catalog.Dtos.BrandDtos;
using ECommerce.Catalog.Dtos.AboutDtos;
using ECommerce.Catalog.Entities;

namespace ECommerce.Catalog.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();

			CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

			CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
			CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();

			CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
			CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
			CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();

			CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
			CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
			CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();

			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

			CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
			CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
			CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();

			CreateMap<Product, ResultProductWithCategoryDto>()
			.ForMember(dest => dest.CategoryName,
					  opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null)).ReverseMap();

			CreateMap<Brand, ResultBrandDto>().ReverseMap();
			CreateMap<Brand, CreateBrandDto>().ReverseMap();
			CreateMap<Brand, UpdateBrandDto>().ReverseMap();

			CreateMap<About, ResultAboutDto>().ReverseMap();
			CreateMap<About, CreateAboutDto>().ReverseMap();
			CreateMap<About, UpdateAboutDto>().ReverseMap();
		}
	}
}
