using Dapper;
using ECommerce.Discount.Context;
using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
	public class DiscountService : IDiscountService
	{
		private readonly DapperContext _context;

		public DiscountService(DapperContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(CreateCouponDto createCouponDto)
		{
			string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";
			var parameters = new DynamicParameters();
			parameters.Add("@Code", createCouponDto.Code);
			parameters.Add("@Rate", createCouponDto.Rate);
			parameters.Add("@IsActive", createCouponDto.IsActive);
			parameters.Add("@ValidDate", createCouponDto.ValidDate);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteAsync(int id)
		{
			string query = "DELETE FROM Coupons WHERE Id = @Id";
			var parameters = new DynamicParameters();
			parameters.Add("@Id", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultCouponDto>> GetAllAsync()
		{
			string query = "SELECT * from Coupons";
			using (var connection = _context.CreateConnection())
			{
				var coupons = await connection.QueryAsync<ResultCouponDto>(query);
				return coupons.ToList();
			}
		}

		public async Task<ResultCouponDto> GetByIdAsync(int id)
		{
			string query = "SELECT * FROM Coupons WHERE Id = @Id";
			var parameters = new DynamicParameters();
			parameters.Add("@Id", id);
			using (var connection = _context.CreateConnection())
			{
				var coupon = await connection.QuerySingleOrDefaultAsync<ResultCouponDto>(query, parameters);
				return coupon;
			}
		}

		public async Task UpdateAsync(UpdateCouponDto updateCouponDto)
		{
			string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE Id = @Id";
			var parameters = new DynamicParameters();
			parameters.Add("@Id", updateCouponDto.Id);
			parameters.Add("@Code", updateCouponDto.Code);
			parameters.Add("@Rate", updateCouponDto.Rate);
			parameters.Add("@IsActive", updateCouponDto.IsActive);
			parameters.Add("@ValidDate", updateCouponDto.ValidDate);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}

}
