﻿namespace AırportMvcUI.ApiServices
{
    public interface IHttpApiService
    {
        // Bir servisle haberleşirken yaptığımız operasyonlar : 
        // Get
        // Post
        // Put
        // Delete

        Task<T> GetData<T>(string requestUri);

        Task<T> PostData<T>(string requestUri, string jsonData);

        Task<bool> DeleteData(string requestUri);

		Task<T> PutData<T>(string requestUri, string jsonData);
	}
}