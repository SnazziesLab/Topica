# TopicMeta

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | Pointer to **NullableString** |  | [optional] 
**CreatedOn** | Pointer to **time.Time** |  | [optional] 

## Methods

### NewTopicMeta

`func NewTopicMeta() *TopicMeta`

NewTopicMeta instantiates a new TopicMeta object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewTopicMetaWithDefaults

`func NewTopicMetaWithDefaults() *TopicMeta`

NewTopicMetaWithDefaults instantiates a new TopicMeta object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetId

`func (o *TopicMeta) GetId() string`

GetId returns the Id field if non-nil, zero value otherwise.

### GetIdOk

`func (o *TopicMeta) GetIdOk() (*string, bool)`

GetIdOk returns a tuple with the Id field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetId

`func (o *TopicMeta) SetId(v string)`

SetId sets Id field to given value.

### HasId

`func (o *TopicMeta) HasId() bool`

HasId returns a boolean if a field has been set.

### SetIdNil

`func (o *TopicMeta) SetIdNil(b bool)`

 SetIdNil sets the value for Id to be an explicit nil

### UnsetId
`func (o *TopicMeta) UnsetId()`

UnsetId ensures that no value is present for Id, not even an explicit nil
### GetCreatedOn

`func (o *TopicMeta) GetCreatedOn() time.Time`

GetCreatedOn returns the CreatedOn field if non-nil, zero value otherwise.

### GetCreatedOnOk

`func (o *TopicMeta) GetCreatedOnOk() (*time.Time, bool)`

GetCreatedOnOk returns a tuple with the CreatedOn field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetCreatedOn

`func (o *TopicMeta) SetCreatedOn(v time.Time)`

SetCreatedOn sets CreatedOn field to given value.

### HasCreatedOn

`func (o *TopicMeta) HasCreatedOn() bool`

HasCreatedOn returns a boolean if a field has been set.


[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


