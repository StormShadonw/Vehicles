using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Vehicles.API.Helpers
{
	public interface IBlobHelper
	{
		Task<Guid> UploadBlobAsync(IFormFile file, string contanierName);
		Task<Guid> UploadBlobAsync(byte[] file, string contanierName);
		Task<Guid> UploadBlobAsync(string image, string contanierName);
		Task DeleteBlobAsync(Guid id, string contanierName);

	}
}
