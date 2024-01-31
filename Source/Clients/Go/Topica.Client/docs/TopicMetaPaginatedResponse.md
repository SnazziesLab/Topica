# TopicMetaPaginatedResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Data** | Pointer to [**[]TopicMeta**](TopicMeta.md) |  | [optional] 
**Page** | Pointer to **int32** |  | [optional] 
**PageSize** | Pointer to **int32** |  | [optional] 
**Total** | Pointer to **int32** |  | [optional] 

## Methods

### NewTopicMetaPaginatedResponse

`func NewTopicMetaPaginatedResponse() *TopicMetaPaginatedResponse`

NewTopicMetaPaginatedResponse instantiates a new TopicMetaPaginatedResponse object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewTopicMetaPaginatedResponseWithDefaults

`func NewTopicMetaPaginatedResponseWithDefaults() *TopicMetaPaginatedResponse`

NewTopicMetaPaginatedResponseWithDefaults instantiates a new TopicMetaPaginatedResponse object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetData

`func (o *TopicMetaPaginatedResponse) GetData() []TopicMeta`

GetData returns the Data field if non-nil, zero value otherwise.

### GetDataOk

`func (o *TopicMetaPaginatedResponse) GetDataOk() (*[]TopicMeta, bool)`

GetDataOk returns a tuple with the Data field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetData

`func (o *TopicMetaPaginatedResponse) SetData(v []TopicMeta)`

SetData sets Data field to given value.

### HasData

`func (o *TopicMetaPaginatedResponse) HasData() bool`

HasData returns a boolean if a field has been set.

### SetDataNil

`func (o *TopicMetaPaginatedResponse) SetDataNil(b bool)`

 SetDataNil sets the value for Data to be an explicit nil

### UnsetData
`func (o *TopicMetaPaginatedResponse) UnsetData()`

UnsetData ensures that no value is present for Data, not even an explicit nil
### GetPage

`func (o *TopicMetaPaginatedResponse) GetPage() int32`

GetPage returns the Page field if non-nil, zero value otherwise.

### GetPageOk

`func (o *TopicMetaPaginatedResponse) GetPageOk() (*int32, bool)`

GetPageOk returns a tuple with the Page field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetPage

`func (o *TopicMetaPaginatedResponse) SetPage(v int32)`

SetPage sets Page field to given value.

### HasPage

`func (o *TopicMetaPaginatedResponse) HasPage() bool`

HasPage returns a boolean if a field has been set.

### GetPageSize

`func (o *TopicMetaPaginatedResponse) GetPageSize() int32`

GetPageSize returns the PageSize field if non-nil, zero value otherwise.

### GetPageSizeOk

`func (o *TopicMetaPaginatedResponse) GetPageSizeOk() (*int32, bool)`

GetPageSizeOk returns a tuple with the PageSize field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetPageSize

`func (o *TopicMetaPaginatedResponse) SetPageSize(v int32)`

SetPageSize sets PageSize field to given value.

### HasPageSize

`func (o *TopicMetaPaginatedResponse) HasPageSize() bool`

HasPageSize returns a boolean if a field has been set.

### GetTotal

`func (o *TopicMetaPaginatedResponse) GetTotal() int32`

GetTotal returns the Total field if non-nil, zero value otherwise.

### GetTotalOk

`func (o *TopicMetaPaginatedResponse) GetTotalOk() (*int32, bool)`

GetTotalOk returns a tuple with the Total field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetTotal

`func (o *TopicMetaPaginatedResponse) SetTotal(v int32)`

SetTotal sets Total field to given value.

### HasTotal

`func (o *TopicMetaPaginatedResponse) HasTotal() bool`

HasTotal returns a boolean if a field has been set.


[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


