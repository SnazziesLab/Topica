# Topic

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | Pointer to **NullableString** |  | [optional] 
**CreatedOn** | Pointer to **time.Time** |  | [optional] 
**History** | Pointer to [**[]Entry**](Entry.md) |  | [optional] 

## Methods

### NewTopic

`func NewTopic() *Topic`

NewTopic instantiates a new Topic object
This constructor will assign default values to properties that have it defined,
and makes sure properties required by API are set, but the set of arguments
will change when the set of required properties is changed

### NewTopicWithDefaults

`func NewTopicWithDefaults() *Topic`

NewTopicWithDefaults instantiates a new Topic object
This constructor will only assign default values to properties that have it defined,
but it doesn't guarantee that properties required by API are set

### GetId

`func (o *Topic) GetId() string`

GetId returns the Id field if non-nil, zero value otherwise.

### GetIdOk

`func (o *Topic) GetIdOk() (*string, bool)`

GetIdOk returns a tuple with the Id field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetId

`func (o *Topic) SetId(v string)`

SetId sets Id field to given value.

### HasId

`func (o *Topic) HasId() bool`

HasId returns a boolean if a field has been set.

### SetIdNil

`func (o *Topic) SetIdNil(b bool)`

 SetIdNil sets the value for Id to be an explicit nil

### UnsetId
`func (o *Topic) UnsetId()`

UnsetId ensures that no value is present for Id, not even an explicit nil
### GetCreatedOn

`func (o *Topic) GetCreatedOn() time.Time`

GetCreatedOn returns the CreatedOn field if non-nil, zero value otherwise.

### GetCreatedOnOk

`func (o *Topic) GetCreatedOnOk() (*time.Time, bool)`

GetCreatedOnOk returns a tuple with the CreatedOn field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetCreatedOn

`func (o *Topic) SetCreatedOn(v time.Time)`

SetCreatedOn sets CreatedOn field to given value.

### HasCreatedOn

`func (o *Topic) HasCreatedOn() bool`

HasCreatedOn returns a boolean if a field has been set.

### GetHistory

`func (o *Topic) GetHistory() []Entry`

GetHistory returns the History field if non-nil, zero value otherwise.

### GetHistoryOk

`func (o *Topic) GetHistoryOk() (*[]Entry, bool)`

GetHistoryOk returns a tuple with the History field if it's non-nil, zero value otherwise
and a boolean to check if the value has been set.

### SetHistory

`func (o *Topic) SetHistory(v []Entry)`

SetHistory sets History field to given value.

### HasHistory

`func (o *Topic) HasHistory() bool`

HasHistory returns a boolean if a field has been set.

### SetHistoryNil

`func (o *Topic) SetHistoryNil(b bool)`

 SetHistoryNil sets the value for History to be an explicit nil

### UnsetHistory
`func (o *Topic) UnsetHistory()`

UnsetHistory ensures that no value is present for History, not even an explicit nil

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


