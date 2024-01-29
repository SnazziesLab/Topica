# \TopicsApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**add_message**](TopicsApi.md#add_message) | **POST** /api/Topics/AddMessage | 
[**delete_message**](TopicsApi.md#delete_message) | **DELETE** /api/Topics/message | 
[**delete_topic**](TopicsApi.md#delete_topic) | **DELETE** /api/Topics | 
[**get_topic**](TopicsApi.md#get_topic) | **GET** /api/Topics/{id} | 
[**get_topics**](TopicsApi.md#get_topics) | **GET** /api/Topics | 



## add_message

> add_message(topic_id, message)


### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**topic_id** | Option<**String**> |  |  |
**message** | Option<**String**> |  |  |

### Return type

 (empty response body)

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## delete_message

> crate::models::Topic delete_message(topic_id, message_id)


### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**topic_id** | Option<**String**> |  |  |
**message_id** | Option<**uuid::Uuid**> |  |  |

### Return type

[**crate::models::Topic**](Topic.md)

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## delete_topic

> crate::models::Topic delete_topic(topic_name)


### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**topic_name** | Option<**String**> |  |  |

### Return type

[**crate::models::Topic**](Topic.md)

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## get_topic

> crate::models::Topic get_topic(id)


### Parameters


Name | Type | Description  | Required | Notes
------------- | ------------- | ------------- | ------------- | -------------
**id** | **String** |  | [required] |

### Return type

[**crate::models::Topic**](Topic.md)

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


## get_topics

> crate::models::Topic get_topics()


### Parameters

This endpoint does not need any parameter.

### Return type

[**crate::models::Topic**](Topic.md)

### Authorization

[Basic](../README.md#Basic), [ApiKey](../README.md#ApiKey)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

