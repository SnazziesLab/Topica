# Topica.Client.Api.MessagesApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddMessage**](MessagesApi.md#addmessage) | **POST** /api/Messages | Creates a message under topic id. |

<a id="addmessage"></a>
# **AddMessage**
> string AddMessage (string? topicId = null, string? body = null)

Creates a message under topic id.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Topica.Client.Api;
using Topica.Client.Client;
using Topica.Client.Model;

namespace Example
{
    public class AddMessageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure HTTP basic authorization: Basic
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";
            // Configure API key authorization: ApiKey
            config.AddApiKey("X-API-KEY", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-KEY", "Bearer");
            // Configure API key authorization: Bearer
            config.AddApiKey("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("Authorization", "Bearer");

            var apiInstance = new MessagesApi(config);
            var topicId = "topicId_example";  // string? | If topicId is null, a new Topic will be generated with a random GUID (optional) 
            var body = "body_example";  // string? |  (optional) 

            try
            {
                // Creates a message under topic id.
                string result = apiInstance.AddMessage(topicId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MessagesApi.AddMessage: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AddMessageWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Creates a message under topic id.
    ApiResponse<string> response = apiInstance.AddMessageWithHttpInfo(topicId, body);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MessagesApi.AddMessageWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **topicId** | **string?** | If topicId is null, a new Topic will be generated with a random GUID | [optional]  |
| **body** | **string?** |  | [optional]  |

### Return type

**string**

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey), [Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

