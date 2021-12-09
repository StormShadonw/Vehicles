using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace Vehicles.API.Helpers
{
	public class BlobHelper : IBlobHelper
	{
		private readonly CloudBlobClient _blobClient;
		public BlobHelper(IConfiguration configuration)
		{
			string keys = configuration["Blob.ConnectionString"];
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(keys);
			_blobClient = storageAccount.CreateCloudBlobClient();
		}
		public Task<Guid> DeleteBlobAsync(Guid id, string contanierName)
		{
			throw new NotImplementedException();
		}

		public Task<Guid> UploadBlobAsync(IFormFile file, string contanierName)
		{
			throw new NotImplementedException();
		}

		public Task<Guid> UploadBlobAsync(byte[] file, string contanierName)
		{
			throw new NotImplementedException();
		}

		public Task<Guid> UploadBlobAsync(string image, string contanierName)
		{
			throw new NotImplementedException();
		}
	}
}
