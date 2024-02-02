# \MessagesAPI

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddMessage**](MessagesAPI.md#AddMessage) | **Post** /api/Messages | Creates a message under topic id.



## AddMessage

> string AddMessage(ctx).TopicId(topicId).Body(body).Execute()

Creates a message under topic id.

### Example

```go
package main

import (
	"context"
	"fmt"
	"os"
	openapiclient "github.com/GIT_USER_ID/GIT_REPO_ID"
)

func main() {
	topicId := "topicId_example" // string | If topicId is null, a new Topic will be generated with a random GUID (optional)
	body := "body_example" // string |  (optional)

	configuration := openapiclient.NewConfiguration()
	apiClient := openapiclient.NewAPIClient(configuration)
	resp, r, err := apiClient.MessagesAPI.AddMessage(context.Background()).TopicId(topicId).Body(body).Execute()
	if err != nil {
		fmt.Fprintf(os.Stderr, "Error when calling `MessagesAPI.AddMessage``: %v\n", err)
		fmt.Fprintf(os.Stderr, "Full HTTP response: %v\n", r)
	}
	// response from `AddMessage`: string
	fmt.Fprintf(os.Stdout, "Response from `MessagesAPI.AddMessage`: %v\n", resp)
}
```

### Path Parameters



### Other Parameters

Other parameters are passed through a pointer to a apiAddMessageRequest struct via the builder pattern


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **topicId** | **string** | If topicId is null, a new Topic will be generated with a random GUID | 
 **body** | **string** |  | 

### Return type

**string**

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey), [Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)

