using System.Text.Json;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.OpenApi.Any;

namespace chrome_extenstions.Services
{
    public class FirebaseService
    {


        private readonly FirebaseClient firebaseClient;


        public FirebaseService(string authSecret, string basePath)
        {
            var firebaseConfig = GetFirebaseConfig(authSecret, basePath);
            firebaseClient = new FirebaseClient(firebaseConfig);
        }

        public List<T> Get<T>(string entity)
        {
            try
            {
                var datasource = firebaseClient.Get(entity);
                if (datasource != null)
                {
                    var dictionary = JsonSerializer.Deserialize<Dictionary<string, T>>(datasource.Body);
                    List<T> data = new List<T>();
                    foreach (var key in dictionary)
                    {
                        data.Add(key.Value);
                    }
                    return data;
                }
                else
                {
                    Console.WriteLine("No data found.");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }

        public object Set<T>(string entity, T value)
        {
            try
            {
                var response = firebaseClient.Set(entity, value);
                return JsonSerializer.Deserialize<object>(response.Body);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }

        public object Push<T>(string entity, T value, bool isMultipleData = false)
        {
            if (value == null) throw new ArgumentNullException(nameof(value), "Data not found");

            try
            {
                PushResponse response = null;

                /*if (isMultipleData)
                {
                    foreach (var item in value as List<AnyType>)
                    {
                        response = firebaseClient.Push(entity, item);
                    }
                }
                else
                {
                    response = firebaseClient.Push(entity, value);
                }*/
                response = firebaseClient.Push(entity, value);

                return response == null ? default : JsonSerializer.Deserialize<object>(response.Body);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }


        public object Delete<T>(string entity, string id)
        {
            try {
                var response = firebaseClient.Delete(entity);
                return JsonSerializer.Deserialize<object>(response.Body);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return default;
            }
        }
        private IFirebaseConfig  GetFirebaseConfig(string authSecret, string basePath)
        {
            return new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };
        }
    }
}
