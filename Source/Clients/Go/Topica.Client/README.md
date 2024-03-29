# Go API client for topicaclient

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

## Overview
This API client was generated by the [OpenAPI Generator](https://openapi-generator.tech) project.  By using the [OpenAPI-spec](https://www.openapis.org/) from a remote server, you can easily generate an API client.

- API version: 1.0
- Package version: 0.0.1
- Build package: org.openapitools.codegen.languages.GoClientCodegen

## Installation

Install the following dependencies:

```sh
go get github.com/stretchr/testify/assert
go get golang.org/x/net/context
```

Put the package under your project folder and add the following in import:

```go
import topicaclient "github.com/GIT_USER_ID/GIT_REPO_ID"
```

To use a proxy, set the environment variable `HTTP_PROXY`:

```go
os.Setenv("HTTP_PROXY", "http://proxy_name:proxy_port")
```

## Configuration of Server URL

Default configuration comes with `Servers` field that contains server objects as defined in the OpenAPI specification.

### Select Server Configuration

For using other server than the one defined on index 0 set context value `topicaclient.ContextServerIndex` of type `int`.

```go
ctx := context.WithValue(context.Background(), topicaclient.ContextServerIndex, 1)
```

### Templated Server URL

Templated server URL is formatted using default variables from configuration or from context value `topicaclient.ContextServerVariables` of type `map[string]string`.

```go
ctx := context.WithValue(context.Background(), topicaclient.ContextServerVariables, map[string]string{
	"basePath": "v2",
})
```

Note, enum values are always validated and all unused variables are silently ignored.

### URLs Configuration per Operation

Each operation can use different server URL defined using `OperationServers` map in the `Configuration`.
An operation is uniquely identified by `"{classname}Service.{nickname}"` string.
Similar rules for overriding default operation server index and variables applies by using `topicaclient.ContextOperationServerIndices` and `topicaclient.ContextOperationServerVariables` context maps.

```go
ctx := context.WithValue(context.Background(), topicaclient.ContextOperationServerIndices, map[string]int{
	"{classname}Service.{nickname}": 2,
})
ctx = context.WithValue(context.Background(), topicaclient.ContextOperationServerVariables, map[string]map[string]string{
	"{classname}Service.{nickname}": {
		"port": "8443",
	},
})
```

## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*LoginAPI* | [**Login**](docs/LoginAPI.md#login) | **Post** /api/Login | 
*MessagesAPI* | [**AddMessage**](docs/MessagesAPI.md#addmessage) | **Post** /api/Messages | Creates a message under topic id.
*TopicsAPI* | [**CreateTopic**](docs/TopicsAPI.md#createtopic) | **Put** /api/Topics | 
*TopicsAPI* | [**DeleteMessage**](docs/TopicsAPI.md#deletemessage) | **Delete** /api/Topics/{topicId}/messages/{messageId} | 
*TopicsAPI* | [**DeleteTopic**](docs/TopicsAPI.md#deletetopic) | **Delete** /api/Topics/{topicId} | 
*TopicsAPI* | [**GetTopic**](docs/TopicsAPI.md#gettopic) | **Get** /api/Topics/{topicId} | 
*TopicsAPI* | [**GetTopics**](docs/TopicsAPI.md#gettopics) | **Get** /api/Topics | 
*TopicsAPI* | [**GetTotal**](docs/TopicsAPI.md#gettotal) | **Get** /api/Topics/Total | 


## Documentation For Models

 - [Entry](docs/Entry.md)
 - [LoginModel](docs/LoginModel.md)
 - [ProblemDetails](docs/ProblemDetails.md)
 - [Topic](docs/Topic.md)
 - [TopicMeta](docs/TopicMeta.md)
 - [TopicMetaPaginatedResponse](docs/TopicMetaPaginatedResponse.md)


## Documentation For Authorization


Authentication schemes defined for the API:
### Basic

- **Type**: HTTP basic authentication

Example

```go
auth := context.WithValue(context.Background(), topicaclient.ContextBasicAuth, topicaclient.BasicAuth{
	UserName: "username",
	Password: "password",
})
r, err := client.Service.Operation(auth, args)
```

### ApiKey

- **Type**: API key
- **API key parameter name**: X-API-KEY
- **Location**: HTTP header

Note, each API key must be added to a map of `map[string]APIKey` where the key is: X-API-KEY and passed in as the auth context for each request.

Example

```go
auth := context.WithValue(
		context.Background(),
		topicaclient.ContextAPIKeys,
		map[string]topicaclient.APIKey{
			"X-API-KEY": {Key: "API_KEY_STRING"},
		},
	)
r, err := client.Service.Operation(auth, args)
```

### Bearer

- **Type**: API key
- **API key parameter name**: Authorization
- **Location**: HTTP header

Note, each API key must be added to a map of `map[string]APIKey` where the key is: Authorization and passed in as the auth context for each request.

Example

```go
auth := context.WithValue(
		context.Background(),
		topicaclient.ContextAPIKeys,
		map[string]topicaclient.APIKey{
			"Authorization": {Key: "API_KEY_STRING"},
		},
	)
r, err := client.Service.Operation(auth, args)
```


## Documentation for Utility Methods

Due to the fact that model structure members are all pointers, this package contains
a number of utility functions to easily obtain pointers to values of basic types.
Each of these functions takes a value of the given basic type and returns a pointer to it:

* `PtrBool`
* `PtrInt`
* `PtrInt32`
* `PtrInt64`
* `PtrFloat`
* `PtrFloat32`
* `PtrFloat64`
* `PtrString`
* `PtrTime`

## Author



