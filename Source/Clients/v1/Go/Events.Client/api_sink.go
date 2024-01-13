/*
Events, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)

API version: 1.0
*/

// Code generated by OpenAPI Generator (https://openapi-generator.tech); DO NOT EDIT.

package Events.Client

import (
	"bytes"
	"context"
	"io"
	"net/http"
	"net/url"
)


// SinkAPIService SinkAPI service
type SinkAPIService service

type ApiSinkPutRequest struct {
	ctx context.Context
	ApiService *SinkAPIService
	uid *string
	content *string
}

func (r ApiSinkPutRequest) Uid(uid string) ApiSinkPutRequest {
	r.uid = &uid
	return r
}

func (r ApiSinkPutRequest) Content(content string) ApiSinkPutRequest {
	r.content = &content
	return r
}

func (r ApiSinkPutRequest) Execute() (*http.Response, error) {
	return r.ApiService.SinkPutExecute(r)
}

/*
SinkPut Method for SinkPut

 @param ctx context.Context - for authentication, logging, cancellation, deadlines, tracing, etc. Passed from http.Request or context.Background().
 @return ApiSinkPutRequest
*/
func (a *SinkAPIService) SinkPut(ctx context.Context) ApiSinkPutRequest {
	return ApiSinkPutRequest{
		ApiService: a,
		ctx: ctx,
	}
}

// Execute executes the request
func (a *SinkAPIService) SinkPutExecute(r ApiSinkPutRequest) (*http.Response, error) {
	var (
		localVarHTTPMethod   = http.MethodPut
		localVarPostBody     interface{}
		formFiles            []formFile
	)

	localBasePath, err := a.client.cfg.ServerURLWithContext(r.ctx, "SinkAPIService.SinkPut")
	if err != nil {
		return nil, &GenericOpenAPIError{error: err.Error()}
	}

	localVarPath := localBasePath + "/Sink"

	localVarHeaderParams := make(map[string]string)
	localVarQueryParams := url.Values{}
	localVarFormParams := url.Values{}

	if r.uid != nil {
		parameterAddToHeaderOrQuery(localVarQueryParams, "Uid", r.uid, "")
	}
	if r.content != nil {
		parameterAddToHeaderOrQuery(localVarQueryParams, "content", r.content, "")
	}
	// to determine the Content-Type header
	localVarHTTPContentTypes := []string{}

	// set Content-Type header
	localVarHTTPContentType := selectHeaderContentType(localVarHTTPContentTypes)
	if localVarHTTPContentType != "" {
		localVarHeaderParams["Content-Type"] = localVarHTTPContentType
	}

	// to determine the Accept header
	localVarHTTPHeaderAccepts := []string{}

	// set Accept header
	localVarHTTPHeaderAccept := selectHeaderAccept(localVarHTTPHeaderAccepts)
	if localVarHTTPHeaderAccept != "" {
		localVarHeaderParams["Accept"] = localVarHTTPHeaderAccept
	}
	req, err := a.client.prepareRequest(r.ctx, localVarPath, localVarHTTPMethod, localVarPostBody, localVarHeaderParams, localVarQueryParams, localVarFormParams, formFiles)
	if err != nil {
		return nil, err
	}

	localVarHTTPResponse, err := a.client.callAPI(req)
	if err != nil || localVarHTTPResponse == nil {
		return localVarHTTPResponse, err
	}

	localVarBody, err := io.ReadAll(localVarHTTPResponse.Body)
	localVarHTTPResponse.Body.Close()
	localVarHTTPResponse.Body = io.NopCloser(bytes.NewBuffer(localVarBody))
	if err != nil {
		return localVarHTTPResponse, err
	}

	if localVarHTTPResponse.StatusCode >= 300 {
		newErr := &GenericOpenAPIError{
			body:  localVarBody,
			error: localVarHTTPResponse.Status,
		}
		return localVarHTTPResponse, newErr
	}

	return localVarHTTPResponse, nil
}
