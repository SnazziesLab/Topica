# \MessagesApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**add_message**](MessagesApi.md#add_message) | **POST** /api/Messages | Creates a message under topic id.



## add_message

> String add_message(topic_id, body)
Creates a message under topic id.

### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**topic_id** | Option<**String**> | If topicId is null, a new Topic will be generated with a random GUID |  |
**body** | Option<**String**> |  |  |

### Return type

**String**

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey), [Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

